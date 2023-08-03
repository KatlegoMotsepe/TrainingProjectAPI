namespace NewTrainingProjectAPI.DTOs
{
    public class AddDetailsDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserID { get; set; }   
    }
}
