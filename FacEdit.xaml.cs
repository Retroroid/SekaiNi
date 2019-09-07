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
    /// Interaction logic for FacEdit.xaml
    /// </summary>
    public partial class FacEdit : Window, INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public Fac ViewItem {
            get { return _ViewItem; }
            set {
                if (value != _ViewItem) {
                    _ViewItem = value;
                    OnPropertyChanged("ViewItem");
                }
            }
        }
        private Fac _ViewItem;

        // ---------------- Constructors ---------------- ---------------- //
        public FacEdit() {
            ViewItem = new Fac();
            InitializeComponent();
            DataContext = this;
        }
        public FacEdit(Fac ViewItem) {
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
                new FacEdit(ViewItem.DeserializeFile()).Show();
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

        #region Context Menu Authority
        private void MenuAuthorityEdit_Click(object sender, RoutedEventArgs e) {
            //DataGrid dg = ((sender as MenuItem)
            //    .Parent as ContextMenu)
            //    .PlacementTarget as DataGrid;
        }
        private void MenuAuthorityAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < 0 || dg.SelectedIndex >= ViewItem.Authority.Count) ViewItem.Authority.Add(new Cha());
            else ViewItem.Authority.Add((dg.SelectedItem as Cha).CloneObject());
            ListAuthority.Items.Refresh();
        }
        private void MenuAuthorityDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex >=0 && dg.SelectedIndex < ViewItem.Authority.Count) ViewItem.Authority.RemoveAt(dg.SelectedIndex);
            ListAuthority.Items.Refresh();
        }
        #endregion

        #region Context Menu Locations
        private void MenuLocationsEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex >= 0 && dg.SelectedIndex < ViewItem.Locations.Count) new LocEdit(dg.SelectedItem as Loc).Show();
        }
        private void MenuLocationsAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < 0 || dg.SelectedIndex >= ViewItem.Locations.Count) ViewItem.Locations.Add(new Loc());
            else ViewItem.Locations.Add((dg.SelectedItem as Loc).CloneObject());
            ListLocations.Items.Refresh();
        }
        private void MenuLocationsDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex >= 0 && dg.SelectedIndex < ViewItem.Locations.Count) ViewItem.Locations.RemoveAt(dg.SelectedIndex);
            ListLocations.Items.Refresh();
        }
        #endregion

        #region Context Menu Members
        private void MenuMembersEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Members.Count) new ChaEdit(dg.SelectedItem as Cha).Show();
        }
        private void MenuMembersAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Members.Count < 1 || dg.SelectedIndex >= ViewItem.Members.Count) ViewItem.Members.Add(new Cha());
            else ViewItem.Members.Add((dg.SelectedItem as Cha).CloneObject());
            ListMembers.Items.Refresh();
        }
        private void MenuMembersDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Members.Count) ViewItem.Members.RemoveAt(dg.SelectedIndex);
            ListMembers.Items.Refresh();
        }
        #endregion

        #region Context Menu Groups
        private void MenuGroupsEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Groups.Count) new FacEdit(dg.SelectedItem as Fac).Show();
        }
        private void MenuGroupsAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Groups.Count < 1 || dg.SelectedIndex >= ViewItem.Groups.Count) ViewItem.Groups.Add(new Fac());
            else ViewItem.Groups.Add((dg.SelectedItem as Fac).CloneObject());
            ListGroups.Items.Refresh();
        }
        private void MenuGroupsDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Groups.Count) ViewItem.Groups.RemoveAt(dg.SelectedIndex);
            ListGroups.Items.Refresh();
        }
        #endregion

        #region Context Menu Ranks
        private void MenuRanksEdit_Click(object sender, RoutedEventArgs e) {
            //DataGrid dg = ((sender as MenuItem)
            //    .Parent as ContextMenu)
            //    .PlacementTarget as DataGrid;
        }
        private void MenuRanksAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Ranks.Count < 1 || dg.SelectedIndex >= ViewItem.Ranks.Count) ViewItem.Ranks.Add(new Accolade());
            else ViewItem.Ranks.Add((dg.SelectedItem as Accolade).CloneObject());
            ListRanks.Items.Refresh();
        }
        private void MenuRanksDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Ranks.Count) ViewItem.Ranks.RemoveAt(dg.SelectedIndex);
            ListRanks.Items.Refresh();
        }
        #endregion

        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
