using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpaceRover.GameClasses
{
    internal class GameObject
    {
        public Vector2 Position;
        public Vector2 Size;
        public BitmapSource Bitmap;

        public GameObject(Vector2 position, Vector2 size, BitmapSource imageBitmap)
        {
            this.Position = position;
            this.Size = size;
            this.Bitmap = imageBitmap;
        }

        //public GameObject(Vector2 position, Vector2 size, SolidColorBrush color)
        //{
        //    this.Position = position;
        //    this.Size = size;
           
        //    //TODO: color 
        //}

        /// <summary>
        /// Initializes an Image object with Source, Width and Height
        /// </summary>
        /// <returns>
        /// Object of Image class with needed Attributes
        /// </returns>
        public Image RenderImage()
        {
            var img = new Image();
            img.Source = this.Bitmap;
            img.Width = this.Size.X;
            img.Height = this.Size.Y;

            return img;
        }
    }
}
