using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Cafe.BL.Model;

namespace Cafe.BL.Controller
{/// <summary>
/// Контроллер пользователя.
/// </summary>
   public  class UserController
    {/// <summary>
    /// Пользователь приложения.
    /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName,DateTime birdthDay,string number,string addres)
        {
            //TODO: проверка
            var gender = new Gender(genderName);
            User= new User(userName, gender, birdthDay, number, addres);
            
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,User);
            }

        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        public UserController ()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
               var userLoad= formatter.Deserialize(fs) as User;// один пользователь получается 
               if (userLoad!=null)
               {
                   User = userLoad;
               }
               //TODO:Что делать, если пользователь не прочитан?
            }
        }
    }
}
