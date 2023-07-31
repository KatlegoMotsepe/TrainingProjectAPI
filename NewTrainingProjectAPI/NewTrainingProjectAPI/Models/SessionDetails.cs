using NewTrainingProjectAPI.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewTrainingProjectAPI.Models
{
    public class SessionDetails
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [InverseProperty("SessionDetails")]
        public virtual ICollection<Points> Points { get; set; }

        public SessionDetails(){}

        public SessionDetails(AddDetailsDTO addDetails)
        {
            Id = new Guid();    
            StartDate = addDetails.StartDate;   
            EndDate = addDetails.EndDate;   
        }
    }
}
