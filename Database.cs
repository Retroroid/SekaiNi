using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekai {
    class Database {
        // ---------------- Variables ---------------- ---------------- //
        public static string DPath;
        public static Font DFont;
        public static Random DRng;

        // ---------------- Constructors ---------------- ---------------- //
        public static void InitializeDatabase() {
            string tempPath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            DPath = System.IO.Path.GetDirectoryName(tempPath).Substring(6).Replace("/", "\\\\") + "\\Data";
            DFont = new Font("Microsoft Sans Serif", 11);
            DRng = new Random(Guid.NewGuid().GetHashCode());
        }

        // ---------------- Methods ---------------- ---------------- //
        

        // ---------------- ---------------- ---------------- ---------------- //
        // ---------------- ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace
