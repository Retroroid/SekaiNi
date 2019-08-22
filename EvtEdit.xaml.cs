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
    /// Interaction logic for EvtEdit.xaml
    /// </summary>
    public partial class EvtEdit : Window, INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public Evt ViewItem {
            get { return _ViewItem; }
            set {
                if (value != _ViewItem) {
                    _ViewItem = value;
                    OnPropertyChanged("ViewItem");
                }
            }
        }
        private Evt _ViewItem;

        // ---------------- Constructors ---------------- ---------------- //
        public EvtEdit() {
            ViewItem = new Evt();
            InitializeComponent();
            DataContext = this;
        }
        public EvtEdit(Evt ViewItem) {
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
                new EvtEdit(ViewItem.DeserializeFile()).Show();
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

        #region Context Menu SubEvents
        private void MenuSubEventsEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Characters.Count) new EvtEdit(dg.SelectedItem as Evt).Show();
        }
        private void MenuSubEventsAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.SubEvents.Count < 1 || dg.SelectedIndex >= ViewItem.SubEvents.Count) ViewItem.SubEvents.Add(new Evt());
            else ViewItem.SubEvents.Add((dg.SelectedItem as Evt).CloneObject());
            ListSubEvents.Items.Refresh();
        }
        private void MenuSubEventsDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.SubEvents.Count) ViewItem.SubEvents.RemoveAt(dg.SelectedIndex);
            ListSubEvents.Items.Refresh();
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

        #region Context Menu RandomEvents
        private void MenuRandomEventsEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.RandomEvents.Count) new ChaEdit(dg.SelectedItem as Cha).Show();
        }
        private void MenuRandomEventsAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.RandomEvents.Count < 1 || dg.SelectedIndex >= ViewItem.RandomEvents.Count) ViewItem.RandomEvents.Add(new Doh());
            else ViewItem.RandomEvents.Add((dg.SelectedItem as Doh).CloneObject());
            ListRandomEvents.Items.Refresh();
        }
        private void MenuRandomEventsDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.RandomEvents.Count) ViewItem.RandomEvents.RemoveAt(dg.SelectedIndex);
            ListRandomEvents.Items.Refresh();
        }
        #endregion

        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
