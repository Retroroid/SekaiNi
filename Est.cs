using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    [Serializable]
    public class Est : Fac {
        // ---------------- Variables ---------------- ---------------- //
        public Fac Faction {
            get { return _Faction; }
            set {
                if (Faction != _Faction) {
                    _Faction = Faction;
                    OnPropertyChanged("Faction");
                }
            }
        }
        private Fac _Faction;
        public List<Cha> Staff {
            get { return _Staff; }
            set {
                if (Staff != _Staff) {
                    _Staff = Staff;
                    OnPropertyChanged("Staff");
                }
            }
        }
        private List<Cha> _Staff;
        public List<Service> Services {
            get { return _Services; }
            set {
                if (Services != _Services) {
                    _Services = Services;
                    OnPropertyChanged("Services");
                }
            }
        }
        private List<Service> _Services;

        // ---------------- Constructors ---------------- ---------------- //
        public Est() : base() {
            Staff = new List<Cha>();
            Services = new List<Service>();
        }

        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
