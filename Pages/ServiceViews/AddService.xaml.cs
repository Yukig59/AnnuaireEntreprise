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
    /// Logique d'interaction pour AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        public AddService()
        {
            InitializeComponent();
        }

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            Services service = new();
            service.Name = serviceInput.Text;
            try
            {
                var result = service.Create();
                if(result == true)
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
