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
using TvorchestvoProgram.Context;
using TvorchestvoProgram.Model;

namespace TvorchestvoProgram.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductDataPage.xaml
    /// </summary>
    public partial class ProductDataPage : Page
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductDataPage(Product product)
        {
            InitializeComponent();
            Product = product;
            this.DataContext = this;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void txbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void cmbSearchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditbTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Products = Data.u01.Product.ToList();
            ProductDataListView.ItemsSource = Products;
        }
    }
}
