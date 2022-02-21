using Annuaire.Models;
using System;
using System.Windows;

namespace Annuaire.Pages.SalarieViews
{
    /// <summary>
    /// Logique d'interaction pour EditSalarie.xaml
    /// </summary>
    public partial class EditSalarie : Window
    {
        public EditSalarie(Salaries salarie)
        {
            InitializeComponent();
            Sites site = new();
            Services service = new();
            siteChoice.DataContext = site;
            siteChoice.ItemsSource = site.GetAll();
            serviceChoice.DataContext = service;
            serviceChoice.ItemsSource = service.GetAll();
            Iname.Text = salarie.Nom;
            Iprenom.Text = salarie.Prenom;
            ItelFixe.Text = salarie.TelFixe.ToString();
            ItelPort.Text = salarie.TelPortable.ToString();
            Iemail.Text = salarie.Email;
            siteChoice.SelectedValue = salarie.Site.Id;
            serviceChoice.SelectedValue = salarie.Services.Id;
            idHidden.Text = salarie.Id.ToString();
            idHidden.Visibility = Visibility.Hidden;
            salarie.Id = -1;
        }

        private void btn_Valider_Click(object sender, RoutedEventArgs e)
        {
            Salaries salaries = new();

            salaries.Id = int.Parse(idHidden.Text);
            salaries.Nom = Iname.Text;
            salaries.Prenom = Iprenom.Text;
            salaries.Email = Iemail.Text;
            salaries.TelPortable = int.Parse(ItelPort.Text);
            salaries.TelFixe = int.Parse(ItelFixe.Text);
            salaries.Services = (Services)serviceChoice.SelectedItem;
            salaries.Site = (Sites)siteChoice.SelectedItem;
            salaries.ServicesId = salaries.Services.Id;
            salaries.SiteId = salaries.Site.Id;
            try
            {
                var result = salaries.Update();
                if(result == true)
                {
                    var win = new AdminPanel();
                    Close();
                    win.Show();
                }
            }catch (Exception ex)
            {
                throw;    
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
