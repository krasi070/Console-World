namespace ConsoleWorld.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Level
    {
        public Level()
        {
            this.Characters = new HashSet<Character>();
        }

        public Level(int expToNextLevel, int pointsToReceive)
        {
            this.ExpToNextLevel = expToNextLevel;
            this.PointsToReceive = pointsToReceive;
            this.Characters = new HashSet<Character>();
        }

        [Key]
        public int LevelId { get; set; }

        [Range(0, int.MaxValue)]
        public int ExpToNextLevel { get; set; }

        [Range(0, int.MaxValue)]
        public int PointsToReceive { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}