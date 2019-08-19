using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sekai {
    [Serializable]
    public class Note : INotifyPropertyChanged {
        #region Property Changed Event
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(nam));
            }
        }
        #endregion

        #region Properties
        public string Title {
            get { return _Title; }
            set {
                if (value != _Title) {
                    _Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        private string _Title;
        public string Time {
            get { return _Time; }
            set {
                if (value != _Time) {
                    _Time = value;
                    OnPropertyChanged("Time");
                }
            }
        }
        private string _Time;
        public string Tag {
            get { return _Tag; }
            set {
                if (value != _Tag) {
                    _Tag = value;
                    OnPropertyChanged("Tag");
                }
            }
        }
        private string _Tag;
        public string Text {
            get { return _Text; }
            set {
                if (value != _Text) {
                    _Text = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        private string _Text;
        #endregion

        public Note() { }
    }

    [Serializable]
    public class Dot : IComparable<Dot>, INotifyPropertyChanged {
        // ---------------- Variables ---------------- ---------------- //

        #region Property Changed Event
        public event PropertyChangedEventHandler PropertyChanged; 

        protected void OnPropertyChanged(string nam) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null){
                handler(this, new PropertyChangedEventArgs(nam));
            }
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

        public List<Note> Notes { get; set; }
        #endregion

        #region Meta-Properties
        public string DirectoryPath { get; set; }
        public string SavePath { get; set; }
        public string ClassType { get; set; }
        public string ImagePath { get; set; }
        #endregion


        // ---------------- Constructors ---------------- ---------------- //
        public Dot() {
            // Get class type as string
            string[] classType = GetType().ToString().Split('.');
            ClassType = classType[classType.Length - 1];

            // Base directory of this type of object. Useful with the sub-classes
            DirectoryPath = Database.DPath + "\\" + ClassType;
            if (!System.IO.Directory.Exists(DirectoryPath)) System.IO.Directory.CreateDirectory(DirectoryPath);
            DirectoryInfo DI = new DirectoryInfo(DirectoryPath);

            // Create a new unique ID for this object.
            _ID = ClassType + DI.GetFiles().Length;
            SavePath = DirectoryPath + "\\" + ID + ".bin";

            // Default information
            _Name = $"{ClassType} Name";
            _Description = "A short expose of what this is.";
            ImagePath = String.Empty;

            // Initialize list
            Notes = new List<Note>();
        }

        // ---------------- Methods ---------------- ---------------- //
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

        #region Serialization
        public void SerializeFile() {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(SavePath, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, this);
            stream.Close();
        }
        public static T DeserializeFile<T>(string FileID) where T : Dot {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(
                $"{Database.DPath}\\{FileID.Substring(0, 3)}\\{FileID}.bin",
                FileMode.Open,
                FileAccess.Read);
            return (T)formatter.Deserialize(stream);
        }
        #endregion


        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // end of class
} // end of namespace
