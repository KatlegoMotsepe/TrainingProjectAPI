﻿using System.ComponentModel.DataAnnotations.Schema;

namespace NewTrainingProjectAPI.Models
{
    public class Points
    {
        public Guid Id { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        //-25.68750142236085, 28.123616977269446

        public Guid SessionDetailsID { get; set; }

        [ForeignKey("SessionDetailsID")]  
        public virtual SessionDetails SessionDetails { get; set; }

    }
}