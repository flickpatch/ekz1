using GlazAlmaz.Database.Entity;
using GlazAlmaz.DataBase;
using GlazAlmaz.Windows;
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
    /// Interaction logic for TovarPage.xaml
    /// </summary>
    public partial class TovarPage : Page
    {
        private static User user = new User();
        public TovarPage( User u)
        {
            InitializeComponent();
            cbKategory.ItemsSource = Efmodel.Init().Categories.ToList();
            cbCena.Items.Add("Убывание");
            cbCena.Items.Add("Возрастание");
            cbCena.Items.Add("Дефолт");
            user = u;
            if(user.Role!= "Администратор")
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnChange.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
            }
            UpdateData();
        }
        private void UpdateData()
        {
            lvTovars.ItemsSource = Efmodel.Init().Tovars.Where(t=> t.Name.Contains(tbSearch.Text)).ToList();
        }

        private void btnADdClick(object sender, RoutedEventArgs e)
        {
            new AddWindow(new Tovar()).ShowDialog();
            UpdateData();
        }

        private void btnChangeClick(object sender, RoutedEventArgs e)
        {

            Tovar tovar = lvTovars.SelectedItem as Tovar;
            if (tovar != null)
            {
                new AddWindow(tovar).ShowDialog();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Выберите товар!");
            }
        }

        private void tbSearchTextChange(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            if (lvTovars.SelectedItems != null)
            {

                if (MessageBox.Show("Вы дуйствительно хотите удалить данный товар?", "Предупреждение", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    Efmodel.Init().Tovars.Remove(lvTovars.SelectedItems as Tovar);
                MessageBox.Show("Успешно");
            }

        }

        private void btnAddZClick(object sender, RoutedEventArgs e)
        {
            Tovar tovar = lvTovars.SelectedItem as Tovar;
            if (tovar != null)
            {               
                new AddWindow(tovar).ShowDialog();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Выберите товар!");
            }
        }

        private void ChangeCena(object sender, SelectionChangedEventArgs e)
        {
            if(cbCena.Text == "Убывание")
            {
                
            }
        }
    }
}
