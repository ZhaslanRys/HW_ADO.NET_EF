using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AlterUserWindow.xaml
    /// </summary>
    public partial class AlterUserWindow : Window
    {
        User user;
        MainWindow window = new MainWindow();
        public AlterUserWindow(User user)
        {
            InitializeComponent();

            this.user = user;
            loginBox.Text = user.Login;
            addressBox.Text = user.Address;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
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
                    context.Entry(user).State = EntityState.Modified;
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
