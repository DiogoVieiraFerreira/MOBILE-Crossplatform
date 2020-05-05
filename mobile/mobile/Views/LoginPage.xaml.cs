using System;
using System.IO;
using Xamarin.Forms;

namespace mobile.Views
{
    public partial class LoginPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "token");
        public LoginPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                string token = File.ReadAllText(_fileName);
            }
        }

        private void Button_Register(object sender, EventArgs e)
        {
            Console.WriteLine(FirstName.Text);
            Console.Error.WriteLine(LastName.Text);
            Console.WriteLine(mobile.Text);
        }

        private void Button_Login(object sender, EventArgs e)
        {

        }
    }
}