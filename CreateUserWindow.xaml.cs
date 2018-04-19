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

namespace HomeWorkEF
{
    /// <summary>
    /// Логика взаимодействия для CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            using (var context = new UserContext())
            {
                if (context.User.Count(u => u.Login == loginBox.Text) == 0)
                {
                    User user = new User
                    {
                        Login = loginBox.Text,
                        Password = passwordBox.Password.GetHashCode(),
                        Address = addressBox.Text,
                        IsAdmin = isAdminBox.HasContent
                    };
                    context.User.Add(user);
                    context.SaveChanges();
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такой логин занят ведите другой");
                }
            }
        }
    }
}
