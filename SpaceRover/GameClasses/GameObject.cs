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

        private Image Image;

        public GameObject(Vector2 position, Vector2 size, BitmapSource bitmap)
        {
            this.Position = position;
            this.Size = size;
            this.Bitmap = bitmap;
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
            if(this.Image == null)
            {
                this.Image = new Image();
            }

            this.Image.Source = this.Bitmap;
            this.Image.Width = this.Size.X;
            this.Image.Height = this.Size.Y;

            return this.Image;
        }

        public void SetHeight(double height)
        {
            this.Size.Y = height;
        }

        public void SetWidth(double width)
        {
            this.Size.X = width;
        }

        public void SetPosX(double posX)
        {
            this.Position.X = posX;
        }

        public void SetPosY(double posY)
        {
            this.Position.Y = posY;
        }

        public double SetWidthRelativeToCanvas(Canvas canvas, double widthPercentage)
        {
            var width = canvas.ActualWidth * widthPercentage;
            this.Size.X = width;

            return width;
        }
        public double SetHeightRelativeToCanvas(Canvas canvas, double heightPercentage)
        {
            var height = canvas.ActualHeight * heightPercentage;
            this.Size.Y = height;

            return height;
        }

        public double SetPosXRelativeToCanvas(Canvas canvas, double posXPercantage)
        {
            var posX = canvas.ActualWidth * posXPercantage;
            this.Position.X = posX;

            return posX;
        }

        public double SetPosYRelativeToCanvas(Canvas canvas, double posYPercantage)
        {
            var posY = canvas.ActualHeight * posYPercantage;
            this.Position.Y = posY;

            return posY;
        }
    }
}
