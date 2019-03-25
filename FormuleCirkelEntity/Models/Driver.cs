﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormuleCirkelEntity.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        public int DriverNumber { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<SeasonDriver> SeasonDrivers { get; set; }
    }
}