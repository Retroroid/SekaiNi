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

namespace SekaiNi {
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window {
        public MainMenu() {
            InitializeComponent();
            Database.InitializeDatabase();
        }
        private void ChaEdit_Open(object sender, RoutedEventArgs e) {
            new ChaEdit().Show();
        }
        private void D100Edit_Open(object sender, RoutedEventArgs e) {
            new DohEdit().Show();
        }
        private void EstEdit_Open(object sender, RoutedEventArgs e) {
            new EstEdit().Show();
        }
        private void EvtEdit_Open(object sender, RoutedEventArgs e) {
            new EvtEdit().Show();
        }
        private void FacEdit_Open(object sender, RoutedEventArgs e) {
            new FacEdit().Show();
        }
        private void GhlEdit_Open(object sender, RoutedEventArgs e) {
            new GhlEdit().Show();
        }
        private void ItmEdit_Open(object sender, RoutedEventArgs e) {
            new ItmEdit().Show();
        }
        private void LocEdit_Open(object sender, RoutedEventArgs e) {
            new LocEdit().Show();
        }
        private void MdlEdit_Open(object sender, RoutedEventArgs e) {
            new MdlEdit().Show();
        }
    }
}
