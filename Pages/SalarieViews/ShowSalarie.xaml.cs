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
    /// Logique d'interaction pour ShowSalarie.xaml
    /// </summary>
    public partial class ShowSalarie : Window
    {
        public ShowSalarie(Salaries salaries)
        {
            InitializeComponent();
        }
    }
}
