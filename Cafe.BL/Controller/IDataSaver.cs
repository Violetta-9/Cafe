using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Controller
{
    public interface IDataSaver
    {
        void Save<T>(T item) where T:class;
        List<T> Load<T>() where T : class;


    }
    

    
}
