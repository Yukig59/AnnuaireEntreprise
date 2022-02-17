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
            sitesList.DataContext = site;
            sitesList.ItemsSource = site.GetAll();
        }

        private void btw_new_site(object sender, RoutedEventArgs e)
        {
            var win = new SiteViews.AddSite();
            Hide();
            win.Show(); 
        }

        private void btw_edit_site(object sender, RoutedEventArgs e)
        {
            Sites site = (Sites)sitesList.SelectedItem;
            var win = new SiteViews.EditSite(site);
            this.Hide();
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
                    this.Hide();
                    win.Show();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
