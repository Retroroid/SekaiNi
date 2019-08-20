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
            Sekai.Database.InitializeDatabase();
        }
        private void d100Edit_Open(object sender, RoutedEventArgs e) {
            new DohEdit().Show();
        }
        private void Editor_Open(object sender, RoutedEventArgs e) {
            new Templater().Show();
        }
    }
}
