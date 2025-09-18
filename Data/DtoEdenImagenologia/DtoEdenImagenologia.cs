namespace LaboratorioRamos.Data.DtoEdenImagenologia
{
    public class DtoEdenImagenologiaCount
    {
        public int total_count { get; set; } = 0;
        public bool success { get; set; }
    }
    public class DtoEdenImagenologia
    {
        //public List<Datum>? data { get; set; }
        //public List<Datum>? results { get; set; }
        //public Errors errors { get; set; }
        //public bool success { get; set; }
        //public int total_count { get; set; } = 0;
        public string url { get; set; }
        public bool success { get; set; }
    }

    public class Appointment
    {
        public string id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
    }

    public class Code1
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string folio { get; set; }
        public string priority { get; set; }
        public string description { get; set; }
        public string comments { get; set; }
        public ReferringPractitioner referring_practitioner { get; set; }
        public string created_at { get; set; }
        public string status { get; set; }
        public string viewer_link { get; set; }
        public string pdf_url { get; set; }
        public string pdf_letterhead_url { get; set; }
        public string study_viewer_link { get; set; }
        public string public_study_viewer_link { get; set; }
        public string report_viewer_link { get; set; }
        public string report_pdf_url { get; set; }
        public string report_rtf_url { get; set; }
        public string report_pdf_letterhead_url { get; set; }
        public PacsStudy pacs_study { get; set; }
        public ManagementStudy management_study { get; set; }
        public Patient patient { get; set; }
        public Modality modality { get; set; }
        public Facility facility { get; set; }
        public Room room { get; set; }
        public Appointment appointment { get; set; }
        public NursingUnit nursing_unit { get; set; }
    }

    public class Errors
    {
    }

    public class Facility
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Field
    {
        public string value { get; set; }
    }

    public class ManagementStudy
    {
        public string id { get; set; }
        public string name { get; set; }
        public Code1 code { get; set; }
        public Modality modality { get; set; }
    }

    public class Modality
    {
        public string id { get; set; }
        public string identifier { get; set; }
    }

    public class NursingUnit
    {
        public string identifier { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class PacsStudy
    {
        public string id { get; set; }
        public string dicom_date_time { get; set; }
        public string status { get; set; }
        public List<Report> reports { get; set; }
        public List<StudyPdfFile> study_pdf_files { get; set; }
    }

    public class Patient
    {
        public string id { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public string birth_date { get; set; }
        public string identifier { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string phone_code { get; set; }
        public PhoneCountry phone_country { get; set; }
        public PatientData patient_data { get; set; }
    }

    public class PatientData
    {
        public SaleChannel sale_channel { get; set; }
    }

    public class PhoneCountry
    {
        public string id { get; set; }
        public string iso_code { get; set; }
    }

    public class ReferringPractitioner
    {
        public string id { get; set; }
        public string external_identifier { get; set; }
        public string full_name { get; set; }
        public string name { get; set; }
        public string first_surname { get; set; }
        public string last_surname { get; set; }
        public User user { get; set; }
        public string gender { get; set; }
    }

    public class Report
    {
        public SignedBy signed_by { get; set; }
        public List<Field> fields { get; set; }
    }

    public class Room
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class SaleChannel
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class SignedBy
    {
        public string full_name { get; set; }
        public User user { get; set; }
        public string identifier { get; set; }
    }

    public class StudyPdfFile
    {
        public string file_url { get; set; }
        public string status { get; set; }
        public string updated_at { get; set; }
    }

    public class User
    {
        public string email { get; set; }
    }



}
