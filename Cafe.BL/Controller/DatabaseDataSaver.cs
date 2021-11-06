using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        

        public List<T> Load<T>() where T : class
        {
            using (var db = new CafeContext())
            {
                var result = db.Set<T>().Where(p=>true).ToList();
                return result;
            }
        }

        public void Save<T>(T item) where T:class
        {
           
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new CafeContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
