using NewTrainingProjectAPI.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewTrainingProjectAPI.Models
{
    public class SessionStats
    {
        public Guid Id { get; set; }
        public double TopSpeed { get; set; }  
        public double LowSpeed { get; set; }
        public double AveSpeed { get; set; }
        public double AvePace { get; set; }
        public Guid EntriesId { get; set; }

        [ForeignKey("EntriesId")] 
        public virtual Entries Entries { get; set; }

        public SessionStats(){ }

        public SessionStats(AddStatsDTO addStats)
        {
            Id = new Guid();
            TopSpeed = addStats.TopSpeed;
            LowSpeed = addStats.LowSpeed;
            AvePace = addStats.AvePace;
            AveSpeed = addStats.AveSpeed;
        }
    }
}
