using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    // ---------------- ---------------- ---------------- //
    [Serializable]
    public class Note : INotifyPropertyChanged {
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
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
        public Note() { }
    }
    // ---------------- ---------------- ---------------- //
    [Serializable]
    public class Accolade : INotifyPropertyChanged {
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public Fac Authority { //TODO
            get { return _Authority; }
            set {
                if (value != _Authority) {
                    _Authority = value;
                    OnPropertyChanged("Authority");
                }
            }
        }
        private Fac _Authority;
        public string Rank {
            get { return _Rank; }
            set {
                if (value != _Rank) {
                    _Rank = value;
                    OnPropertyChanged("Rank");
                }
            }
        }
        private string _Rank;
        public string Benefits {
            get { return _Benefits; }
            set {
                if (value != _Benefits) {
                    _Benefits = value;
                    OnPropertyChanged("Benefits");
                }
            }
        }
        private string _Benefits;
        public string Duties {
            get { return _Duties; }
            set {
                if (value != _Duties) {
                    _Duties = value;
                    OnPropertyChanged("Duties");
                }
            }
        }
        private string _Duties;
        public Accolade() { }
    }
    // ---------------- ---------------- ---------------- //
    [Serializable]
    public class Bonus : INotifyPropertyChanged {
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public string Source {
            get { return _Source; }
            set {
                if (value != _Source) {
                    _Source = value;
                    OnPropertyChanged("Source");
                }
            }
        }
        private string _Source;
        public int Value {
            get { return _Value; }
            set {
                if (value != _Value) {
                    _Value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
        private int _Value;
        public Bonus() { }
    }
    // ---------------- ---------------- ---------------- //
    [Serializable]
    public class Occupation : INotifyPropertyChanged {
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public string Employer { // Association or facility
            get { return _Employer; }
            set {
                if (value != _Employer) {
                    _Employer = value;
                    OnPropertyChanged("Employer");
                }
            }
        }
        private string _Employer;
        public string Title {
            get { return _Title; }
            set {
                if (Title != _Title) {
                    _Title = Title;
                    OnPropertyChanged("Title");
                }
            }
        }
        private string _Title;
        public string CurrentShift {
            get { return _CurrentShift; }
            set {
                if (CurrentShift != _CurrentShift) {
                    _CurrentShift = CurrentShift;
                    OnPropertyChanged("CurrentShift");
                }
            }
        }
        private string _CurrentShift;
        public Occupation() { }
    }
    // ---------------- ---------------- ---------------- //
    [Serializable]
    public class Service : INotifyPropertyChanged {
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
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
        public int Price {
            get { return _Price; }
            set {
                if (Price != _Price) {
                    _Price = Price;
                    OnPropertyChanged("Price");
                }
            }
        }
        private int _Price;
        public string Note {
            get { return _Note; }
            set {
                if (value != _Note) {
                    _Note = value;
                    OnPropertyChanged("Note");
                }
            }
        }
        private string _Note;
        public Service() { }
    }
    // ---------------- ---------------- ---------------- //
    [Serializable]
    public class Quest : INotifyPropertyChanged {
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
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
        public Mdl Module {
            get { return _Module; }
            set {
                if (Module != _Module) {
                    _Module = Module;
                    OnPropertyChanged("Module");
                }
            }
        }
        private Mdl _Module;
        public Cha PostedBy {
            get { return _PostedBy; }
            set {
                if (value != _PostedBy) {
                    _PostedBy = value;
                    OnPropertyChanged("PostedBy");
                }
            }
        }
        private Cha _PostedBy;
        public string Details {
            get { return _Details; }
            set {
                if (value != _Details) {
                    _Details = value;
                    OnPropertyChanged("Details");
                }
            }
        }
        private string _Details;
        public int Reward {
            get { return _Reward; }
            set {
                if (value != _Reward) {
                    _Reward = value;
                    OnPropertyChanged("Reward");
                }
            }
        }
        private int _Reward;
        public string[] Tags {
            get { return _Tags; }
            set {
                if (value != _Tags) {
                    _Tags = value;
                    OnPropertyChanged("Tags");
                }
            }
        }
        private string[] _Tags;
        public Quest() { }
    }
    // ---------------- ---------------- ---------------- //
    [Serializable]
    public class Ability : INotifyPropertyChanged {
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
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
        public int DieSize {
            get { return _DieSize; }
            set {
                if (value != _DieSize) {
                    _DieSize = value;
                    OnPropertyChanged("DieSize");
                }
            }
        }
        private int _DieSize;
        public int DieCount {
            get { return _DieCount; }
            set {
                if (value != _DieCount) {
                    _DieCount = value;
                    OnPropertyChanged("DieCount");
                }
            }
        }
        private int _DieCount;
        public int DieBonus {
            get { return _DieBonus; }
            set {
                if (value != _DieBonus) {
                    _DieBonus = value;
                    OnPropertyChanged("DieBonus");
                }
            }
        }
        private int _DieBonus;
        public int Charges {
            get { return _Charges; }
            set {
                if (value != _Charges) {
                    _Charges = value;
                    OnPropertyChanged("Charges");
                }
            }
        }
        private int _Charges;
        public string Recharge {
            get { return _Recharge; }
            set {
                if (value != _Recharge) {
                    _Recharge = value;
                    OnPropertyChanged("Recharge");
                }
            }
        }
        private string _Recharge;
        public Ability() { }
    }
    // ---------------- ---------------- ---------------- //
} // End of namespace
