using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    [Serializable]
    public class Evt : Dot {
        // ---------------- Variables ---------------- ---------------- //
        public List<Evt> SubEvents {
            get { return _SubEvents; }
            set {
                if (SubEvents != _SubEvents) {
                    _SubEvents = SubEvents;
                    OnPropertyChanged("SubEvents");
                }
            }
        }
        private List<Evt> _SubEvents;
        public List<Cha> Characters {
            get { return _Characters; }
            set {
                if (Characters != _Characters) {
                    _Characters = Characters;
                    OnPropertyChanged("Characters");
                }
            }
        }
        private List<Cha> _Characters;
        public List<Doh> RandomEvents {
            get { return _RandomEvents; }
            set {
                if (RandomEvents != _RandomEvents) {
                    _RandomEvents = RandomEvents;
                    OnPropertyChanged("RandomEvents");
                }
            }
        }
        private List<Doh> _RandomEvents;

        // ---------------- Constructors ---------------- ---------------- //
        public Evt() : base() {
            SubEvents = new List<Evt>();
            Characters = new List<Cha>();
            RandomEvents = new List<Doh>();
        }

        new public Evt CloneObject() {
            return new Evt {
                SubEvents = SubEvents,
                Characters = Characters,
                RandomEvents = RandomEvents
            };
        }
        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
