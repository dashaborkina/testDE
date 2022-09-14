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
using System.Data.Entity;

namespace test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            dgr.ItemsSource = optbazaEntities.GetContext().tovar.ToList();

            cbx_category.ItemsSource = optbazaEntities.GetContext().category.ToList();
            cbx_post.ItemsSource = optbazaEntities.GetContext().postavshiki.ToList();
            cbx_cat.ItemsSource = optbazaEntities.GetContext().category.ToList();
            cbx_pos.ItemsSource = optbazaEntities.GetContext().postavshiki.ToList();
        }

        public void SearchTovar()
        {
            var curr = optbazaEntities.GetContext().tovar.ToList();

            if (cbx_category.SelectedItem != null)
                curr = curr.Where(x => x.idcategory.Equals(cbx_category.SelectedIndex + 1)).ToList();
            if (txb_title.Text != "")
                curr = curr.Where(x => x.title.ToLower().Contains(txb_title.Text.ToLower().ToString())).ToList();
            if (cbx_post.SelectedItem != null)
                curr = curr.Where(x => x.idpostavshik.Equals(cbx_post.SelectedIndex + 1)).ToList();

            dgr.ItemsSource = curr.ToList();
        }

        private void txb_title_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SearchTovar();
        }

        private void cbx_category_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SearchTovar();
        }

        private void cbx_post_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchTovar();
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            cbx_post.SelectedItem = null;
            cbx_category.SelectedItem = null;
            txb_title.Clear();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (dgr.SelectedItem != null)
            {
                MessageBoxResult ress = MessageBox.Show("Do you want to edit the row?", "Are you sure?",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ress == MessageBoxResult.Yes)
                {
                    optbazaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Row was edited", "Sucsses!", MessageBoxButton.OK);
                }
                else
                {
                    dgr.SelectedItem = null;
                }
            }
            else
            {
                if (txb_title1.Text != ""
                    && txb_kolvo.Text != ""
                    && txb_price.Text != ""
                    && cbx_cat.SelectedItem != null
                    && cbx_pos.SelectedItem != null)
                    {
                        tovar tov = new tovar()
                        {
                            title = txb_title1.Text.ToString(),
                            kolvo = Convert.ToInt32(txb_kolvo.Text),
                            price = Convert.ToInt32(txb_price.Text),
                            idcategory = cbx_cat.SelectedIndex + 1,
                            idpostavshik = cbx_pos.SelectedIndex + 1
                        };
                        optbazaEntities.GetContext().tovar.Add(tov);
                        optbazaEntities.GetContext().SaveChanges();
                        MessageBox.Show("The letter was added", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                        MessageBox.Show("Rows can't be empty", "Exeption", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            dgr.ItemsSource = optbazaEntities.GetContext().tovar.ToList();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            tovar tov = dgr.SelectedItem as tovar;
            try
            {
                if (dgr.SelectedItems.Count > 0)
                {
                    MessageBoxResult res = MessageBox.Show($"Do you want to delete these {dgr.SelectedItems.Count} rows?",
                        "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        optbazaEntities.GetContext().tovar.Remove(tov);
                        optbazaEntities.GetContext().SaveChanges();
                        MessageBox.Show("Rows were deleted", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    if (res == MessageBoxResult.No)
                        return;
                }
                else
                    MessageBox.Show("Choose smth", "Exeption", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dgr.ItemsSource = optbazaEntities.GetContext().tovar.ToList();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            dgr.SelectedItem = null;
            stp_tov.IsEnabled = true;
        }

        private void dgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stp_tov.IsEnabled = false;
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            stp_tov.IsEnabled = true;
        }
    }
}
