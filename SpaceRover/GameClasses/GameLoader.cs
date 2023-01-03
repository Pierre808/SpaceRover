using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpaceRover.GameClasses
{
    internal class GameLoader
    {
        Canvas Canvas;
        GameObject GameScreen;

        SolidColorBrush MainBackgrkoundColor = Brushes.Beige;

        public GameLoader(Canvas canvas)
        {
            this.Canvas = canvas;
        }

        /// <summary>
        /// Set MainCanvas Attributes for the first time
        /// </summary>
        public void InitializeCanvas()
        {
            Canvas.Background = MainBackgrkoundColor;
            Canvas.Loaded += new System.Windows.RoutedEventHandler(loadedCanvas);
            Canvas.SizeChanged += new SizeChangedEventHandler(ResizeCanvas);
        }

        private void loadedCanvas(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.Canvas.ActualWidth);

            //initialize GameScreen
            SetGameScreenAttributes();
            this.Canvas.Children.Add(this.GameScreen.RenderImage());
        }

        /// <summary>
        /// Reset size and position of elements on the canvas
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
            //initialize if not already
            if (this.GameScreen == null)
            {
                this.GameScreen = new GameObject(Vector2.Zero(), Vector2.Zero(), new BitmapImage(RessourceManager.GetImageRessourceUri("space-rover-tile.png")));
            }

            //set height, width and position relative to Canvas
            if (this.Canvas.ActualWidth > this.Canvas.ActualHeight)
            {
                //if width is larger than height -> take 80% of screen height as size
                var size = this.GameScreen.SetHeightRelativeToCanvas(this.Canvas, 0.8);
                this.GameScreen.SetWidth(size);

                this.GameScreen.SetPosYRelativeToCanvas(this.Canvas, 0.1);
                this.GameScreen.SetPosX((this.Canvas.ActualWidth - this.GameScreen.Size.X) / 2);
            }
            else
            {
                var size = this.GameScreen.SetHeightRelativeToCanvas(this.Canvas, 0.8);
                this.GameScreen.SetHeight(size);

                this.GameScreen.SetPosY((this.Canvas.ActualHeight - this.GameScreen.Size.Y) / 2);
                this.GameScreen.SetPosXRelativeToCanvas(this.Canvas, 0.1);
            }

            //add to Canvas
            var gameScreenImage = this.GameScreen.RenderImage();

            Canvas.SetTop(gameScreenImage, this.GameScreen.Position.Y);
            Canvas.SetLeft(gameScreenImage, this.GameScreen.Position.X);
        }
    }
}
