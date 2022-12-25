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
using System.Xml.Linq;

namespace AuthApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string pass = tbPass.Password.Trim();

            if (!email.Contains("@") || !email.Contains(".") || pass.Length < 6)
            {
                tbEmail.Background = Brushes.Pink;
                tbPass.Background = Brushes.Pink;
            }
            else
            {
                tbEmail.Background = Brushes.Transparent;
                tbPass.Background = Brushes.Transparent;

                User authUser = null;

                using(AppContext db = new AppContext()) {
                    authUser = db.Users.Where(b => b.Email == email && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void Window_Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            Hide();
        }
    }
}
