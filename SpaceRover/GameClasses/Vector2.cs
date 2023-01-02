using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRover.GameClasses
{
    internal class Vector2
    {
        public double X;
        public double Y;

        public Vector2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Returns Vector2 with X and Y equals 0
        /// Shorthand for new Vector2(0, 0)
        /// </summary>
        /// <returns></returns>
        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

        /// <summary>
        /// Returns Vector2 with X and Y equals 1
        /// Shorthand for new Vector2(1, 1)
        /// </summary>
        /// <returns></returns>
        public static Vector2 One()
        {
            return new Vector2(1, 1);
        }
    }
}
