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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.UI;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string token;
        public MainWindow()
        {
            token = string.Empty;
            this.InitializeComponent();
            this.Login();
            if (token == string.Empty)
            {
                this.Close();
            }
        }

        public MainWindow(string recievedToken)
        {
            this.InitializeComponent();
            this.token = recievedToken;
            this.GetStarNames();
            this.RefreshPlanetList();
        }

        private async Task Login()
        {
            LoginWindow lw = new LoginWindow();
            if (lw.ShowDialog() == true)
            {
                token = lw.Token;
                await this.GetStarNames();
                await this.RefreshPlanetList();
            }
        }

        private async Task GetStarNames()
        {
            CustomerCbox.ItemsSource = null;
            RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Star", token);
            IEnumerable<Star> customernames = await restService.Get<Star>();

            CustomerCbox.ItemsSource = customernames;
        }

        private async void CustomerCbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Star star = CustomerCbox.SelectedItem as Star;
            await RefreshPlanetList(star);
        }

        private void ClearSelection_ButtonClick(object sender, RoutedEventArgs e)
        {
            CustomerCbox.SelectedIndex = -1;
        }

        private async Task RefreshPlanetList()
        {
            DGrid1.ItemsSource = null;
            RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Planet", token);
            IEnumerable<Planet> productList = await restService.Get<Planet>();
            DGrid1.ItemsSource = productList;
        }

        private async Task RefreshPlanetList(Star star)
        {
            if (star != null)
            {
                DGrid1.ItemsSource = null;
                IEnumerable<Planet> planetlist = star.Planets;
                DGrid1.ItemsSource = planetlist;
            }
            else
            {
                await RefreshPlanetList();
            }
        }

        private async void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerCbox.SelectedItem as Star == null)
                await this.RefreshPlanetList();
            else
                await this.RefreshPlanetList(CustomerCbox.SelectedItem as Star);
        }

        private async void AddNewPlanet_ButtonClick(object sender, RoutedEventArgs e)
        {
            PlanetEditingWindow win = new PlanetEditingWindow();
            if (win.ShowDialog() == true)
            {
                RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Planet", token);

                if (win.Planet.PlanetID == null || win.Planet.PlanetID == string.Empty)
                    win.Planet.PlanetID = Guid.NewGuid().ToString();
                if (CustomerCbox.SelectedItem as Star != null)
                    win.Planet.StarID = (CustomerCbox.SelectedItem as Star).StarID;

                restService.Post<Planet>(win.Planet);
                MessageBox.Show("planet added to database");

                await this.GetStarNames();
                await this.RefreshPlanetList();
            }
            else
            {
                MessageBox.Show("Adding new planet failed");
            }
        }

        private async void DeletePlanet_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (DGrid1.SelectedItem as Planet != null)
            {
                RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Planet", token);
                restService.Delete<string>((DGrid1.SelectedItem as Planet).PlanetID);
                MessageBox.Show("Product successfully deleted");
                await this.GetStarNames();
                await this.RefreshPlanetList();
            }
            else
            {
                MessageBox.Show("Could not delete product");
            }
        }

        private async void EditPlanet_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (DGrid1.SelectedItem as Planet != null)
            {
                PlanetEditingWindow win = new PlanetEditingWindow(DGrid1.SelectedItem as Planet);
                if (win.ShowDialog() == true)
                {
                    RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Planet", token);

                    if (win.Planet.PlanetID == null || win.Planet.PlanetID == string.Empty)
                        win.Planet.PlanetID = Guid.NewGuid().ToString();

                    restService.Put<string, Planet>((DGrid1.SelectedItem as Planet).PlanetID, win.Planet);
                    MessageBox.Show("Product updated in the database");

                    await this.GetStarNames();
                    await this.RefreshPlanetList();
                }
                else
                {
                    MessageBox.Show("Modifying selected product was not successful");
                }
            }
            else
            {
                MessageBox.Show("Could not modify selected product.");
            }
        }

        private async void AddNewStar_ButtonClick(object sender, RoutedEventArgs e)
        {
            StarEditingWindow win = new StarEditingWindow();
            if (win.ShowDialog() == true)
            {
                RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Star", token);

                if (win.Star.StarID == null || win.Star.StarID == string.Empty)
                    win.Star.StarID = Guid.NewGuid().ToString();

                restService.Post<Star>(win.Star);
                MessageBox.Show("Star added to database");

                await this.GetStarNames();
                await this.RefreshPlanetList();
            }
            else
            {
                MessageBox.Show("Adding new star was not successful");
            }
        }

        private async void EditStar_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (CustomerCbox.SelectedItem as Star != null)
            {
                StarEditingWindow win = new StarEditingWindow(CustomerCbox.SelectedItem as Star);
                if (win.ShowDialog() == true)
                {
                    RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Star", token);

                    if (win.Star.StarID == null || win.Star.StarID == string.Empty)
                        win.Star.StarID = Guid.NewGuid().ToString();

                    restService.Put<string, Star>((CustomerCbox.SelectedItem as Star).StarID, win.Star);
                    MessageBox.Show("Star updated in the database");

                    await this.GetStarNames();
                    await this.RefreshPlanetList();
                }
                else
                {
                    MessageBox.Show("Modifying selected star was not successful");
                }
            }
            else
            {
                MessageBox.Show("Could not modify selected star.");
            }
        }

        private async void Deletestar_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (CustomerCbox.SelectedItem as Star != null)
            {
                RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Star", token);
                restService.Delete<string>((CustomerCbox.SelectedItem as Star).StarID);
                MessageBox.Show("Star successfully deleted");
                await this.GetStarNames();
                await this.RefreshPlanetList();
            }
            else
            {
                MessageBox.Show("Could not delete star");
            }
        }

        private void SignOut_ButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
