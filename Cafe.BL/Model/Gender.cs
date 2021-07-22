﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Model
{/// <summary>
/// Пол.
/// </summary>
 [Serializable]
     public class Gender
     {/// <summary>
     /// Название.
     /// </summary>
         public string Name { get; }
     /// <summary>
     /// Создать новый пол.
     /// </summary>
     /// <param name="name">Имя поля.</param>
         public Gender(string name)
         {
             if (string.IsNullOrEmpty(name))
             {
                 throw new ArgumentNullException("Имя не может быть пустым", nameof(name));

             }

             Name = name;
         }


         public override string ToString()
         {
             return Name;
         }
    
     }
}
