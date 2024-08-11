namespace DateManagementMySQL.Core.DTOS
{
    public class PatientDTO
    {
        public int? PatientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public int IdEps { get; set; }
        public string PhoneNumber { get; set; }
        public bool UseWhatsApp { get; set; }
        public string EpsCode { get; set; }
    }
}
