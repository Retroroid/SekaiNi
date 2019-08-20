
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
            ViewItem.Notes.Add(new Sekai.Note { Title = "Note 1 Name!", Time = "Note 1 Time!", Tag = "Note 1 Tag!", Text = "Note 1 Text!" });
            ViewItem.Notes.Add(new Sekai.Note { Title = "Note 2 Name!", Time = "Note 2 Time!", Tag = "Note 2 Tag!", Text = "Note 2 Text!" });
            ViewItem.Notes.Add(new Sekai.Note { Title = "Note 3 Name!", Time = "Note 3 Time!", Tag = "Note 3 Tag!", Text = "Note 3 Text!" });
            ViewItem.Notes.Add(new Sekai.Note { Title = "Note 4 Name!", Time = "Note 4 Time!", Tag = "Note 4 Tag!", Text = "Note 4 Text!" });
            ViewItem.Elements.Add(new Element { Tag = "Bad", Weight = 10, Value = "PC explodes" });
            ViewItem.Elements.Add(new Element { Tag = "Bad", Weight = 20, Value = "PC is dismembered" });
            ViewItem.Elements.Add(new Element { Tag = "Bad", Weight = 40, Value = "PC dies of blood loss" });
            ViewItem.Elements.Add(new Element { Tag = "Good", Weight = 1, Value = "PC finds love of their lfie" });
            ViewItem.Elements.Add(new Element { Tag = "Good", Weight = 1, Value = "PC finds money" });
            ViewItem.Elements.Add(new Element { Tag = "Bad", Weight = 99, Value = "PC is drawn and quartered after being shamed" });
        }
        // ---------------- Methods ---------------- ---------------- //
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

        private void MenuItemSave_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = $"{Sekai.Database.DPath}\\{ViewItem.ClassType}";
            sfd.FileName = $"{Sekai.Database.DPath}\\{ViewItem.ClassType}\\{ViewItem.ID}.bin";
            sfd.OverwritePrompt = true;
            if (sfd.ShowDialog() == true) {
                ViewItem.ID = Regex.Match(sfd.SafeFileName, @"(.*)\.").Value.TrimEnd('.');
                ViewItem.SerializeToFile();
            }
        }
        private void MenuItemLoad_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = $"{Sekai.Database.DPath}\\{ViewItem.ClassType}";
            if(ofd.ShowDialog() == true) {
                string[] FilePath = ofd.FileName.Split('\\');
                string st = Regex.Match(FilePath[FilePath.Length - 1], @"(.*)\.").Value.TrimEnd('.');
                ViewItem.ID = st;
                new DohEdit(ViewItem.DeserializeFileByID()).Show();
            }
        }
        // ---------------- Meta-Methods ---------------- ---------------- //


        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
