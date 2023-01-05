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
    internal class StaticMovingGameObject //: GameObject
    {
        Vector2 MovementPerClick;
        GameHandler GameHandler;

        private List<Key> UpKeys;
        private List<Key> LeftKeys;
        private List<Key> DownKeys;
        private List<Key> RightKeys;

        //public StaticMovingGameObject(Vector2 position, Vector2 size, BitmapSource bitmap, Vector2 movementPerClick, GameHandler gameHandler) : base(position, size, bitmap)
        //{
        //    this.MovementPerClick = movementPerClick;
        //    this.GameHandler = gameHandler;

        //    this.UpKeys = new List<Key> { Key.Up, Key.W };
        //    this.LeftKeys = new List<Key> { Key.Left, Key.A };
        //    this.DownKeys = new List<Key> { Key.Down, Key.S };
        //    this.RightKeys = new List<Key> { Key.Right, Key.D };

        //    GameHandler.Canvas.KeyDown += new System.Windows.Input.KeyEventHandler(KeyDown);
        //}

        //private void KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(this.UpKeys.Contains(e.Key))
        //    {
        //        this.Move(new Vector2(0, this.MovementPerClick.Y));
        //    }
        //    else if(this.LeftKeys.Contains(e.Key))
        //    {
        //        this.Move(new Vector2(- this.MovementPerClick.X, 0));
        //    }
        //    else if(this.DownKeys.Contains(e.Key))
        //    {
        //        this.Move(new Vector2(0, - this.MovementPerClick.Y));
        //    }
        //    else if(this.RightKeys.Contains(e.Key))
        //    {
        //        this.Move(new Vector2(this.MovementPerClick.X, 0));
        //    }
        //}

        /// <summary>
        /// Moves to actual positon + addVector
        /// </summary>
        /// <param name="addVector">
        /// Position that should be added to current position
        /// </param>
        //public void Move(Vector2 addVector)
        //{
        //    this.Position.Add(addVector);
        //}


    }
}
