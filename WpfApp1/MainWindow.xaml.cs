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

namespace AuthApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text.Trim();
            string email = tbEmail.Text.Trim();
            string pass = tbPass.Password.Trim();
            string pass2 = tbPass2.Password.Trim();

            if (name.Length < 1 || !email.Contains("@") || !email.Contains("."))
            {
                tbName.Background = Brushes.Pink;
                tbEmail.Background = Brushes.Pink;
            }
            else if (pass != pass2 || pass.Length < 6 || pass2.Length < 6)
            {
                tbPass.Background = Brushes.Pink;
                tbPass2.Background = Brushes.Pink;
            }
            else
            {
                tbName.Background = Brushes.Transparent;
                tbEmail.Background = Brushes.Transparent;
                tbPass.Background = Brushes.Transparent;
                tbPass2.Background = Brushes.Transparent;

                User user = new User(name, email, pass);

                if (email == user.Email)
                {
                    MessageBox.Show("Данная почта зарегистрированна");
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    Hide();
                }
            }


        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
