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

            ViewItem.Notes.Add(new Note { Title = "Note 1 Name!", Time = "Note 1 Time!", Tag = "Note 1 Tag!", Text = "Note 1 Text!" });
            ViewItem.Notes.Add(new Note { Title = "Note 2 Name!", Time = "Note 2 Time!", Tag = "Note 2 Tag!", Text = "Note 2 Text!" });
            ViewItem.Notes.Add(new Note { Title = "Note 3 Name!", Time = "Note 3 Time!", Tag = "Note 3 Tag!", Text = "Note 3 Text!" });
            ViewItem.Notes.Add(new Note { Title = "Note 4 Name!", Time = "Note 4 Time!", Tag = "Note 4 Tag!", Text = "Note 4 Text!" });
        }
        public Templater(Dot ViewItem) {
            this.ViewItem = ViewItem;
            InitializeComponent();
            DataContext = this;
        }
        // ---------------- Methods ---------------- ---------------- //
        private void MenuItemSave_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog {
                InitialDirectory = $"{Database.DPath}\\{ViewItem.ClassType}",
                FileName = $"{ViewItem.Name}",
                OverwritePrompt = true
            };
            if (sfd.ShowDialog() == true) {
                string[] FilePath = sfd.FileName.Split('\\');
                string str = FilePath[FilePath.Length - 1];
                if (str.Contains(".bin")) {
                    str.Replace(".bin", string.Empty);
                    str = str.Substring(3);
                }
                ViewItem.Name = str;
                ViewItem.SerializeToFile();
            }
        }
        private void MenuItemLoad_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog {
                InitialDirectory = $"{Database.DPath}\\{ViewItem.ClassType}"
            };
            if (ofd.ShowDialog() == true) {
                string[] FilePath = ofd.FileName.Split('\\');
                string str = FilePath[FilePath.Length - 1];
                if (str.Contains(".bin")) {
                    str.Replace(".bin", string.Empty);
                    str = str.Substring(3);
                }
                ViewItem.Name = str;
                new Templater(ViewItem.DeserializeFile()).Show();
            }
        }
        #region Context Menu Base
        private void MenuItemEdit_Click(object sender, RoutedEventArgs e) {

        }
        private void MenuItemAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            ViewItem.Notes.Add((dg.SelectedItem as Note).CloneObject());
            ListNotes.Items.Refresh();
        }
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            ViewItem.Notes.RemoveAt(dg.SelectedIndex);
            ListNotes.Items.Refresh();
        }
        #endregion
        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
