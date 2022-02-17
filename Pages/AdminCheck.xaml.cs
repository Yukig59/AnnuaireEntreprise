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
    /// Logique d'interaction pour AdminCheck.xaml
    /// </summary>
    public partial class AdminCheck : Window
    {
        private string password = "123456";
        public AdminCheck()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(passwordAdmin.Password == password)
            {
                var win = new AdminPanel();
                Hide();
                win.Show();
            }
            else
            {
                passwordAdmin.Clear();
                MessageBox.Show("Le mot de passe est incorrect");

            }
        }
    }
}
