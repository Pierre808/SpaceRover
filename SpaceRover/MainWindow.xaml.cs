using SpaceRover.GameClasses;
using SpaceRover.ImplementationClasses;
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
        GameHandler GameHandler;
        GameLoader GameLoader;

        public MainWindow()
        {
            InitializeComponent();

            this.GameHandler = new GameHandler(Canvas);
            this.GameLoader = new GameLoader(this.GameHandler);
        }
    }
}

