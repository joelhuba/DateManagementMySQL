namespace DateManagementMySQL.Core.DTOS.resposne
{
    public class PatientReviewResponseDTO
    {
        public int IdReview { get; set; }          
        public string Name { get; set; }          
        public string LastName { get; set; }      
        public string Cedula { get; set; }          
        public string PhoneNumber { get; set; }    
        public byte Rating { get; set; }           
        public string ReviewText { get; set; }      
        public DateTime ReviewDate { get; set; }
    }
}
