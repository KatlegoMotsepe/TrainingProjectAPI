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

    }
}
