
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SekaiNi {
    /// <summary>
    /// Interaction logic for DohEdit.xaml
    /// </summary>
    public partial class DohEdit {
        // ---------------- Variables ---------------- ---------------- //
        public Doh ViewItem { get; set; }

        // ---------------- Constructors ---------------- ---------------- //
        public DohEdit() {
            ViewItem = new Doh();
            ViewItem.CreateChildNode();
            ViewItem.Notes.Add(new Sekai.Note { Title = "Note 1 Name!", Time = "Note 1 Time!", Tag = "Note 1 Tag!", Text = "Note 1 Text!" });
            ViewItem.Notes.Add(new Sekai.Note { Title = "Note 2 Name!", Time = "Note 2 Time!", Tag = "Note 2 Tag!", Text = "Note 2 Text!" });
            ViewItem.Notes.Add(new Sekai.Note { Title = "Note 3 Name!", Time = "Note 3 Time!", Tag = "Note 3 Tag!", Text = "Note 3 Text!" });
            ViewItem.Notes.Add(new Sekai.Note { Title = "Note 4 Name!", Time = "Note 4 Time!", Tag = "Note 4 Tag!", Text = "Note 4 Text!" });

            InitializeComponent();

            DataContext = ViewItem;
            //ListNotes.ItemsSource = ViewItem.Notes;
        }

        // ---------------- Methods ---------------- ---------------- //
        private void ChangeID(object sender, RoutedEventArgs e) {
            ViewItem.ID = "Wowee!";
            
        }

        // ---------------- Meta-Methods ---------------- ---------------- //


        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
