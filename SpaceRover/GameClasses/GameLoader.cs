using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;

namespace SpaceRover.GameClasses
{
    /// <summary>
    /// Implementation of own game methods 
    /// </summary>
    internal class GameLoader
    {
        GameHandler GameHandler;
        GameObject GameScreen;

        Vector2 GameTilesAmount;

        public GameLoader(GameHandler gameHandler)
        {
            this.GameHandler = gameHandler;

            InitializeMethods(); 
        }

        /// <summary>
        /// sets methods for loaded and resize
        /// </summary>
        private void InitializeMethods()
        {
            this.GameHandler.CanvasLoaded += new RoutedEventHandler(loadedCanvas);
            this.GameHandler.CanvasResize += new SizeChangedEventHandler(ResizeCanvas);
        }

        /// <summary>
        /// runs when canvas is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadedCanvas(object sender, RoutedEventArgs e)
        {
            SetGameScreenAttributes();

            this.GameHandler.Canvas.Children.Add(this.GameScreen.RenderImage());

            foreach(var child in this.GameScreen.GetChilds())
            {
                var img = child.RenderImage();

                this.GameHandler.Canvas.Children.Add(img);
            }
        }

        /// <summary>
        /// runs when canvas is resized (window resize) 
        /// </summary>
        public void ResizeCanvas(object sender, SizeChangedEventArgs e)
        {
            SetGameScreenAttributes();
        }

        /// <summary>
        /// Sets position, size etc. of GameScreen on canvas according to the values of this.GameScreen
        /// </summary>
        private void SetGameScreenAttributes()
        {
            InitializeAttributes();
            
            //set height, width and position relative to Canvas
            double size;

            if (this.GameHandler.Canvas.ActualWidth > this.GameHandler.Canvas.ActualHeight)
            {
                //if width is larger than height -> take 80% of screen height as size
                size = this.GameScreen.SetHeightRelativeToCanvas(this.GameHandler.Canvas, 0.8);
                this.GameScreen.SetWidth(size);

                this.GameScreen.SetPosYRelativeToCanvas(this.GameHandler.Canvas, 0.1);
                this.GameScreen.SetPosX((this.GameHandler.Canvas.ActualWidth - this.GameScreen.Size.X) / 2);
            }
            else
            {
                size = this.GameScreen.SetWidthRelativeToCanvas(this.GameHandler.Canvas, 0.8);
                this.GameScreen.SetHeight(size);

                this.GameScreen.SetPosY((this.GameHandler.Canvas.ActualHeight - this.GameScreen.Size.Y) / 2);
                this.GameScreen.SetPosXRelativeToCanvas(this.GameHandler.Canvas, 0.1);
            }

            //add GameTiles
            if (this.GameScreen.GetChilds().Count == 0)
            {
                for (int i = 0; i < this.GameTilesAmount.X; i++)
                {
                    for(int j = 0; j < this.GameTilesAmount.Y; j++)
                    {
                        var tile = new GameObject(Vector2.Zero(), Vector2.Zero(), new BitmapImage(RessourceManager.GetImageRessourceUri("space-rover-tile.png")));
                        tile.SetPosX(size / this.GameTilesAmount.X * i);
                        tile.SetPosY(size / this.GameTilesAmount.Y * j);
                        tile.SetHeight(size / this.GameTilesAmount.Y);
                        tile.SetWidth(size / this.GameTilesAmount.X);

                        this.GameScreen.AddChild(tile);
                    }
                }
            }
            else
            {
                this.GameScreen.ResetChildsOnCanvas();
            }

            foreach(var child in this.GameScreen.GetChilds())
            {
                var tileImage = child.RenderImage();

                Canvas.SetTop(tileImage, child.Position.Y);
                Canvas.SetLeft(tileImage, child.Position.X);
            }


            //add to Canvas
            var gameScreenImage = this.GameScreen.RenderImage();

            Canvas.SetTop(gameScreenImage, this.GameScreen.Position.Y);
            Canvas.SetLeft(gameScreenImage, this.GameScreen.Position.X);
        }

        /// <summary>
        /// Initializes Attributes if null
        /// </summary>
        private void InitializeAttributes()
        {
            if (this.GameScreen == null)
            {
                this.GameScreen = new GameObject(Vector2.Zero(), Vector2.Zero(), new BitmapImage(RessourceManager.GetImageRessourceUri("black.png")));
            }

            if (this.GameTilesAmount == null)
            {
                this.GameTilesAmount = new Vector2(8, 8);
            }

            
        }
    }
}
