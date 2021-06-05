using Models;
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
using System.Windows.Shapes;
using WpfClient.VM;

namespace WpfClient.UI
{
    /// <summary>
    /// Interaction logic for PlanetEditingWindow.xaml
    /// </summary>
    public partial class PlanetEditingWindow : Window
    {
        private PlanetEditVM vm;
        public PlanetEditingWindow()
        {
            InitializeComponent();
            this.vm = this.FindResource("VM") as PlanetEditVM;
        }
        public PlanetEditingWindow(Planet oldPlanet)
            : this()
        {
            this.vm.Planet = oldPlanet;
        }

        public Planet Planet { get => this.vm.Planet; }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
