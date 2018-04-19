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
    /// Логика взаимодействия для DeleteUserWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        public DeleteUserWindow()
        {
            InitializeComponent();
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new UserContext())
            {
                var user = context.User.FirstOrDefault(u => u.Login == deleteLoginBox.Text);
                if (user!=null)
                {
                    context.User.Remove(user);
                    context.SaveChanges();
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                }
            }
        }
    }
}
