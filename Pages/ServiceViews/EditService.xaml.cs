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

namespace Annuaire.Pages.ServiceViews
{
    /// <summary>
    /// Logique d'interaction pour EditService.xaml
    /// </summary>
    public partial class EditService : Window
    {
        public EditService(Services service)
        {
            InitializeComponent();
            ServiceInput.Text = service.Name;
            IdHidden.Text = service.Id.ToString();
            IdHidden.Visibility = Visibility.Hidden;

        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            Services service = new();
            service.Name = ServiceInput.Text;
            service.Id = int.Parse(IdHidden.Text);
            try
            {
                var result = service.Update();
                if(result == true)
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

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            var win = new AdminPanel();
            Close();
            win.Show();
        }
    }
}
