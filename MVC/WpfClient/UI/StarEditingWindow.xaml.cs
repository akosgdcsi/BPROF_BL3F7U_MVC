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
    /// Interaction logic for StarEditingWindow.xaml
    /// </summary>
    public partial class StarEditingWindow : Window
    {
        private StarEditVM vm;
        public StarEditingWindow()
        {
            InitializeComponent();
            this.vm = this.FindResource("VM") as StarEditVM;
        }

        public StarEditingWindow(Star oldStar) : this()
        {
            this.vm.Star = oldStar;
        }

        public Star Star { get => this.vm.Star; }

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
