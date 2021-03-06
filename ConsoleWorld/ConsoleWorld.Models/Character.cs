﻿namespace ConsoleWorld.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System;

    public class Character : Unit
    {
        public Character() 
            : base()
        {
            this.Symbol = '@';
            this.BackgroundColor = ConsoleColor.Black;
            this.ForegroundColor = ConsoleColor.White;
            this.DungeonLevel = 1;
        }

        public int Id { get; set; }

        [Required]
        public Class Class { get; set; }
        
        [Range(0, int.MaxValue)]
        public int Exp { get; set; }

        public int LevelId { get; set; }

        public virtual Level Level { get; set; }

        [Range(0, int.MaxValue)]
        public int Points { get; set; }

        public int DungeonLevel { get; set; }
    }
}