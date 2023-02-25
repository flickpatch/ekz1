using GlazAlmaz.Actions;
using GlazAlmaz.Database.Entity;
using GlazAlmaz.DataBase;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GlazAlmaz.Windows
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Tovar tovar = new Tovar();
        public AddWindow(Tovar t)
        {
            InitializeComponent();
            tovar = t;
            if(tovar.Id !=0)
            {
                btnAdd.Content = "Изменить";
                tblTitle.Text = "Изменение";
                DataContext = tovar;
            }
            cbKategory.ItemsSource = Efmodel.Init().Categories.ToList();
            
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            
            if (tovar.Id == 0)
            {
                tovar = DataContext as Tovar;
                try
                {
                    Efmodel.Init().Tovars.Add(tovar);
                    Efmodel.Init().SaveChanges();
                    MessageBox.Show("Успешно!");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность введеных данных!");
                }
              
            }
            else
            {
                try
                {
                    Efmodel.Init().Tovars.Update(tovar);
                    Efmodel.Init().SaveChanges();
                    MessageBox.Show("Успешно!");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность введеных данных!");
                }
               
            }
        }

        private void btnAddPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*jpeg;*.png;*.jfif";
            if (dialog.ShowDialog() == true)
            {
                tovar.Photo = File.ReadAllBytes(dialog.FileName);
                imgPhoto.Source = ImageConvert.ImageConverter(tovar.Photo);
            }
        }
    }
}
