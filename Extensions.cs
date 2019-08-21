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
        public static void SerializeToFile<T>(this T ViewItem) where T:Dot {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream($"{Database.DPath}\\{ViewItem.ClassType}\\{ViewItem.ClassType}{ViewItem.Name}.bin",
                FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, ViewItem);
            stream.Close();
        }
        public static T DeserializeFile<T>(this T ViewItem) where T : Dot {
            if (ViewItem is null) {
                throw new ArgumentNullException(nameof(ViewItem));
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(
                $"{Database.DPath}\\{ViewItem.ClassType}\\{ViewItem.ClassType}{ViewItem.Name}.bin",
                FileMode.Open, FileAccess.Read);
            T obj = (T)formatter.Deserialize(stream);
            return obj;
        }
        #endregion
        // ---------------- ---------------- ---------------- ----------------//
    } // End of class
} // End of namespace
