using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfClient.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Token { get; private set; }
        public LoginWindow()
        {
            InitializeComponent();
        }
        private async void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Auth");
                TokenViewModel tvm = await restService.Put<TokenViewModel, LoginViewModel>(new LoginViewModel()
                {
                    Username = textbox_username.Text,
                    Password = textbox_password.Password
                });
                Token = tvm.Token;
                this.DialogResult = true;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Wrong Password or username");
            }
        }
        private void Register_Button_click(object sender, RoutedEventArgs e)
        {
            RestService restService = new RestService("https://webapi20210607153930.azurewebsites.net/", "/Auth");
            restService.Post<RegisterViewModel>(new RegisterViewModel()
            {
                Email = textbox_username.Text,
                Password = textbox_password.Password
            });

            MessageBox.Show("You can log in now.");
        }
    }
}
