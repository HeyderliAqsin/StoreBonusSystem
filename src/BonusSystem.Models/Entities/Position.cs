﻿using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class Position:BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}
