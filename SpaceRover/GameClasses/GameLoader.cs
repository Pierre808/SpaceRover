using System;
using System.Collections.Generic;
using System.Linq;
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

            var obj = new GameObject(Vector2.Zero(), new Vector2(this.Canvas.ActualWidth, this.Canvas.ActualHeight), new BitmapImage(new Uri("C:/Users/pierr/Downloads/space-rover-cube.png")));

            var img = obj.RenderImage();


            Canvas.SetTop(img, obj.Position.Y);
            Canvas.SetLeft(img, obj.Position.X);

            this.Canvas.Children.Add(img);


            Console.WriteLine(obj.Size.Y);
            Console.WriteLine(img.ActualWidth);
        }

        /// <summary>
        /// Reset size and position of elements on the canvas
        /// </summary>
        public void resizeCanvas()
        {
            
        }
    }
}
