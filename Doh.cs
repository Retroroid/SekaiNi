using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SekaiNi {
    public class Element : IComparable {
        public int Weight { get; set; }
        public string Value { get; set; }
        public string ID { get; set; }
        public string Tag { get; set; }
        public Element() { }
        public int CompareTo(object Obj) {
            int ReturnInt;
            Element el = Obj as Element;
            ReturnInt = Weight.CompareTo(el.Weight);
            if (ReturnInt == 0) ReturnInt = Value.CompareTo(el.Value);
            if (ReturnInt == 0) ReturnInt = ID.CompareTo(el.ID);
            return ReturnInt;
        }
    }
    public class Doh : Sekai.Dot  {
        // ---------------- Variables ---------------- ---------------- //
        public List<Element> Elements { get; set; }
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

        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
