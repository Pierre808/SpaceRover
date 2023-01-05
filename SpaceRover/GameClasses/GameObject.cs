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
        private Vector2 Position;
        private Vector2 Size;
        private BitmapSource Bitmap;
        string Tag;
        int Zindex;

        private Image Image;

        private List<GameObject> Childs;

        private GameHandler GameHandler;

        /// <summary>
        /// Helper for childs resizing and repositioning
        /// will be changed on resize / repositioning
        /// </summary>
        private Vector2 oldPos = Vector2.Zero();
        private Vector2 oldSize = Vector2.Zero();
        
        public GameObject(Vector2 position, Vector2 size, BitmapSource bitmap, string tag, GameHandler gameHandler)
        {
            this.Position = position;
            this.Size = size;
            this.Bitmap = bitmap;
            this.Tag = tag;
            this.Zindex = 0;

            this.Image = new Image();

            this.Childs = new List<GameObject>();

            this.GameHandler = gameHandler;


            //add to GameHandler if not already
            if (!this.GameHandler.GetLoadedGameObjects().Contains(this))
            {
                this.GameHandler.AddLoadedGameObject(this);

                this.GameHandler.Canvas.Children.Add(this.Image);
            }
        }

        public GameObject(Vector2 position, Vector2 size, BitmapSource bitmap, GameHandler gameHandler) 
            :this(position, size, bitmap, "New GameObject", gameHandler)
        {
        }

        /// <summary>
        /// Sets Image attributes like Source, Width and Height, ... and sets image on Canvas
        /// </summary>
        public void RenderImage()
        {
            //set image
            this.Image.Source = this.Bitmap;
            this.Image.Width = this.Size.X;
            this.Image.Height = this.Size.Y;

            //set on Canvas
            Canvas.SetTop(this.Image ,this.Position.Y);
            Canvas.SetLeft(this.Image ,this.Position.X);
            Canvas.SetZIndex(this.Image ,this.Zindex);

            this.ResetChildsOnCanvas();
        }

        public void AddChild(GameObject child)
        {
            child.SetPosition(child.GetPosition().ReturnAdd(this.Position));
            this.Childs.Add(child);
        }

        public List<GameObject> GetChilds()
        {
            return this.Childs;
        }

        /// <summary>
        /// Sets childs positon and size according to this (patent) GameObject
        /// </summary>
        private void ResetChildsOnCanvas()
        {
            if(this.oldSize.IsZero())
            {
                return;
            }

            var sizeDiff = this.Size.ReturnDivide(this.oldSize);

            foreach (var child in this.Childs)
            {
                child.SetHeight(child.Size.Y * sizeDiff.Y);
                child.SetWidth(child.Size.X * sizeDiff.X);

                child.Position.Remove(this.oldPos);

                if(child.Position.X != 0)
                {
                    child.SetPosition(child.GetPosition().ReturnMultiplyX(sizeDiff.X));
                    //child.Position.X = child.Position.X * sizeDiff.X;
                }
                if(child.Position.Y != 0)
                {
                    child.SetPosition(child.GetPosition().ReturnMultiplyY(sizeDiff.Y));
                    //child.Position.Y = child.Position.Y * sizeDiff.Y;
                }

                child.SetPosition(child.GetPosition().ReturnAdd(this.Position));
                //child.Position.Add(this.Position);


                child.RenderImage();
            }

            this.oldPos = Vector2.Zero();
            this.oldSize = Vector2.Zero();
        }


        //getting pos and size

        /// <summary>
        /// Gets the positon Vector2 of a GameObject
        /// </summary>
        /// <returns>
        /// Vector2
        /// </returns>
        public Vector2 GetPosition()
        {
            return this.Position;
        }

        /// <summary>
        /// Gets the size of this GameObject
        /// </summary>
        /// <returns>
        /// Vector2 : size
        /// </returns>
        public Vector2 GetSize()
        {
            return this.Size;
        }


        //setting height, width, pos 

        /// <summary>
        /// Sets position of GameObject to a Vector2
        /// </summary>
        /// <param name="position">
        /// Vector2 of new position
        /// </param>
        public void SetPosition(Vector2 position)
        {
            this.Position = position;
        }

        /// <summary>
        /// Sets size of GameObject to a new Vector2
        /// </summary>
        /// <param name="size">
        /// Vector2 of new size
        /// </param>
        public void SetSize(Vector2 size)
        {
            this.Size = size;
        }

        /// <summary>
        /// Sets height value of this GameObject
        /// </summary>
        /// <param name="height">
        /// New height
        /// </param>
        public void SetHeight(double height)
        {
            setOldSizeY(this.Size.Y);

            this.Size.Y = height;

        }

        /// <summary>
        /// Sets width value of this GameObject
        /// </summary>
        /// <param name="width">
        /// Value of new width
        /// </param>
        public void SetWidth(double width)
        {
            setOldSizeX(this.Size.X);

            this.Size.X = width;
        }

        /// <summary>
        /// Sets new value for X positon
        /// </summary>
        /// <param name="posX">
        /// New X position
        /// </param>
        public void SetPosX(double posX)
        {
            setOldPosX(this.Position.X);

            this.Position.X = posX;
        }

        /// <summary>
        /// Sets new value for Y positon
        /// </summary>
        /// <param name="posY">
        /// New Y position
        /// </param>
        public void SetPosY(double posY)
        {
            setOldPosY(this.Position.Y);

            this.Position.Y = posY;
        }

        /// <summary>
        /// Sets the width relative (in percentage) to a canvas width
        /// </summary>
        /// <param name="canvas">The canvas</param>
        /// <param name="widthPercentage">Percentage of new width</param>
        /// <returns></returns>
        public double SetWidthRelativeToCanvas(Canvas canvas, double widthPercentage)
        {
            setOldSizeX(this.Size.X);

            var width = canvas.ActualWidth * widthPercentage;
            this.Size.X = width;

            return width;
        }

        /// <summary>
        /// Sets height relative (in percantage) to a canvas
        /// </summary>
        /// <param name="canvas">The canvas</param>
        /// <param name="heightPercentage">Percentage of new width</param>
        /// <returns></returns>
        public double SetHeightRelativeToCanvas(Canvas canvas, double heightPercentage)
        {
            setOldSizeY(this.Size.Y);

            var height = canvas.ActualHeight * heightPercentage;
            this.Size.Y = height;

            return height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="posXPercantage"></param>
        /// <returns></returns>
        public double SetPosXRelativeToCanvas(Canvas canvas, double posXPercantage)
        {
            setOldPosX(this.Position.X);

            var posX = canvas.ActualWidth * posXPercantage;
            this.Position.X = posX;

            return posX;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="posYPercantage"></param>
        /// <returns></returns>
        public double SetPosYRelativeToCanvas(Canvas canvas, double posYPercantage)
        {
            setOldPosY(this.Position.Y);

            var posY = canvas.ActualHeight * posYPercantage;
            this.Position.Y = posY;

            return posY;
        }

        /// <summary>
        /// Get GameObject tag
        /// </summary>
        /// <returns>
        /// Tag of this GameObject
        /// </returns>
        public string GetTag()
        {
            return this.Tag;
        }

        /// <summary>
        /// Sets tag
        /// </summary>
        /// <param name="tag">
        /// Tag value
        /// </param>
        public void SetTag(string tag)
        {
            this.Tag = tag;
        }

        /// <summary>
        /// Sets value for Zindex
        /// </summary>
        /// <param name="zindex">
        /// New Zindex value
        /// </param>
        public void SetZindex(int zindex)
        {
            this.Zindex = zindex;
        }

        /// <summary>
        /// Gets Zindex value
        /// </summary>
        /// <returns>
        /// Zindex value
        /// </returns>
        public int GetZindex()
        {
            return this.Zindex;
        }



        //vars for rendering methods

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
