using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    [Serializable]
    public class Fac : Dot{
        // ---------------- Variables ---------------- ---------------- //
        public string Focus {
            get { return _Focus; }
            set {
                if (Focus != _Focus) {
                    _Focus = Focus;
                    OnPropertyChanged("Focus");
                }
            }
        }
        private string _Focus;
        public List<Loc> Locations {
            get { return _Locations; }
            set {
                if (Locations != _Locations) {
                    _Locations = Locations;
                    OnPropertyChanged("Locations");
                }
            }
        }
        private List<Loc> _Locations;
        public List<Cha> Authority {
            get { return _Authority; }
            set {
                if (Authority != _Authority) {
                    _Authority = Authority;
                    OnPropertyChanged("Authority");
                }
            }
        }
        private List<Cha> _Authority;
        public List<Cha> Members {
            get { return _Members; }
            set {
                if (Members != _Members) {
                    _Members = Members;
                    OnPropertyChanged("Members");
                }
            }
        }
        private List<Cha> _Members;
        public List<Fac> Groups {
            get { return _Groups; }
            set {
                if (Groups != _Groups) {
                    _Groups = Groups;
                    OnPropertyChanged("Groups");
                }
            }
        }
        private List<Fac> _Groups;
        public List<Accolade> Ranks {
            get { return _Ranks; }
            set {
                if (Ranks != _Ranks) {
                    _Ranks = Ranks;
                    OnPropertyChanged("Ranks");
                }
            }
        }
        private List<Accolade> _Ranks;

        // ---------------- Constructors ---------------- ---------------- //
        public Fac() : base() {
            Focus = "Speciality or focus";
            Locations = new List<Loc>();
            Authority = new List<Cha>();
            Members = new List<Cha>();
            Groups = new List<Fac>();
            Ranks = new List<Accolade>();
        }
        new public Fac CloneObject() {
            return new Fac {
                Name = Name,
                Description = Description,
                Location = Location,
                Notes = Notes,
                Focus = Focus,
                Locations = Locations,
                Authority = Authority,
                Members = Members,
                Groups = Groups,
                Ranks = Ranks
            };
        }
        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
