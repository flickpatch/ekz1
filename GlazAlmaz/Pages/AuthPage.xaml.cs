using GlazAlmaz.Database.Entity;
using GlazAlmaz.DataBase;
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

namespace GlazAlmaz.Pages
{
    /// <summary>
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuthClick(object sender, RoutedEventArgs e)
        {
            User user = Efmodel.Init().Users.Where(u => u.Login == tbLogin.Text && u.Pass == PbPass.Password).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show("Успешно. Вы "+ user.Role);
                NavigationService.Navigate(new TovarPage(user));
            }
            else
                MessageBox.Show("Не верное имя пользователя или пароль.");
        }
    }
}
