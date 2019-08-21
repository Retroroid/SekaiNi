using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    [Serializable]
    public class Cha : Dot {
        // ---------------- Variables ---------------- ---------------- //

        #region Dictionaries
        [field: NonSerialized]
        public static string[] AbilityScoreList = {
            "STR", "DEX", "CON", "INT", "WIS", "CHA"
        };
        [field: NonSerialized]
        public static string[] SkillList = {
            "Acrobatics", "Animal Handling", "Arcana",
            "Athletics", "Deception", "History",
            "Insight", "Intimidation", "Investigation",
            "Medicine", "Nature", "Perception",
            "Performance", "Persuasion", "Religion",
            "Sleight of Hand", "Stealth", "Survival"
        };
        [field: NonSerialized]
        public static Dictionary<string, string> SkillBaseByName = new Dictionary<string, string> {
                {"Acrobatics", "DEX" }, {"Animal Handling", "WIS" }, {"Arcana", "INT" },
                { "Athletics", "STR" }, {"Deception", "CHA" }, {"History", "INT"},
                { "Insight", "WIS" }, { "Intimidation", "CHA" }, { "Investigation", "INT" },
                { "Medicine", "WIS" }, { "Nature", "INT" }, { "Perception", "WIS" },
                { "Performance", "CHA" }, {"Persuasion","CHA" }, {"Religion","INT" },
                { "Sleight of Hand", "DEX" }, {"Stealth","DEX" }, { "Survival","WIS" }
            };
        #endregion

        #region Stat Block

        #region Ability Scores and Skills
        public AS STR {
            get { return _STR; }
            set {
                if (value != _STR) {
                    _STR = value;
                    OnPropertyChanged("STR");
                }
            }
        }
        private AS _STR;
        public AS DEX {
            get { return _DEX; }
            set {
                if (value != _DEX) {
                    _DEX = value;
                    OnPropertyChanged("DEX");
                }
            }
        }
        private AS _DEX;
        public AS CON {
            get { return _CON; }
            set {
                if (value != _CON) {
                    _CON = value;
                    OnPropertyChanged("CON");
                }
            }
        }
        private AS _CON;
        public AS INT {
            get { return _INT; }
            set {
                if (value != _INT) {
                    _INT = value;
                    OnPropertyChanged("INT");
                }
            }
        }
        private AS _INT;
        public AS WIS {
            get { return _WIS; }
            set {
                if (value != _WIS) {
                    _WIS = value;
                    OnPropertyChanged("WIS");
                }
            }
        }
        private AS _WIS;
        public AS CHA {
            get { return _CHA; }
            set {
                if (value != _CHA) {
                    _CHA = value;
                    OnPropertyChanged("CHA");
                }
            }
        }
        private AS _CHA;
        public AS[] Skills {
            get { return _Skills; }
            set {
                if (value != _Skills) {
                    _Skills = value;
                    OnPropertyChanged("Skills");
                }
            }
        }
        private AS[] _Skills;
        #endregion

        public int HPCurrent {
            get { return _HPCurrent; }
            set {
                if (value != _HPCurrent) {
                    _HPCurrent = value;
                    OnPropertyChanged("HPCurrent");
                }
            }
        }
        private int _HPCurrent;
        public int HPMax {
            get { return _HPMax; }
            set {
                if (value != _HPMax) {
                    _HPMax = value;
                    OnPropertyChanged("HPMax");
                }
            }
        }
        private int _HPMax;
        public int PB {
            get { return _PB; }
            set {
                if (value != _PB) {
                    _PB = value;
                    OnPropertyChanged("PB");
                }
            }
        }
        private int _PB;
        public int AC {
            get { return _AC; }
            set {
                if (value != _AC) {
                    _AC = value;
                    OnPropertyChanged("AC");
                }
            }
        }
        private int _AC;
        public int Speed {
            get { return _Speed; }
            set {
                if (value != _Speed) {
                    _Speed = value;
                    OnPropertyChanged("Speed");
                }
            }
        }
        private int _Speed;
        #endregion

        #region RP Block
        public string Activity {
            get { return _Activity; }
            set {
                if (value != _Activity) {
                    _Activity = value;
                    OnPropertyChanged("Activity");
                }
            }
        }
        private string _Activity;
        public Occupation Occupation {
            get { return _Occupation; }
            set {
                if (value != _Occupation) {
                    _Occupation = value;
                    OnPropertyChanged("Occupation");
                }
            }
        }
        private Occupation _Occupation;
        public List<Cha> Relationships {
            get { return _Relationships; }
            set {
                if (value != _Relationships) {
                    _Relationships = value;
                    OnPropertyChanged("Relationships");
                }
            }
        }
        private List<Cha> _Relationships;
        #endregion

        #region Miscellaneous Block
        public List<Itm> Inventory { //TODO
            get { return _Inventory; }
            set {
                if (value != _Inventory) {
                    _Inventory = value;
                    OnPropertyChanged("Inventory");
                }
            }
        }
        private List<Itm> _Inventory;
        public List<Ability> Attacks { //TODO
            get { return _Attacks; }
            set {
                if (value != _Attacks) {
                    _Attacks = value;
                    OnPropertyChanged("Loadout");
                }
            }
        }
        private List<Ability> _Attacks;
        public List<Ability> Abilities { //TODO
            get { return _Abilities; }
            set {
                if (value != _Abilities) {
                    _Abilities = value;
                    OnPropertyChanged("Abilities");
                }
            }
        }
        private List<Ability> _Abilities;
        public List<Accolade> Accolades { //TODO
            get { return _Accolades; }
            set {
                if (value != _Accolades) {
                    _Accolades = value;
                    OnPropertyChanged("Accolades");
                }
            }
        }
        private List<Accolade> _Accolades;
        #endregion

        // ---------------- Constructors ---------------- ---------------- //
        public Cha() : base() {
            // Initialize Ability Scores
            STR = new AS { Name = "STR"};
            DEX = new AS { Name = "DEX"};
            CON = new AS { Name = "CON"};
            INT = new AS { Name = "INT"};
            WIS = new AS { Name = "WIS"};
            CHA = new AS { Name = "CHA"};

            // Initialzie Skills
            for (int i = 0; i < SkillList.Length; i++) {
                Skills[i] = new AS {
                    Name = SkillList[i],
                    Based = SkillBaseByName[SkillList[i]],
                };
            }

            // Initialize other stats
            HPCurrent = 10; HPMax = 10;
            PB = 2; AC = 10; Speed = 10;

            // Initialize RP
            Activity = "Current activity";
            Occupation = new Occupation();
            Relationships = new List<Cha>();

            // Initialize Miscellaneous
            Inventory = new List<Itm>();
            Attacks = new List<Ability>();
            Abilities = new List<Ability>();
            Accolades = new List<Accolade>();
        }

        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
    // ---------------- ---------------- ---------------- //
    [Serializable]
    public class AS : INotifyPropertyChanged {
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion
        public int Score {
            get { return _Score; }
            set {
                if (value != _Score) {
                    _Score = value;
                    OnPropertyChanged("Score");
                }
            }
        }
        private int _Score;
        public string Based {
            get { return _Based; }
            set {
                if (value != _Based) {
                    _Based = value;
                    OnPropertyChanged("Based");
                }
            }
        }
        private string _Based;
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
        public bool Proficient {
            get { return _Proficient; }
            set {
                if (value != _Proficient) {
                    _Proficient = value;
                    OnPropertyChanged("Proficient");
                }
            }
        }
        private bool _Proficient;
        public List<Bonus> Bonuses {
            get { return _Bonuses; }
            set {
                if (value != _Bonuses) {
                    _Bonuses = value;
                    OnPropertyChanged("Bonuses");
                }
            }
        }
        private List<Bonus> _Bonuses;
        public AS() {
            Score = 10;
            Based = string.Empty;
            Name = string.Empty;
            Proficient = false;
            Bonuses = new List<Bonus>();
        }
    }
} // End of namespace