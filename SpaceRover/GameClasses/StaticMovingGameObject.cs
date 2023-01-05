using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SpaceRover.GameClasses
{
    /// <summary>
    /// GameObject with colision and static movement     
    /// Movement is static e.g. 5px per click
    /// </summary>
    internal class StaticMovingGameObject : GameObject
    {
        /// <summary>
        /// Indicates how much this GameObject will move at once (e.g. 5units each time it moves on X axis)
        /// </summary>
        Vector2 Movement;
        GameHandler GameHandler;

        //Movement keys

        private List<Key> UpKeys;
        private List<Key> LeftKeys;
        private List<Key> DownKeys;
        private List<Key> RightKeys;

        public StaticMovingGameObject(Vector2 position, Vector2 size, BitmapSource bitmap, string tag, GameHandler gameHandler, Vector2 movement) : base(position, size, bitmap, tag, gameHandler)
        {
            this.Movement = movement;
            this.GameHandler = gameHandler;

            this.UpKeys = new List<Key> { Key.Up, Key.W };
            this.LeftKeys = new List<Key> { Key.Left, Key.A };
            this.DownKeys = new List<Key> { Key.Down, Key.S };
            this.RightKeys = new List<Key> { Key.Right, Key.D };

            this.GameHandler.Canvas.KeyDown += new System.Windows.Input.KeyEventHandler(KeyDown);
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if(this.UpKeys.Contains(e.Key))
            {
                this.Move(new Vector2(0, - this.Movement.Y));
            }
            else if(this.LeftKeys.Contains(e.Key))
            {
                this.Move(new Vector2(- this.Movement.X, 0));
            }
            else if(this.DownKeys.Contains(e.Key))
            {
                this.Move(new Vector2(0, this.Movement.Y));
            }
            else if(this.RightKeys.Contains(e.Key))
            {
                this.Move(new Vector2(this.Movement.X, 0));
            }
        }

        /// <summary>
        /// Moves to actual positon + addVector
        /// </summary>
        /// <param name="addVector">
        /// Position that should be added to current position
        /// </param>
        public void Move(Vector2 addVector)
        {
            this.SetPosition(this.GetPosition().ReturnAdd(addVector));
            this.RenderImage();
        }

        public void SetMovement(Vector2 movement)
        {
            this.Movement = movement;
        }
    }
}
