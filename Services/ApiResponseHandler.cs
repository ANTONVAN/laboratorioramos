using MudBlazor;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace LaboratorioRamos.Services
{
    public interface IApiResponseHandler
    {
        Task<bool> HandleResponseAsync<T>(HttpResponseMessage response, string operation = "", bool showNotification = true, CancellationToken cancellationToken = default);
        Task<T?> HandleResponseWithDataAsync<T>(HttpResponseMessage response, string operation = "", bool showNotification = true, CancellationToken cancellationToken = default) where T : class;
        void ShowSuccessMessage(string message);
        void ShowErrorMessage(string message);
        void ShowWarningMessage(string message);
        void ShowInfoMessage(string message);
    }

    public class ApiResponseHandler : IApiResponseHandler
    {
        private readonly ISnackbar _snackbar;
        private readonly ILogger<ApiResponseHandler> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiResponseHandler(ISnackbar snackbar, ILogger<ApiResponseHandler> logger)
        {
            _snackbar = snackbar ?? throw new ArgumentNullException(nameof(snackbar));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<bool> HandleResponseAsync<T>(HttpResponseMessage response, string operation = "", bool showNotification = true, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(response);
            
            var success = response.IsSuccessStatusCode;
            var message = GetMessageByStatusCode(response.StatusCode, operation);
            var severity = GetSeverityByStatusCode(response.StatusCode);

            // Log the response for debugging
            _logger.LogInformation("API Response: {StatusCode} for operation: {Operation}", response.StatusCode, operation);

            if (showNotification && !string.IsNullOrEmpty(message))
            {
                _snackbar.Add(message, severity);
            }

            return success;
        }

        public async Task<T?> HandleResponseWithDataAsync<T>(HttpResponseMessage response, string operation = "", bool showNotification = true, CancellationToken cancellationToken = default) where T : class
        {
            ArgumentNullException.ThrowIfNull(response);
            
            var success = response.IsSuccessStatusCode;
            var message = GetMessageByStatusCode(response.StatusCode, operation);
            var severity = GetSeverityByStatusCode(response.StatusCode);

            // Log the response for debugging
            _logger.LogInformation("API Response: {StatusCode} for operation: {Operation}", response.StatusCode, operation);

            if (showNotification && !string.IsNullOrEmpty(message))
            {
                _snackbar.Add(message, severity);
            }

            if (success && response.Content != null)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken);
                    if (string.IsNullOrEmpty(content))
                    {
                        _logger.LogWarning("Empty response content for operation: {Operation}", operation);
                        return null;
                    }

                    return JsonSerializer.Deserialize<T>(content, _jsonOptions);
                }
                catch (JsonException ex)
                {
                    _logger.LogError(ex, "JSON deserialization error for operation: {Operation}", operation);
                    if (showNotification)
                    {
                        _snackbar.Add($"Error al procesar la respuesta JSON: {ex.Message}", Severity.Error);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error processing response for operation: {Operation}", operation);
                    if (showNotification)
                    {
                        _snackbar.Add($"Error inesperado al procesar la respuesta: {ex.Message}", Severity.Error);
                    }
                    return null;
                }
            }

            return null;
        }

        public void ShowSuccessMessage(string message)
        {
            ArgumentException.ThrowIfNullOrEmpty(message);
            _snackbar.Add($"✅ {message}", Severity.Success);
            _logger.LogInformation("Success message shown: {Message}", message);
        }

        public void ShowErrorMessage(string message)
        {
            ArgumentException.ThrowIfNullOrEmpty(message);
            _snackbar.Add($"❌ {message}", Severity.Error);
            _logger.LogError("Error message shown: {Message}", message);
        }

        public void ShowWarningMessage(string message)
        {
            ArgumentException.ThrowIfNullOrEmpty(message);
            _snackbar.Add($"⚠️ {message}", Severity.Warning);
            _logger.LogWarning("Warning message shown: {Message}", message);
        }

        public void ShowInfoMessage(string message)
        {
            ArgumentException.ThrowIfNullOrEmpty(message);
            _snackbar.Add($"ℹ️ {message}", Severity.Info);
            _logger.LogInformation("Info message shown: {Message}", message);
        }

        private static string GetMessageByStatusCode(HttpStatusCode statusCode, string operation)
        {
            var operationText = string.IsNullOrWhiteSpace(operation) ? "operación" : operation;
            
            return statusCode switch
            {
                // Success codes
                HttpStatusCode.OK => $"✅ {operationText} completada exitosamente",
                HttpStatusCode.Created => $"✅ {operationText} creada exitosamente",
                HttpStatusCode.Accepted => $"✅ {operationText} aceptada",
                HttpStatusCode.NoContent => $"✅ {operationText} procesada correctamente",

                // Client errors
                HttpStatusCode.BadRequest => "❌ Solicitud inválida. Verifique los datos ingresados",
                HttpStatusCode.Unauthorized => "🔐 No autorizado. Verifique sus credenciales",
                HttpStatusCode.Forbidden => $"🚫 Acceso denegado. No tiene permisos para esta {operationText}",
                HttpStatusCode.NotFound => $"🔍 {operationText} no encontrada",
                HttpStatusCode.MethodNotAllowed => $"⚠️ Método no permitido para esta {operationText}",
                HttpStatusCode.Conflict => $"⚠️ Conflicto en la {operationText}. El recurso ya existe",
                HttpStatusCode.UnprocessableEntity => $"❌ Datos inválidos para la {operationText}",
                HttpStatusCode.TooManyRequests => "⏰ Demasiadas solicitudes. Intente nuevamente más tarde",

                // Server errors
                HttpStatusCode.InternalServerError => "🔥 Error interno del servidor. Contacte al administrador",
                HttpStatusCode.BadGateway => "🌐 Error de comunicación con el servidor",
                HttpStatusCode.ServiceUnavailable => "🔧 Servicio temporalmente no disponible",
                HttpStatusCode.GatewayTimeout => "⏱️ Tiempo de espera agotado. Intente nuevamente",

                // Default case
                _ => statusCode >= HttpStatusCode.OK && statusCode < HttpStatusCode.BadRequest
                    ? $"✅ {operationText} completada" 
                    : $"❌ Error en {operationText} (Código: {(int)statusCode})"
            };
        }

        private static Severity GetSeverityByStatusCode(HttpStatusCode statusCode)
        {
            return statusCode switch
            {
                // Success codes
                HttpStatusCode.OK => Severity.Success,
                HttpStatusCode.Created => Severity.Success,
                HttpStatusCode.Accepted => Severity.Success,
                HttpStatusCode.NoContent => Severity.Success,

                // Client errors
                HttpStatusCode.BadRequest => Severity.Warning,
                HttpStatusCode.Unauthorized => Severity.Warning,
                HttpStatusCode.Forbidden => Severity.Warning,
                HttpStatusCode.NotFound => Severity.Warning,
                HttpStatusCode.MethodNotAllowed => Severity.Warning,
                HttpStatusCode.Conflict => Severity.Warning,
                HttpStatusCode.UnprocessableEntity => Severity.Warning,
                HttpStatusCode.TooManyRequests => Severity.Warning,

                // Server errors
                HttpStatusCode.InternalServerError => Severity.Error,
                HttpStatusCode.BadGateway => Severity.Error,
                HttpStatusCode.ServiceUnavailable => Severity.Error,
                HttpStatusCode.GatewayTimeout => Severity.Error,

                // Default case
                _ => statusCode >= HttpStatusCode.InternalServerError ? Severity.Error : Severity.Warning
            };
        }
    }
}
