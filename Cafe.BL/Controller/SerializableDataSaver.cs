using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Cafe.BL.Controller
{
     class SerializableDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    var item = formatter.Deserialize(fs) as List<T>;
                    if (item != null)//избежать десериализации пустого потока 
                    {
                        return item;
                    }
                }
                return new List<T>();
            }
        }

        public void Save<T>(T item) where T: class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
