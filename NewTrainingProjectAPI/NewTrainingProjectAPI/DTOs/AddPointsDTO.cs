namespace NewTrainingProjectAPI.DTOs
{
    public class AddPointsDTO
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public Guid SessionID { get; set; } 
    }
}
