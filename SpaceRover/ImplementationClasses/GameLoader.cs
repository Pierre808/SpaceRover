using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;
using SpaceRover.GameClasses;

namespace SpaceRover.ImplementationClasses
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
            GameHandler = gameHandler;

            InitializeMethods();
        }

        /// <summary>
        /// sets methods for loaded and resize
        /// </summary>
        private void InitializeMethods()
        {
            GameHandler.CanvasLoaded += new RoutedEventHandler(loadedCanvas);
            GameHandler.CanvasResize += new SizeChangedEventHandler(ResizeCanvas);
        }

        /// <summary>
        /// runs when canvas is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadedCanvas(object sender, RoutedEventArgs e)
        {
            SetGameScreenAttributes();
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

            if (GameHandler.Canvas.ActualWidth > GameHandler.Canvas.ActualHeight)
            {
                //if width is larger than height -> take 80% of screen height as size
                size = GameScreen.SetHeightRelativeToCanvas(GameHandler.Canvas, 0.8);
                GameScreen.SetWidth(size);

                GameScreen.SetPosYRelativeToCanvas(GameHandler.Canvas, 0.1);
                GameScreen.SetPosX((GameHandler.Canvas.ActualWidth - GameScreen.GetSize().X) / 2);
            }
            else
            {
                size = GameScreen.SetWidthRelativeToCanvas(GameHandler.Canvas, 0.8);
                GameScreen.SetHeight(size);

                GameScreen.SetPosY((GameHandler.Canvas.ActualHeight - GameScreen.GetSize().Y) / 2);
                GameScreen.SetPosXRelativeToCanvas(GameHandler.Canvas, 0.1);
            }

            //add GameTiles
            if (GameScreen.GetChilds().Count == 0)
            {
                for (int i = 0; i < GameTilesAmount.X; i++)
                {
                    for (int j = 0; j < GameTilesAmount.Y; j++)
                    {
                        var tile = new GameObject(Vector2.Zero(), Vector2.Zero(), new BitmapImage(RessourceManager.GetImageRessourceUri("space-rover-tile.png")), "GameScreenTile", this.GameHandler);
                        tile.SetPosX(size / GameTilesAmount.X * i);
                        tile.SetPosY(size / GameTilesAmount.Y * j);
                        tile.SetHeight(size / GameTilesAmount.Y);
                        tile.SetWidth(size / GameTilesAmount.X);

                        GameScreen.AddChild(tile);
                    }
                }
            }

            //render
            this.GameScreen.RenderImage();
        }

        /// <summary>
        /// Initializes Attributes if null
        /// </summary>
        private void InitializeAttributes()
        {
            if (GameScreen == null)
            {
                GameScreen = new GameObject(Vector2.Zero(), Vector2.Zero(), new BitmapImage(RessourceManager.GetImageRessourceUri("black.png")), "GameScreen", this.GameHandler);
            }

            if (GameTilesAmount == null)
            {
                GameTilesAmount = new Vector2(8, 8);
            }


        }
    }
}
