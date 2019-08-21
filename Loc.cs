using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    [Serializable]
    public class Loc : Dot {
        // ---------------- Variables ---------------- ---------------- //
        public Loc Parent {
            get { return _Parent; }
            set { if(value != _Parent) {
                    _Parent = value;
                    OnPropertyChanged("Parent");
                }
            }
        }
        private Loc _Parent;
        public int Population {
            get { return _Population; }
            set { if(value != _Population) {
                    _Population = value;
                    OnPropertyChanged("Population");
                }
            }
        }
        private int _Population;
        public int[] Coordinates {
            get { return _Coordinates; }
            set {
                if (value != _Coordinates) {
                    _Coordinates = value;
                    OnPropertyChanged("Coordinates");
                }
            }
        }
        private int[] _Coordinates;
        public List<Cha> Characters {
            get { return _Characters; }
            set { if(value != _Characters) {
                    _Characters = value;
                    OnPropertyChanged("Characters");
                }
            }
        }
        private List<Cha> _Characters;
        public List<Loc> Locations {
            get { return _Locations; }
            set {
                if (value != _Locations) {
                    _Locations = value;
                    OnPropertyChanged("Locations");
                }
            }
        }
        private List<Loc> _Locations;
        public List<Est> Establishments {
            get { return _Establishments; }
            set {
                if (value != _Establishments) {
                    _Establishments = value;
                    OnPropertyChanged("Establishments");
                }
            }
        }
        private List<Est> _Establishments;
        public List<Evt> Events {
            get { return _Events; }
            set {
                if (value != _Events) {
                    _Events = value;
                    OnPropertyChanged("Events");
                }
            }
        }
        private List<Evt> _Events;
        public List<Dot> Exports {
            get { return _Exports; }
            set {
                if (value != _Exports) {
                    _Exports = value;
                    OnPropertyChanged("Exports");
                }
            }
        }
        private List<Dot> _Exports;
        public List<Dot> Imports {
            get { return _Imports; }
            set {
                if (value != _Imports) {
                    _Imports = value;
                    OnPropertyChanged("Imports");
                }
            }
        }
        private List<Dot> _Imports;

        // ---------------- Constructors ---------------- ---------------- //
        public Loc() : base() {
            Coordinates = new int[] { 0, 0 };
            Characters = new List<Cha>();
            Locations = new List<Loc>();
            Establishments = new List<Est>();
            Events = new List<Evt>();
            Exports = new List<Dot>();
            Imports = new List<Dot>();
        }

        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace