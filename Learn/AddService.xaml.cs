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

namespace Learn
{
    /// <summary>
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        LearnDatabaseEntities db = new LearnDatabaseEntities();
        byte[] image;
        public AddService()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = new Service
                {
                    Name = nameTextBox.Text,
                    Image = image.ToString(),
                    Duration = durationTextBox.Text,
                    Cost = int.Parse(costTextBox.Text),
                    Sale = saleTextBox.Text,
                };
                db.Service.Add(service);
                db.SaveChanges();
                MessageBox.Show("Добавлено!");
                new AdminServices().Show();
                Close();
            }
            catch { 
                MessageBox.Show("Заполните все поля корректно!");    
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            new AdminServices().Show();
            Close();
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); 
            openFileDialog.ShowDialog(); 
            image = File.ReadAllBytes(openFileDialog.FileName);
        }
    }
}
