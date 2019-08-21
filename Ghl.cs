using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    public class Ghl : Est {
        // ---------------- Variables ---------------- ---------------- //
        public List<Cha> CommonRoom {
            get { return _CommonRoom; }
            set {
                if (value != _CommonRoom) {
                    _CommonRoom = value;
                    OnPropertyChanged("CommonRoom");
                }
            }
        }
        private List<Cha> _CommonRoom;
        public List<Quest> Questboard {
            get { return _Questboard; }
            set {
                if (value != _Questboard) {
                    _Questboard = value;
                    OnPropertyChanged("Questboard");
                }
            }
        }
        private List<Quest> _Questboard;

        // ---------------- Constructors ---------------- ---------------- //
        public Ghl() : base() {
            CommonRoom = new List<Cha>();
            Questboard = new List<Quest>();
        }

        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
