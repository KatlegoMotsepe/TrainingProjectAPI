using Microsoft.Extensions.Configuration.UserSecrets;
using NewTrainingProjectAPI.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewTrainingProjectAPI.Models
{
    public class Entries
    {
        public Guid Id { get; set; }

        public Guid UerId { get; set; }

        [ForeignKey("UerId")]
        public virtual User User { get; set; }

        [InverseProperty("Entries")]  
        public virtual ICollection<SessionStats> SessionStats { get; set; } 

        public Guid SessionDetailsId { get; set; }

        [ForeignKey("SessionDetailsId")]
        public virtual SessionDetails SessionDetails { get; set; }

        
        public Entries() { }

        public Entries(AddEntryDTO addEntryDTO)
        {
            Id = new Guid();
            UerId = addEntryDTO.UserId;
            SessionDetailsId = addEntryDTO.SessionDetailsID;
        }
    }
}
