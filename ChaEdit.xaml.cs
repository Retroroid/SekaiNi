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
    /// Interaction logic for ChaEdit.xaml
    /// </summary>
    public partial class ChaEdit : Window, INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public Cha ViewItem {
            get { return _ViewItem; }
            set {
                if (value != _ViewItem) {
                    _ViewItem = value;
                    OnPropertyChanged("ViewItem");
                }
            }
        }
        private Cha _ViewItem;

        // ---------------- Constructors ---------------- ---------------- //
        public ChaEdit() {
            ViewItem = new Cha();
            InitializeComponent();
            DataContext = this;
            ListInventory.Columns[0].IsReadOnly = true;
        }
        public ChaEdit(Cha ViewItem) {
            this.ViewItem = ViewItem;
            InitializeComponent();
            DataContext = this;
            ListInventory.Columns[0].IsReadOnly = true;
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

                //TODO saveable lists
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
                new ChaEdit(ViewItem.DeserializeFile()).Show();

                //TODO saveable lists
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
            if(ViewItem.Notes.Count  < 1 || dg.SelectedIndex < 0) return;
            ViewItem.Notes.RemoveAt(dg.SelectedIndex);
            ListNotes.Items.Refresh();
        }
        #endregion

        #region Context Menu Inventory
        private void MenuItmEdit_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < ViewItem.Inventory.Count && dg.SelectedIndex >= 0) {
                new ItmEdit(dg.SelectedItem as Itm).Show();
            }
        }
        private void MenuItmAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < 0 || dg.SelectedIndex >= ViewItem.Inventory.Count) ViewItem.Inventory.Add(new Itm());
            else ViewItem.Inventory.Add((dg.SelectedItem as Itm).CloneObject());
            ListInventory.Items.Refresh();

        }
        private void MenuItmDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if(dg.SelectedIndex >= 0 && dg.SelectedIndex < ViewItem.Inventory.Count) ViewItem.Inventory.RemoveAt(dg.SelectedIndex);
            ListInventory.Items.Refresh();
        }
        #endregion

        #region Context Menu Ability
        private void MenuAbilityEdit_Click(object sender, RoutedEventArgs e) {
            //TODO
        }
        private void MenuAbilityAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < 0 || dg.SelectedIndex >= ViewItem.Abilities.Count) ViewItem.Abilities.Add(new Ability());
            else ViewItem.Abilities.Add((dg.SelectedItem as Ability).CloneObject());
            ListAbilities.Items.Refresh();

        }
        private void MenuAbilityDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if(dg.SelectedIndex < ViewItem.Abilities.Count && dg.SelectedIndex >= 0) {
                ViewItem.Abilities.RemoveAt(dg.SelectedIndex);
                ListAbilities.Items.Refresh();
                }
        }
        #endregion

        #region Context Menu Attack
        private void MenuAttackEdit_Click(object sender, RoutedEventArgs e) {
            //TODO
        }
        private void MenuAttackAdd_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex < 0 || dg.SelectedIndex >= ViewItem.Attacks.Count) ViewItem.Attacks.Add(new Ability());
            else ViewItem.Attacks.Add((dg.SelectedItem as Ability).CloneObject());
            ListAttacks.Items.Refresh();

        }
        private void MenuAttackDelete_Click(object sender, RoutedEventArgs e) {
            DataGrid dg = ((sender as MenuItem)
                .Parent as ContextMenu)
                .PlacementTarget as DataGrid;
            if (dg.SelectedIndex >= 0 && dg.SelectedIndex < ViewItem.Attacks.Count) ViewItem.Attacks.RemoveAt(dg.SelectedIndex);
            ListAttacks.Items.Refresh();
        }
        #endregion
        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace