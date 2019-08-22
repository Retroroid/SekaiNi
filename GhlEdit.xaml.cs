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
    /// Interaction logic for GhlEdit.xaml
    /// </summary>
    public partial class GhlEdit : Window, INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public Ghl ViewItem {
            get { return _ViewItem; }
            set {
                if (value != _ViewItem) {
                    _ViewItem = value;
                    OnPropertyChanged("ViewItem");
                }
            }
        }
        private Ghl _ViewItem;

        // ---------------- Constructors ---------------- ---------------- //
        public GhlEdit() {
            ViewItem = new Ghl();
            InitializeComponent();
            DataContext = this;
        }
        public GhlEdit(Ghl ViewItem) {
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
                new GhlEdit(ViewItem.DeserializeFile()).Show();
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

        #region Context Menu CommonRoom
        private void MenuCommonRoomEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.CommonRoom.Count) new ChaEdit(dg.SelectedItem as Cha).Show();
        }
        private void MenuCommonRoomAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.CommonRoom.Count < 1 || dg.SelectedIndex >= ViewItem.CommonRoom.Count) ViewItem.CommonRoom.Add(new Cha());
            else ViewItem.CommonRoom.Add((dg.SelectedItem as Cha).CloneObject());
            ListCommonRoom.Items.Refresh();
        }
        private void MenuCommonRoomDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.CommonRoom.Count) ViewItem.CommonRoom.RemoveAt(dg.SelectedIndex);
            ListCommonRoom.Items.Refresh();
        }
        #endregion

        #region Context Menu Questboard
        private void MenuQuestboardEdit_Click(object sender, RoutedEventArgs e) {
            //DataGrid dg = ((sender as MenuItem)
            //    .Parent as ContextMenu)
            //    .PlacementTarget as DataGrid;
            //if (dg.SelectedIndex < ViewItem.Questboard.Count) new ChaEdit(dg.SelectedItem as Cha).Show();
        }
        private void MenuQuestboardAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (ViewItem.Questboard.Count < 1 || dg.SelectedIndex >= ViewItem.Questboard.Count) ViewItem.Questboard.Add(new Quest());
            else ViewItem.Questboard.Add((dg.SelectedItem as Quest).CloneObject());
            ListQuestboard.Items.Refresh();
        }
        private void MenuQuestboardDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Questboard.Count) ViewItem.Questboard.RemoveAt(dg.SelectedIndex);
            ListQuestboard.Items.Refresh();
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

        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace

