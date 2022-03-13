using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic_Snake
{
    public enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }
    class Settings
    {
        public static int  Width { get; set; }
        public static int Height { get; set; }

        public Directions CurrentDirection;

        public Settings()
        {
            Width = 16;
            Height = 16;
            CurrentDirection = Directions.Right;
        }
    }
}
