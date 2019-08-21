
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System;
using System.IO;
using Microsoft.Win32;

namespace SekaiNi {
    /// <summary>
    /// Interaction logic for DohEdit.xaml
    /// </summary>
    public partial class DohEdit : INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //
        #region Property Changed Event
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public Doh ViewItem {
            get { return _ViewItem; }
            set {
                if (value != _ViewItem) {
                    _ViewItem = value;
                    OnPropertyChanged("ViewItem");
                }
            }
        }
        private Doh _ViewItem;
        public Element ViewElement {
            get { return _ViewElement; }
            set {
                if (value != _ViewElement) {
                    _ViewElement = value;
                    OnPropertyChanged("ViewElement");
                }
            }
        }
        private Element _ViewElement;

        // ---------------- Constructors ---------------- ---------------- //
        public DohEdit() {
            ViewItem = new Doh();
            InitializeComponent();
            DataContext = this;

            AddSomeData();
        }
        public DohEdit(Doh DoneHundo) {
            ViewItem = DoneHundo;
            InitializeComponent();
            DataContext = this;
        }
        public void AddSomeData() {
            ViewItem.Elements.Add(new Element { Tag = "Bad", Weight = 10, Value = "PC explodes" });
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
                    str = str.Replace(".bin", string.Empty);
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
                    str = str.Replace(".bin", string.Empty);
                    str = str.Substring(3);
                }
                Doh newDoh = new Doh { Name = str };
                new DohEdit(newDoh.DeserializeFile()).Show();
            }
        }

        private void ButnAdd_Click(object sender, RoutedEventArgs e) {
            ViewItem.Elements.Add(new Element(ViewElement));
            ListRolls.Items.Refresh();
        }
        private void ButnRoll_Click(object sender, RoutedEventArgs e) {
            ViewElement = ViewItem.RollOnList();
        }
        private void ButnDelete_Click(object sender, RoutedEventArgs e) {
            if (ListRolls.SelectedIndex >= ViewItem.Elements.Count)
                throw new System.Exception("Selected index exceeds Element list");
            ViewItem.Elements.RemoveAt(ListRolls.SelectedIndex);
            ListRolls.Items.Refresh();
        }
        private void ButnImport_Click(object sender, RoutedEventArgs e) {
            string[] ImportedLines = TextResults.Text.Split('\n');
            if (ImportedLines.Length == 0) return;
            foreach (string st in ImportedLines) {
                Element el = new Element {
                    Weight = 1,
                    Value = Regex.Match(st, @"(.*)").Value.TrimEnd('\r')
                };
                ViewItem.Elements.Add(el);
            }
            ListRolls.Items.Refresh();
        }
        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
