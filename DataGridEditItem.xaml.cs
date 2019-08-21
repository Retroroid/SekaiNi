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
    /// Interaction logic for DataGridEditItem.xaml
    /// </summary>
    public partial class DataGridEditItem : Window {
        public DataGridCellInfo dgc;
        public DataGridEditItem(DataGridCellInfo dgc) {
            this.dgc = dgc;
            InitializeComponent();
        }
        public void DGEI_SaveChanges(object sender, RoutedEventArgs e) {

        }
    }
}
