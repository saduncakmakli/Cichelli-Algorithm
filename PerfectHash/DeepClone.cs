using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PerfectHash
{
    static class DeepClone
    {
        //Kullanımı atama_yapılacak_ref_type_degisken = DeepClone.ReturnDeepClone(kopyalananan_ref_type_degisken);
        public static T ReturnDeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
