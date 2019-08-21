using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SekaiNi {
    
    // ---------------- ---------------- ---------------- //

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
        public string ID {
            get { return _ID; }
            set {
                if (value != _ID) {
                    _ID = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        private string _ID;
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
        #endregion

        #region Meta-Properties
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

            // Create a new unique ID for this object.
            _ID = ClassType + DI.GetFiles().Length;

            // Default information
            _Name = $"{ClassType} Name";
            _Description = "A short expose of what this is.";
            ImagePath = string.Empty;

            // Initialize list
            Notes = new List<Note>();
        }

        // ---------------- Methods ---------------- ---------------- //


        // ---------------- Meta-Methods ---------------- ---------------- //
        #region Implementation / Override
        public int CompareTo(Dot obj) {
            // CompareTo for sorting implementation.
            if (obj == null) return 1;
            return string.Compare(ID, obj.ID);
        }
        override public string ToString() {
            return ID + ":" + Name;
        }
        #endregion

        #region Get-Set-Property by Name
        public object this[string propertyName] {
            get {
                Type myType = this.GetType();
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set {
                Type myType = this.GetType();
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);
            }
        }
        public void SetPropertyByName<T>(string field, T value) {
            this[field] = value;
        }
        public dynamic GetPropertyByName(string field) {
            return this[field];
        }
        #endregion


        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // end of class
} // end of namespace
