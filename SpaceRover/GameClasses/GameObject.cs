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

        private List<GameObject> Childs;

        /// <summary>
        /// will be changed on resize / repositioning
        /// </summary>
        private Vector2 oldPos = Vector2.Zero();
        private Vector2 oldSize = Vector2.Zero();
        
        public GameObject(Vector2 position, Vector2 size, BitmapSource bitmap)
        {
            this.Position = position;
            this.Size = size;
            this.Bitmap = bitmap;

            this.Childs = new List<GameObject>();
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

        public void AddChild(GameObject child)
        {
            child.Position.Add(this.Position);
            this.Childs.Add(child);
        }

        public List<GameObject> GetChilds()
        {
            return this.Childs;
        }

        /// <summary>
        /// Sets childs positon and size according to this (patent) GameObject
        /// </summary>
        public void ResetChildsOnCanvas()
        {
            var sizeDiff = this.Size.ReturnDivide(this.oldSize);

            var childRow = new List<double>();
            var childCol = new List<double>();

            foreach(var child in this.Childs)
            {
                if(!childRow.Contains(child.Position.Y))
                {
                    childRow.Add(child.Position.Y);
                }
                if(!childCol.Contains(child.Position.X))
                {
                    childCol.Add(child.Position.X);
                }
            }

            foreach (var child in this.Childs)
            {
                child.SetHeight(child.Size.Y * sizeDiff.Y);
                child.SetWidth(child.Size.X * sizeDiff.X);

                child.Position.Remove(this.oldPos);

                if(child.Position.X != 0)
                {
                    child.Position.X = child.Position.X * sizeDiff.X;
                }
                if(child.Position.Y != 0)
                {
                    child.Position.Y = child.Position.Y * sizeDiff.Y;
                }

                child.Position.Add(this.Position);
            }

            this.oldPos = Vector2.Zero();
            this.oldSize = Vector2.Zero();
        }

        public void SetHeight(double height)
        {
            setOldSizeY(this.Size.Y);

            this.Size.Y = height;

        }

        public void SetWidth(double width)
        {
            setOldSizeX(this.Size.X);

            this.Size.X = width;
        }

        public void SetPosX(double posX)
        {
            setOldPosX(this.Position.X);

            this.Position.X = posX;
        }

        public void SetPosY(double posY)
        {
            setOldPosY(this.Position.Y);

            this.Position.Y = posY;
        }

        public double SetWidthRelativeToCanvas(Canvas canvas, double widthPercentage)
        {
            setOldSizeX(this.Size.X);

            var width = canvas.ActualWidth * widthPercentage;
            this.Size.X = width;

            return width;
        }
        public double SetHeightRelativeToCanvas(Canvas canvas, double heightPercentage)
        {
            setOldSizeY(this.Size.Y);

            var height = canvas.ActualHeight * heightPercentage;
            this.Size.Y = height;

            return height;
        }

        public double SetPosXRelativeToCanvas(Canvas canvas, double posXPercantage)
        {
            setOldPosX(this.Position.X);

            var posX = canvas.ActualWidth * posXPercantage;
            this.Position.X = posX;

            return posX;
        }

        public double SetPosYRelativeToCanvas(Canvas canvas, double posYPercantage)
        {
            setOldPosY(this.Position.Y);

            var posY = canvas.ActualHeight * posYPercantage;
            this.Position.Y = posY;

            return posY;
        }


        private void setOldPosX(double pos)
        {
            if(this.oldPos.X == 0)
            {
                this.oldPos.X = pos;
            }
        }

        private void setOldPosY(double pos)
        {
            if (this.oldPos.Y == 0)
            {
                this.oldPos.Y = pos;
            }
        }

        private void setOldSizeX(double size)
        {
            if (this.oldSize.X == 0)
            {
                this.oldSize.X = size;
            }
        }

        private void setOldSizeY(double size)
        {
            if (this.oldSize.Y == 0)
            {
                this.oldSize.Y = size;
            }
        }
    }
}
