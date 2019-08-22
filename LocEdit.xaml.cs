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
    /// Interaction logic for LocEdit.xaml
    /// </summary>
    public partial class LocEdit : Window, INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public Loc ViewItem {
            get { return _ViewItem; }
            set {
                if (value != _ViewItem) {
                    _ViewItem = value;
                    OnPropertyChanged("ViewItem");
                }
            }
        }
        private Loc _ViewItem;

        // ---------------- Constructors ---------------- ---------------- //
        public LocEdit() {
            ViewItem = new Loc();
            InitializeComponent();
            DataContext = this;
        }
        public LocEdit(Loc ViewItem) {
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
                new LocEdit(ViewItem.DeserializeFile()).Show();
            }
        }
        #region Context Menu Base
        private void MenuItemEdit_Click(object sender, RoutedEventArgs e) {
            //DataGrid dg = ((sender as MenuItem)
            //    .Parent as ContextMenu)
            //    .PlacementTarget as DataGrid;
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

        #region Context Menu Locations
        private void MenuLocationsEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Locations.Count) new LocEdit(dg.SelectedItem as Loc).Show();
        }
        private void MenuLocationsAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Locations.Count < 1 || dg.SelectedIndex >= ViewItem.Locations.Count) ViewItem.Locations.Add(new Loc());
            else ViewItem.Locations.Add((dg.SelectedItem as Loc).CloneObject());
            ListLocations.Items.Refresh();
        }
        private void MenuLocationsDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Locations.Count) ViewItem.Locations.RemoveAt(dg.SelectedIndex);
            ListLocations.Items.Refresh();
        }
        #endregion

        #region Context Menu Establishments
        private void MenuEstablishmentsEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Establishments.Count)new EstEdit(dg.SelectedItem as Est).Show();
        }
        private void MenuEstablishmentsAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Establishments.Count < 1 || dg.SelectedIndex >= ViewItem.Establishments.Count) ViewItem.Establishments.Add(new Est());
            else ViewItem.Establishments.Add((dg.SelectedItem as Est).CloneObject());
            ListEstablishments.Items.Refresh();
        }
        private void MenuEstablishmentsDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Establishments.Count) ViewItem.Establishments.RemoveAt(dg.SelectedIndex);
            ListEstablishments.Items.Refresh();
        }
        #endregion

        #region Context Menu Characters
        private void MenuCharactersEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Characters.Count) new ChaEdit(dg.SelectedItem as Cha).Show();
        }
        private void MenuCharactersAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Characters.Count < 1 || dg.SelectedIndex >= ViewItem.Characters.Count) ViewItem.Characters.Add(new Cha());
            else ViewItem.Characters.Add((dg.SelectedItem as Cha).CloneObject());
            ListCharacters.Items.Refresh();
        }
        private void MenuCharactersDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Characters.Count) ViewItem.Characters.RemoveAt(dg.SelectedIndex);
            ListCharacters.Items.Refresh();
        }
        #endregion

        #region Context Menu Events
        private void MenuEventsEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Events.Count) new EvtEdit(dg.SelectedItem as Evt).Show();
        }
        private void MenuEventsAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Events.Count < 1 || dg.SelectedIndex >= ViewItem.Events.Count) ViewItem.Events.Add(new Evt());
            else ViewItem.Events.Add((dg.SelectedItem as Evt).CloneObject());
            ListEvents.Items.Refresh();
        }
        private void MenuEventsDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Events.Count) ViewItem.Events.RemoveAt(dg.SelectedIndex);
            ListEvents.Items.Refresh();
        }
        #endregion

        #region Context Menu Imports
        private void MenuImportsEdit_Click(object sender, RoutedEventArgs e) {
            //DataGrid dg = ((sender as MenuItem)
            //    .Parent as ContextMenu)
            //    .PlacementTarget as DataGrid;
        }
        private void MenuImportsAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Imports.Count < 1 || dg.SelectedIndex >= ViewItem.Imports.Count) ViewItem.Imports.Add(new Dot());
            else ViewItem.Imports.Add((dg.SelectedItem as Dot).CloneObject());
            ListImports.Items.Refresh();
        }
        private void MenuImportsDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Imports.Count) ViewItem.Imports.RemoveAt(dg.SelectedIndex);
            ListImports.Items.Refresh();
        }
        #endregion

        #region Context Menu Exports
        private void MenuExportsEdit_Click(object sender, RoutedEventArgs e) {
            //DataGrid dg = ((sender as MenuItem)
            //    .Parent as ContextMenu)
            //    .PlacementTarget as DataGrid;
        }
        private void MenuExportsAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Exports.Count < 1 || dg.SelectedIndex >= ViewItem.Exports.Count) ViewItem.Exports.Add(new Dot());
            else ViewItem.Exports.Add((dg.SelectedItem as Dot).CloneObject());
            ListExports.Items.Refresh();
        }
        private void MenuExportsDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Exports.Count) ViewItem.Exports.RemoveAt(dg.SelectedIndex);
            ListExports.Items.Refresh();
        }
        #endregion

        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
