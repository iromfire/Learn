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
    /// Логика взаимодействия для EditService.xaml
    /// </summary>
    public partial class EditService : Window
    {
        LearnDatabaseEntities db = new LearnDatabaseEntities();
        public EditService(Service service)
        {
            InitializeComponent();
            nameTextBox.Text = service.Name; 
            imageTextBox.Text = service.Image;
            durationTextBox.Text = service.Duration;
            costTextBox.Text = service.Cost.ToString();
            saleTextBox.Text = service.Sale;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            new AdminServices().Show();
            Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = new Service
                {
                    Name = nameTextBox.Text,
                    Image = "image",
                    Duration = durationTextBox.Text,
                    Cost = int.Parse(costTextBox.Text),
                    Sale = saleTextBox.Text,
                };
                db.Service.Add(service);
                db.SaveChanges();
                MessageBox.Show("Изменено!");
                new AdminServices().Show();
                Close();
            }
            catch
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
    }
}
