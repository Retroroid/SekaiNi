using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    [Serializable]
    public class Itm : Dot {
        // ---------------- Variables ---------------- ---------------- //
        public string ItemType {
            get { return _ItemType; }
            set {
                if (value != _ItemType) {
                    _ItemType = value;
                    OnPropertyChanged("ItemType");
                }
            }
        }
        private string _ItemType;
        public int Mass {
            get { return _Mass; }
            set {
                if (value != _Mass) {
                    _Mass = value;
                    OnPropertyChanged("Mass");
                }
            }
        }
        private int _Mass;
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
        public int Rarity {
            get { return _Rarity; }
            set {
                if (value != _Rarity) {
                    _Rarity = value;
                    OnPropertyChanged("Rarity");
                }
            }
        }
        private int _Rarity;
        public int Magic {
            get { return _Magic; }
            set {
                if (value != _Magic) {
                    _Magic = value;
                    OnPropertyChanged("Magic");
                }
            }
        }
        private int _Magic;
        public int Quantity {
            get { return _Quantity; }
            set {
                if (value != _Quantity) {
                    _Quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }
        private int _Quantity;
        public bool IsWeapon {
            get { return _IsWeapon; }
            set { if(value != _IsWeapon) {
                    _IsWeapon = value;
                    OnPropertyChanged("IsWeapon");
                }
            }
        }
        private bool _IsWeapon;
        public List<Ability> Attacks {
            get { return _Attacks; }
            set { if(value != _Attacks) {
                    _Attacks = value;
                    OnPropertyChanged("Attacks");
                }
            }
        }
        private List<Ability> _Attacks;
        public List<Ability> Abilities {
            get { return _Abilities; }
            set { if(value != _Abilities) {
                    _Abilities = value;
                    OnPropertyChanged("Abilities");
                }
            }
        }
        private List<Ability> _Abilities;

        // ---------------- Constructors ---------------- ---------------- //
        public Itm() : base() {
            Mass = Value = Rarity = Magic = Quantity = 0;
            IsWeapon = false;
            Attacks = new List<Ability>();
            Abilities = new List<Ability>();
        }

        // ---------------- Methods ---------------- ---------------- //
        new public Itm CloneObject() {
            return new Itm {
                ItemType = ItemType,
                Mass = Mass,
                Value = Value,
                Rarity = Rarity,
                Magic = Magic,
                Quantity = Quantity,
                IsWeapon = IsWeapon,
                Attacks = Attacks,
                Abilities = Abilities
            };
        }

        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
