using Annuaire.Models;
using Annuaire.Pages;
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

namespace Annuaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand cmd = new();
        public MainWindow()
        {
            InitializeComponent();
            cmd.InputGestures.Add(new KeyGesture(Key.F4, ModifierKeys.Control));
            Salaries salarie = new();
            salariesList.DataContext = salarie;
            salariesList.ItemsSource = salarie.GetAll();
        }
        private void AdminPanel(object sender, ExecutedRoutedEventArgs e)
        {
            var win = new AdminCheck();
           
            Hide();
            win.ShowDialog();
        }

    }
}
