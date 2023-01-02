using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        }

        private void loadedCanvas(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.Canvas.ActualWidth);

            //initialize GameScreen
            double gameScreenSize = 0;

            if(this.Canvas.ActualWidth > this.Canvas.ActualHeight)
            {
                //if width is larger than height -> take 8/10 of screen height as size
                gameScreenSize = this.Canvas.ActualHeight / 10 * 8;
            }
            else
            {
                gameScreenSize = this.Canvas.ActualWidth / 10 * 8;
            }

            string uri = RessourceManager.WriteResourceToTempFile("black.png");

            Console.Write("uri: " + uri);

            this.GameScreen = new GameObject(Vector2.Zero(), new Vector2(gameScreenSize, gameScreenSize), new BitmapImage(new Uri(uri)));
        }

        /// <summary>
        /// Reset size and position of elements on the canvas
        /// </summary>
        public void resizeCanvas()
        {
            
        }
    }
}
