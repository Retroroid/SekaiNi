using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for EstEdit.xaml
    /// </summary>
    public partial class EstEdit : Window, INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public Est ViewItem {
            get { return _ViewItem; }
            set {
                if (value != _ViewItem) {
                    _ViewItem = value;
                    OnPropertyChanged("ViewItem");
                }
            }
        }
        private Est _ViewItem;

        // ---------------- Constructors ---------------- ---------------- //
        public EstEdit() {
            ViewItem = new Est();
            InitializeComponent();
            DataContext = this;
        }
        public EstEdit(Est ViewItem) {
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
                new EstEdit(ViewItem.DeserializeFile()).Show();
            }
        }

        #region Context Menu Base
        private void MenuItemEdit_Click(object sender, RoutedEventArgs e) {

        }
        private void MenuItemAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Notes.Count < 1 || dg.SelectedIndex >= ViewItem.Notes.Count) ViewItem.Notes.Add(new Note());
            else ViewItem.Notes.Add((dg.SelectedItem as Note).CloneObject());
            ListNotes.Items.Refresh();
        }
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Notes.Count) ViewItem.Notes.RemoveAt(dg.SelectedIndex);
            ListNotes.Items.Refresh();
        }
        #endregion

        #region Context Menu Staff
        private void MenuStaffEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex >= 0 && dg.SelectedIndex < ViewItem.Staff.Count) new ChaEdit(dg.SelectedItem as Cha).Show();
        }
        private void MenuStaffAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < 0 || dg.SelectedIndex >= ViewItem.Staff.Count) ViewItem.Staff.Add(new Cha());
            else ViewItem.Staff.Add((dg.SelectedItem as Cha).CloneObject());
            ListStaff.Items.Refresh();
        }
        private void MenuStaffDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex >= 0 && dg.SelectedIndex < ViewItem.Staff.Count) ViewItem.Staff.RemoveAt(dg.SelectedIndex);
            ListStaff.Items.Refresh();
        }
        #endregion
        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace

