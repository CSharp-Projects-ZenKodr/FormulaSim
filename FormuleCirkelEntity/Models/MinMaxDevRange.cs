﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormuleCirkelEntity.Models
{
    public class MinMaxDevRange
    {
        public int ValueKey { get; set; }
        public int MinDev { get; set; }
        public int MaxDev { get; set; }
    }
}
