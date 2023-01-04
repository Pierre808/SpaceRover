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

        /// <summary>
        /// space-rover-tile.png
        /// </summary>
        GameObject[,]GameTiles;
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

            for(int i = 0; i < GameTilesAmount.X; i++)
            {
                for(int j = 0; j < GameTilesAmount.Y; j++)
                {
                    this.GameHandler.Canvas.Children.Add(this.GameTiles[i, j].RenderImage());
                }
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
            for (int i = 0; i < this.GameTilesAmount.X; i++)
            {
                for (int j = 0; j < this.GameTilesAmount.Y; j++)
                {
                    this.GameTiles[i, j].SetPosY((size / this.GameTilesAmount.Y * j) + this.GameScreen.Position.Y);
                    this.GameTiles[i, j].SetPosX((size / this.GameTilesAmount.X * i) + this.GameScreen.Position.X);
                    this.GameTiles[i, j].SetHeight(size / this.GameTilesAmount.Y);
                    this.GameTiles[i, j].SetWidth(size / this.GameTilesAmount.X);

                    var tileImage = this.GameTiles[i, j].RenderImage();
                    Canvas.SetTop(tileImage, this.GameTiles[i, j].Position.Y);
                    Canvas.SetLeft(tileImage, this.GameTiles[i, j].Position.X);
                }
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

            if (this.GameTiles == null)
            {

                this.GameTiles = new GameObject[(int)this.GameTilesAmount.X, (int)this.GameTilesAmount.Y];

                for (int i = 0; i < this.GameTilesAmount.X; i++)
                {
                    for (int j = 0; j < this.GameTilesAmount.Y; j++)
                    {
                        this.GameTiles[i, j] = new GameObject(Vector2.Zero(), Vector2.Zero(), new BitmapImage(RessourceManager.GetImageRessourceUri("space-rover-tile.png")));
                    }
                }
            }
        }
    }
}
