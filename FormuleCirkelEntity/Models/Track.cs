﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FormuleCirkelEntity.Models
{
    public enum DNFodds { Increased, Neutral, Decreased }
    public enum RNGodds { Increased, Neutral, Decreased }
    public enum Specification { Topspeed, Acceleration, Stability, Handling }
    public class Track
    {
        public Track()
        {
            DNFodds = DNFodds.Neutral;
            RNGodds = RNGodds.Neutral;
        }

        [Key]
        public int TrackId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal LengthKM { get; set; }
        
        [EnumDataType(typeof(DNFodds))]
        public DNFodds DNFodds { get; set; }

        [EnumDataType(typeof(RNGodds))]
        public RNGodds RNGodds { get; set; }

        [EnumDataType(typeof(Specification))]
        public Specification Specification { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
