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

namespace Learn
{
    /// <summary>
    /// Логика взаимодействия для AdminServices.xaml
    /// </summary>
    public partial class AdminServices : Window
    {
        LearnDatabaseEntities db = new LearnDatabaseEntities();
        List<Service> services = new List<Service>();
        public AdminServices()
        {
            InitializeComponent();
            services = db.Service.ToList();
            dataGrid.ItemsSource = services;
        }

        private void sortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var option = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            switch (option)
            {
                case "Сначала дешевые":
                    dataGrid.ItemsSource = services.OrderBy(s => s.Cost).ToList();
                    break;
                case "Сначала дорогие":
                    dataGrid.ItemsSource = services.OrderByDescending(s => s.Cost).ToList();
                    break;
            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                return;
            }
            else
            {
                dataGrid.ItemsSource = services.Where(s => s.Name.Contains(searchTextBox.Text)).ToList();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedService = (Service)dataGrid.SelectedItem;
                db.Service.Remove(selectedService);
                db.SaveChanges();
                dataGrid.ItemsSource = db.Service.ToList();
                MessageBox.Show("Удалено!");
            }
            catch
            {
                MessageBox.Show("Выберите услугу для удаления!");
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            new AddService().Show();
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            new UserService().Show();
            Close();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedService = (Service)dataGrid.SelectedItem;
            if (selectedService != null)
            {
                new EditService(selectedService).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Выберите услугу для редактирования!");
            }    
        }
    }
}

