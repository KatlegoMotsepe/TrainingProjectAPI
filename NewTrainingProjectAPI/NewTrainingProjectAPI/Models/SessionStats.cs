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
        public Guid SessionDetailsID { get; set; }

        [ForeignKey("SessionDetailsID")] 
        public virtual SessionDetails SessionDetails { get; set; }

        public SessionStats(){ }

        public SessionStats(AddStatsDTO addStats)
        {
            Id = new Guid();
            TopSpeed = addStats.TopSpeed;
            LowSpeed = addStats.LowSpeed;
            AvePace = addStats.AvePace;
            AveSpeed = addStats.AveSpeed;
            SessionDetailsID = 
                addStats.SessionDetailsID;
        }
    }
}
