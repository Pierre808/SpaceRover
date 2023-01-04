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

        public void Add(Vector2 vector2)
        {
            this.X += vector2.X;
            this.Y += vector2.Y;
        }
        public void Remove(Vector2 vector2)
        {
            this.X -= vector2.X;
            this.Y -= vector2.Y;
        }

        public void Divide(Vector2 vector2)
        {
            this.X = this.X/ vector2.X;
            this.Y = this.Y/ vector2.Y;
        }

        public void Multiply(Vector2 vector2)
        {
            this.X = this.X * vector2.X;
            this.Y = this.Y * vector2.Y;
        }
        public Vector2 ReturnAdd(Vector2 vector2)
        {
            return new Vector2(this.X + vector2.X, this.Y + vector2.Y);
        }


        public Vector2 ReturnRemove(Vector2 vector2)
        {
            return new Vector2(this.X - vector2.X, this.Y - vector2.Y);
        }

        public Vector2 ReturnDivide(Vector2 vector2)
        {
            return new Vector2(this.X / vector2.X, this.Y / vector2.Y);
        }

        public Vector2 ReturnMultiply(Vector2 vector2)
        {
            return new Vector2(this.X * vector2.X, this.Y * vector2.Y);
        }

        /// <summary>
        /// Checks if Vectors X and Y equals 0
        /// </summary>
        /// <returns>
        /// True if Vectors X and Y are 0, else false
        /// </returns>
        public bool IsZero()
        {
            if(this.X == 0 && this.Y == 0)
            {
                return true;
            }

            return false;
        }
    }
}
