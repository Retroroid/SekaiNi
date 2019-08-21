using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SekaiNi {
    // ---------------- ---------------- ---------------- //
    [Serializable]
    public class Dot : IComparable<Dot>, INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //

        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged; 
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion

        #region Properties
        public string Name {
            get { return _Name; }
            set {
                if (value != _Name) {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _Name;
        public string Description {
            get { return _Description; }
            set {
                if (value != _Description) {
                    _Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _Description;

        public List<Note> Notes {
            get { return _Notes; }
            set {
                if (value != _Notes) {
                    _Notes = value;
                    OnPropertyChanged("Notes");
                }
            }
        }
        private List<Note> _Notes;
        public Loc Location {
            get { return _Location; }
            set {
                if (Location != _Location) {
                    _Location = Location;
                    OnPropertyChanged("Location");
                }
            }
        }
        private Loc _Location;

        public string ClassType { get; set; }
        public string ImagePath { get; set; }
        #endregion


        // ---------------- Constructors ---------------- ---------------- //
        public Dot() {
            // Get class type as string
            string[] classType = GetType().ToString().Split('.');
            ClassType = classType[classType.Length - 1];

            // Base directory of this type of object. Useful with the sub-classes
            if (!System.IO.Directory.Exists($"{Database.DPath}\\{ClassType}"))
                System.IO.Directory.CreateDirectory($"{Database.DPath}\\{ClassType}");
            DirectoryInfo DI = new DirectoryInfo($"{Database.DPath}\\{ClassType}");

            // Default information
            Name = $"{ClassType} {DI.GetFiles().Length}";
            Description = $"A short expose of what this {ClassType} is.";
            ImagePath = string.Empty;

            // Initialize list
            Notes = new List<Note>();
        }

        // ---------------- Methods ---------------- ---------------- //
        #region Implementation / Override
        public int CompareTo(Dot obj) {
            // CompareTo for sorting implementation.
            if (obj == null) return 1;
            return string.Compare(Name, obj.Name);
        }
        override public string ToString() {
            return Name;
        }
        #endregion

        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // end of class
} // end of namespace
