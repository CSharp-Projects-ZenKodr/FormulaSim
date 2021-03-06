﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FormuleCirkelEntity.Models
{
    public class Team : ModelBase, IArchivable
    {
        public string Abbreviation { get; set; }
        public string Country { get; set; }
        public string Biography { get; set; }
        public bool Archived { get; set; }

        public IList<TeamTrait> TeamTraits { get; } = new List<TeamTrait>();
        public IList<SeasonTeam> SeasonTeams { get; } = new List<SeasonTeam>();

        public int? SimUserId { get; set; }
        public SimUser SimUser { get; set; }
    }
}
