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
            var _service = new Services();
            var _site = new Sites();
            servicechoice.DataContext = _service;
            servicechoice.ItemsSource = _service.GetAll();
            sitechoice.DataContext = _site;
            sitechoice.ItemsSource = _site.GetAll();
            cmd.InputGestures.Add(new KeyGesture(Key.F4, ModifierKeys.Control));
            Salaries salarie = new();
            salariesList.DataContext = salarie;
            salariesList.ItemsSource = salarie.GetAll();
        }
        private void AdminPanel(object sender, ExecutedRoutedEventArgs e)
        {
            var win = new AdminCheck();
           
            Close();
            win.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var returnList = new List<Salaries>();
            var service = servicechoice.SelectedItem as Services;
            var site = sitechoice.SelectedItem as Sites;
            var salarie = new Salaries();
            var list = salarie.GetAll();
            foreach (var item in list)
            {
                if (item.ServicesId == service.Id && item.SiteId == site.Id)
                {
                    if (item.Nom.Contains(searchInput.Text) || item.Prenom.Contains(searchInput.Text))
                    {
                        returnList.Add(item);
                    }
                } 
            }
            salariesList.DataContext = salarie;
            salariesList.ItemsSource = returnList;
        }
        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            Salaries salarie = (Salaries)salariesList.SelectedItem;
            var win = new Pages.SalarieViews.ShowSalarie(salarie);
            win.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow();
            this.Close();
            win.Show();
        }
    }
}
