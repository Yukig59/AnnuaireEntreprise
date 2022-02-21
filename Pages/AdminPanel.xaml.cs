using Annuaire.Models;
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

namespace Annuaire.Pages
{
    /// <summary>
    /// Logique d'interaction pour AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
            Sites site = new();
            Services services = new();
            Salaries salaries = new();
            sitesList.DataContext = site;
            sitesList.ItemsSource = site.GetAll();
            servicesList.DataContext = services;
            servicesList.ItemsSource = services.GetAll();
            salarieList.DataContext = salaries;
            salarieList.ItemsSource = salaries.GetAll();

        }

        private void btw_new_site(object sender, RoutedEventArgs e)
        {
            var win = new SiteViews.AddSite();
            Close();
            win.Show(); 
        }

        private void btw_edit_site(object sender, RoutedEventArgs e)
        {
            Sites site = (Sites)sitesList.SelectedItem;
            var win = new SiteViews.EditSite(site);
            this.Close();
            win.Show();
        }

        private void btw_del_site(object sender, RoutedEventArgs e)
        {
            Sites site = (Sites)sitesList.SelectedItem;
            try
            {
              var result = site.Delete();
                if(result == true)
                {
                    var win = new AdminPanel();
                    this.Close();
                    win.Show();
                }
                else
                {

                    MessageBox.Show("Il y a un ou plusieurs salariés dans cette ville, supprimez les puis réessayez.");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btw_new_service(object sender, RoutedEventArgs e)
        {
            var win = new ServiceViews.AddService();
            Close();
            win.Show();

        }

        private void btw_edit_service(object sender, RoutedEventArgs e)
        {
            Services services = (Services)servicesList.SelectedItem;
            var win = new ServiceViews.EditService(services);
            Close();
            win.Show();

        }

        private void btw_del_service(object sender, RoutedEventArgs e)
        {
            Services service = (Services)servicesList.SelectedItem;
            try
            {
                var result = service.Delete();
                if(result == true)
                {
                    var win = new AdminPanel();
                    this.Close();
                    win.Show();

                }
                else
                {

                    MessageBox.Show("Il y a un ou plusieurs salariés dans ce service, supprimez les puis réessayez.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btw_new_salarie(object sender, RoutedEventArgs e)
        {
            var win = new SalarieViews.AddSalarie();
            Close();
            win.Show();
        }

        private void btw_edit_salarie(object sender, RoutedEventArgs e)
        {
            var win = new SalarieViews.EditSalarie((Salaries)salarieList.SelectedItem);
            Close();
            win.Show();
        }

        private void btw_del_salarie(object sender, RoutedEventArgs e)
        {
            Salaries salarie = (Salaries)servicesList.SelectedItem;
            try
            {
                var result = salarie.Delete();
                if (result == true)
                {
                    var win = new AdminPanel();
                    this.Close();
                    win.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            Salaries salarie = (Salaries)salarieList.SelectedItem;
            var win = new SalarieViews.ShowSalarie(salarie);
            win.ShowDialog();
        }

      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow();
            Close();
            win.Show();
        }
    }
}
