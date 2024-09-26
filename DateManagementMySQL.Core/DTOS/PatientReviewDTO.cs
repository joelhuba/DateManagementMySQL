namespace DateManagementMySQL.Core.DTOS
{
    public class PatientReviewDTO
    {
        public int? IdReview { get; set; }
        public int? PatientId { get; set; }        
        public string ReviewText { get; set; }     
        public byte Rating { get; set; }
    }
}
