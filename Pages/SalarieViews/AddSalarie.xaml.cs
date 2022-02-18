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

namespace Annuaire.Pages.SalarieViews
{
    /// <summary>
    /// Logique d'interaction pour AddSalarie.xaml
    /// </summary>
    public partial class AddSalarie : Window
    {
        public AddSalarie()
        {
            InitializeComponent();
            Sites site = new();
            Services service = new();
            siteChoice.DataContext = site;
            siteChoice.ItemsSource = site.GetAll();
            serviceChoice.DataContext = service;    
            serviceChoice.ItemsSource = service.GetAll();
        }

        private void btn_Valider_Click(object sender, RoutedEventArgs e)
        {
            Salaries salaries = new();
            salaries.Nom = Iname.Text;
            salaries.Prenom = Iprenom.Text;
            salaries.TelPortable = int.Parse(ItelPort.Text);
            salaries.TelFixe = int.Parse(ItelFixe.Text);
            salaries.Services = (Services)serviceChoice.SelectedItem;
            salaries.Site = (Sites)siteChoice.SelectedItem;
            try
            {
                var result = salaries.Create();
                if (result == true)
                {
                    var win = new AdminPanel();
                    Close();
                    win.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Annuler_Click(object sender, RoutedEventArgs e)
        {
            var win = new AdminPanel();
            Close();
            win.Show();
        }
    }
}
