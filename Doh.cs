using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SekaiNi {
    [Serializable]
    public class Element : IComparable, INotifyPropertyChanged {
        #region Property Changed Event
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nam) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nam));
        }
        #endregion

        #region Props
        public int Weight {
            get { return _Weight; }
            set {
                if (value != _Weight) {
                    _Weight = value;
                    OnPropertyChanged("Weight");
                }
            }
        }
        private int _Weight;
        public string Value {
            get { return _Value; }
            set {
                if (value != _Value) {
                    _Value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
        private string _Value;
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
        #endregion

        public Element() { }
        public Element(Element El) {
            if (El != null) {
                Weight = El.Weight;
                if (El.Value != null) { Value = El.Value; }
                if (El.Tag != null) { Tag = El.Tag; }
            }
        }
        public int CompareTo(object Obj) {
            int ReturnInt;
            Element el = Obj as Element;
            ReturnInt = Weight.CompareTo(el.Weight);
            if (ReturnInt == 0) ReturnInt = Value.CompareTo(el.Value);
            if (ReturnInt == 0) ReturnInt = Value.CompareTo(el.Value);
            return ReturnInt;
        }
    }

    [Serializable]
    public class Doh : Sekai.Dot {
        // ---------------- Variables ---------------- ---------------- //
        public List<Element> Elements {
            get { return _Elements; }
            set {
                if (value != _Elements) {
                    _Elements = value;
                    OnPropertyChanged("Elements");
                }
            }
        }
        private List<Element> _Elements;
        public Doh Parent { get; set; }
        public Doh Child { get; set; }

        private readonly Random RNG;


        // ---------------- Constructors ---------------- ---------------- //
        public Doh() {
            Name = "Doh Name";
            Elements = new List<Element>();
            RNG = new Random(Guid.NewGuid().GetHashCode());
        }

        // ---------------- Methods ---------------- ---------------- //
        public Element RollOnList() {
            if (Elements.Count < 1) {
                MessageBox.Show("No Elements in the list! :(");
                return null;
            }
            int Target = RNG.Next(Elements.Sum(Elem => Elem.Weight));
            int CurrentlyAt = 0;
            for (int i = 0; i < Elements.Count; i++) {
                CurrentlyAt += Elements[i].Weight;
                if (Target < CurrentlyAt) return Elements[i];
            }
            return Elements[0];
        }

        #region Node Manipulation
        public void CreateChildNode() {
            if (Child != null) throw new Exception("Doh already has a child Doh. (Sekai.Doh.CreateChildNode)");
            Child = new Doh();
        }
        public void InsertNode(bool GoesBeforeThis, Doh ToInsert) {
            if (GoesBeforeThis) {
                ToInsert.Parent = Parent;
                ToInsert.Child = this;
                ToInsert.Parent.Child = ToInsert;
                Parent = ToInsert;
            }
            else {
                ToInsert.Child = Child;
                ToInsert.Parent = this;
                ToInsert.Child.Parent = ToInsert;
                Child = ToInsert;
            }
        }
        #endregion

        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
