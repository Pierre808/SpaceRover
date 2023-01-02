﻿using SpaceRover.GameClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceRover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLoader GameLoader;

        public MainWindow()
        {
            InitializeComponent();

            this.GameLoader = new GameLoader(Canvas);

            this.GameLoader.InitializeCanvas();

            this.SizeChanged += new SizeChangedEventHandler(resizeCanvas);
        }

        private void resizeCanvas(object sender, SizeChangedEventArgs e)
        {
            this.GameLoader.resizeCanvas();
        }
    }
}
