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
using Annuaire.Models;

namespace Annuaire.Pages.SiteViews
{
    /// <summary>
    /// Logique d'interaction pour AddSite.xaml
    /// </summary>
    public partial class AddSite : Window
    {
        public AddSite()
        {
            InitializeComponent();
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            Sites site = new();
            site.Ville = VilleInput.Text;
            try
            {
                var result = site.Create();
                if (result == true)
                {
                    var win = new AdminPanel();
                    Close();
                    win.Show();
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            var win = new AdminPanel();
            Close();
            win.Show();
        }
    }
}
