using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SekaiNi {
    public static class Extensions {
        // ---------------- ---------------- ---------------- ----------------//
        #region Serialization
        public static void SerializeToFile<T>(this T ViewItem) where T:Sekai.Dot {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream($"{Sekai.Database.DPath}\\{ViewItem.ClassType}\\{ViewItem.ID}.bin",
                FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, ViewItem);
            stream.Close();
        }
        public static T DeserializeFileByID<T>(this T ViewItem) where T : Sekai.Dot {
            if (ViewItem is null) {
                throw new ArgumentNullException(nameof(ViewItem));
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(
                $"{Sekai.Database.DPath}\\{ViewItem.ClassType}\\{ViewItem.ID}.bin",
                FileMode.Open, FileAccess.Read);
            return (T)formatter.Deserialize(stream);
        }
        #endregion

        // ---------------- ---------------- ---------------- ----------------//


        // ---------------- ---------------- ---------------- ----------------//
    } // End of class
} // End of namespace
