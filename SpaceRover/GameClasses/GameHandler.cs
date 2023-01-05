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
    /// <summary>
    /// Handles Events as CanvasLoaded, Resize, ...
    /// </summary>
    internal class GameHandler
    {
        /// <summary>
        /// Application main canvas
        /// </summary>
        public Canvas Canvas { get; private set; }

        /// <summary>
        /// Application main backgroundcolor
        /// </summary>
        SolidColorBrush MainBackgrkoundColor = Brushes.Beige;

        List<GameObject> LoadedGameObjects;


        public GameHandler(Canvas canvas)
        {
            this.Canvas = canvas;

            this.LoadedGameObjects = new List<GameObject>();

            this.Start();
        }

        /// <summary>
        /// OnCanvasLoaded
        /// </summary>
        public event RoutedEventHandler CanvasLoaded;
        protected virtual void OnCanvasLoaded(object sender, RoutedEventArgs e)
        {
            CanvasLoaded?.Invoke(this, e);
        }

        /// <summary>
        /// OnCanvasResize
        /// </summary>
        public event SizeChangedEventHandler CanvasResize;
        protected virtual void OnCanvasResize(object sender, SizeChangedEventArgs e)
        {
            CanvasResize?.Invoke(this, e);
        }

        /// <summary>
        /// Start method that runs all necessary methods
        /// </summary>
        private void Start()
        {
            InitializeCanvas();
        }

        /// <summary>
        /// Set Canvas Attributes for the first time
        /// </summary>
        private void InitializeCanvas()
        {
            this.SetBackground(this.MainBackgrkoundColor);
            Canvas.Loaded += new System.Windows.RoutedEventHandler(OnCanvasLoaded);
            Canvas.SizeChanged += new SizeChangedEventHandler(OnCanvasResize);
        }

        /// <summary>
        /// Sets backgroundcolor of canvas
        /// </summary>
        /// <param name="color">Color to set as background</param>
        public void SetBackground(SolidColorBrush color)
        {
            this.MainBackgrkoundColor = color;

            Canvas.Background = this.MainBackgrkoundColor;
        }

        public List<GameObject> GetLoadedGameObjects()
        {
            return this.LoadedGameObjects;
        }

        public void AddLoadedGameObject(GameObject gameObject)
        {
            this.LoadedGameObjects.Add(gameObject);
        }

        public void RemoveLoadedGameObject(GameObject gameObject)
        {
            this.LoadedGameObjects.Remove(gameObject);
        }
    }
}
