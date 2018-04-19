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

namespace HomeWorkEF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createUserButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow window = new CreateUserWindow();
            window.Show();
            this.Close();
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteUserWindow window = new DeleteUserWindow();
            window.Show();
            this.Close();
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                AlterUserWindow window = new AlterUserWindow(listBox.SelectedItem as User);
                window.Show();
                this.Close();
            }
            
        }

        private void selectAllUserButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new UserContext())
            {
                users = new List<User>(context.User.Where(user => !user.IsAdmin));
            }
            listBox.ItemsSource = users;
        }

        private void selectAllAdminButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new UserContext())
            {
                users = new List<User>(context.User.Where(user => user.IsAdmin));
            }
            listBox.ItemsSource = users;
        }
    }
}
