using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Controller
{
     public class ControllerBase
    {
        public void Save(string fileName,object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,item );
            }
        }

        protected T Load<T>( string fileName ) where T : class
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    var item = formatter.Deserialize(fs) as T;
                    if (item != null)//избежать десериализации пустого потока 
                    {
                        return item;
                    }
                }

                return default(T);
            }
        }
    }
}
