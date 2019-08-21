using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Templater.xaml
    /// </summary>
    public partial class Templater : INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public Dot ViewItem {
            get { return _ViewItem; }
            set {
                if (value != _ViewItem) {
                    _ViewItem = value;
                    OnPropertyChanged("ViewItem");
                }
            }
        }
        private Dot _ViewItem;

        // ---------------- Constructors ---------------- ---------------- //
        public Templater() {
            ViewItem = new Dot();
            InitializeComponent();
            DataContext = this;
        }
        public Templater(Dot ViewItem) {
            this.ViewItem = ViewItem;
            InitializeComponent();
            DataContext = this;
        }
        // ---------------- Methods ---------------- ---------------- //
        private void MenuItemSave_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = $"{Database.DPath}\\{ViewItem.ClassType}";
            sfd.FileName = $"{Database.DPath}\\{ViewItem.ClassType}\\{ViewItem.ID}.bin";
            sfd.OverwritePrompt = true;
            if (sfd.ShowDialog() == true) {
                ViewItem.ID = Regex.Match(sfd.SafeFileName, @"(.*)\.").Value.TrimEnd('.');
                ViewItem.SerializeToFile();
            }
        }
        private void MenuItemLoad_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = $"{Database.DPath}\\{ViewItem.ClassType}";
            if (ofd.ShowDialog() == true) {
                string[] FilePath = ofd.FileName.Split('\\');
                string st = Regex.Match(FilePath[FilePath.Length - 1], @"(.*)\.").Value.TrimEnd('.');
                ViewItem.ID = st;
                new Templater(ViewItem.DeserializeFileByID()).Show();
            }
        }

        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
