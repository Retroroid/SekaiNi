using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    [Serializable]
    public class Mdl : Dot {
        // ---------------- Variables ---------------- ---------------- //
        public List<Cha> Characters {
            get { return _Characters; }
            set {
                if (value != _Characters) {
                    _Characters = value;
                    OnPropertyChanged("Characters");
                }
            }
        }
        private List<Cha> _Characters;
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

        // ---------------- Constructors ---------------- ---------------- //
        public Mdl() : base() {
            Characters = new List<Cha>();
            Events = new List<Evt>();
        }

        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
