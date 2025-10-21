function DownloadPDF(filename, byteBase64) {
    var oLink = document.createElement('a');
    oLink.download = filename;
    oLink.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(oLink);
    oLink.click();
    document.body.removeChild(oLink);
}

function ViewPDF(iframeID, byteBase64) {
    document.getElementById(iframeID).innerHTML = "";
    var contentType = 'application/pdf';
    var blob = b64toBlob(byteBase64, contentType);
    var blobUrl = URL.createObjectURL(blob);
    var ifra = document.createElement('iframe');
    ifra.setAttribute("src", blobUrl);
    ifra.style.with = "100%";
    ifra.style.height = "680%";
    document.getElementById(iframeID).appendChild(ifra);
}
function ViewPDFOrder(iframeID, byteBase64) {
    document.getElementById(iframeID).innerHTML = "";
    var contentType = 'application/pdf';
    var blob = b64toBlob(byteBase64, contentType);
    var blobUrl = URL.createObjectURL(blob);
    var ifra = document.createElement('iframe');
    ifra.addEventListener('load', function () {
        URL.revokeObjectURL(blobUrl);
    });
    ifra.setAttribute("src", blobUrl);
    ifra.setAttribute("loading", "lazy");
    ifra.style.with = "100%";
    ifra.style.height = "100%";
    document.getElementById(iframeID).appendChild(ifra);
}
function ViewPDFResultado(iframeID, byteBase64) {
    document.getElementById(iframeID).innerHTML = "";
    var contentType = 'application/pdf';
    var blob = b64toBlob(byteBase64, contentType);
    var blobUrl = URL.createObjectURL(blob);
    var ifra = document.createElement('iframe');
    ifra.addEventListener('load', function () {
        URL.revokeObjectURL(blobUrl);
    });
    ifra.setAttribute("src", blobUrl);
    ifra.setAttribute("loading", "lazy");
    ifra.style.setProperty('with', '100%', 'important');
    ifra.style.setProperty('height', '100%', 'important');
    document.getElementById(iframeID).appendChild(ifra);
    const NameObj = iframeID.replace("pdf-iframe-", "");
    const loadingElement = document.getElementById(`pdf-loading-${NameObj}`);
    const errorElement = document.getElementById(`pdf-error-${NameObj}`);
    loadingElement.style.setProperty('display', 'none', 'important');
    errorElement.style.setProperty('display', 'none', 'important');
}
function ConvertBase64ToBLOB(byteBase64) {
    var contentType = 'application/pdf';
    var blob = b64toBlob(byteBase64, contentType);
    var blobUrl = URL.createObjectURL(blob);
    return blobUrl;
}

function ViewPDFInNewTab(filename, byteBase64) {
    var contentType = 'application/pdf';
    var blob = b64toBlob(byteBase64, contentType);
    var blobUrl = URL.createObjectURL(blob);
    
    // Open PDF in new tab
    var newWindow = window.open(blobUrl, '_blank');
    
    // Clean up the blob URL after a delay to allow the browser to load it
    setTimeout(function() {
        URL.revokeObjectURL(blobUrl);
    }, 1000);
}

function b64toBlob(b64Data, contentType, sliceSize) {
    contentType = contentType || '';
    sliceSize = sliceSize || 512;

    var byteCharacters = atob(b64Data);
    var byteArrays = [];

    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);

        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        var byteArray = new Uint8Array(byteNumbers);

        byteArrays.push(byteArray);
    }

    var blob = new Blob(byteArrays, { type: contentType });
    return blob;
}


// Función mejorada para cargar PDF en iframe
window.loadPdfInIframe = function (itemId, pdfBase64) {
    try {
        const iframeElement = document.getElementById(`pdf-iframe-${itemId}`);
        const loadingElement = document.getElementById(`pdf-loading-${itemId}`);
        const errorElement = document.getElementById(`pdf-error-${itemId}`);

        if (!iframeElement || !pdfBase64) {
            showPdfError(itemId);
            return;
        }

        // Verificar que el Base64 sea válido
        if (!isValidBase64(pdfBase64)) {
            showPdfError(itemId);
            return;
        }

        // Crear un blob URL en lugar de usar data URL
        const binaryString = atob(pdfBase64);
        const bytes = new Uint8Array(binaryString.length);
        for (let i = 0; i < binaryString.length; i++) {
            bytes[i] = binaryString.charCodeAt(i);
        }

        const blob = new Blob([bytes], { type: 'application/pdf' });
        const blobUrl = URL.createObjectURL(blob);

        // Configurar el iframe con el blob URL
        iframeElement.src = blobUrl;

        // Mostrar el iframe después de un breve delay para asegurar la carga
        setTimeout(() => {
            if (loadingElement) {
                loadingElement.style.setProperty('display', 'none', 'important');
            }
            if (iframeElement) {
                iframeElement.style.display = 'block';
            }
        }, 500);

        // Limpiar el blob URL después de un tiempo para liberar memoria
        setTimeout(() => {
            URL.revokeObjectURL(blobUrl);
        }, 30000); // 30 segundos

    } catch (error) {
        console.error('Error loading PDF:', error);
        showPdfError(itemId);
    }
};

// Función para validar Base64
function isValidBase64(str) {
    try {
        return btoa(atob(str)) === str;
    } catch (err) {
        return false;
    }
}

// Función para ocultar el indicador de carga del PDF
window.hidePdfLoading = function (itemId) {
    const loadingElement = document.getElementById(`pdf-loading-${itemId}`);
    const iframeElement = document.getElementById(`pdf-iframe-${itemId}`);

    if (loadingElement && iframeElement) {
        loadingElement.style.setProperty('display', 'none', 'important');
        iframeElement.style.display = 'block';
    }
};

// Función para mostrar error en la carga del PDF
window.showPdfError = function (itemId) {
    const loadingElement = document.getElementById(`pdf-loading-${itemId}`);
    const iframeElement = document.getElementById(`pdf-iframe-${itemId}`);
    const errorElement = document.getElementById(`pdf-error-${itemId}`);

    if (loadingElement) {
        loadingElement.style.setProperty('display', 'none', 'important');
    }
    if (iframeElement) {
        iframeElement.style.setProperty('display', 'none', 'important');
    }
    if (errorElement) {
        errorElement.style.display = 'flex';
    }
};

// Función para descargar archivos desde Base64
window.downloadFileFromStream = function (fileName, base64Data) {
    try {
        const binaryString = atob(base64Data);
        const bytes = new Uint8Array(binaryString.length);
        for (let i = 0; i < binaryString.length; i++) {
            bytes[i] = binaryString.charCodeAt(i);
        }

        const blob = new Blob([bytes], { type: 'application/pdf' });
        const url = URL.createObjectURL(blob);

        const link = document.createElement('a');
        link.href = url;
        link.download = fileName;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);

        // Limpiar el URL después de la descarga
        setTimeout(() => {
            URL.revokeObjectURL(url);
        }, 1000);

    } catch (error) {
        console.error('Error downloading file:', error);
        alert('Error al descargar el archivo');
    }
};