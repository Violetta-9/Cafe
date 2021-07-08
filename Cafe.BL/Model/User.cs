using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Model
{/// <summary>
/// Пользоваткль
/// </summary>
[Serializable]
public class User
    {
        #region Properties

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get;}// только один раз устанавливаем имя при создании класса
        /// <summary>
            /// Полю
            /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
          
        //DateTime nowDate = DateTime.Today;
        //int age = nowDate.Year - birthDate.Year;
        //if (birthDate > nowDate.AddYears(-age)) age--;
        public int Age { get { return DateTime.Now.Year - BirdthDate.Year; } }
        public DateTime BirdthDate { get; set; }
            /// <summary>
            ///Номер.
            /// </summary>
        public string Number { get; set; }
            /// <summary>
            /// Адрес.
            /// </summary>
        public string Addres { get; set; }
            #endregion
        /// <summary>
        /// Новый пользователь.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthdate">Дата рождения.</param>
        /// <param name="number">Номер.</param>
        /// <param name="addres">Адрес.</param>
        public User(string name, 
                    Gender gender, 
                    DateTime birdthdate, 
                    string number, 
                    string addres)
        {
            #region CheckingСonditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentException("Gender cannot be null.", nameof(gender));
            }

            if (birdthdate < DateTime.Parse("01.01.1900") || birdthdate>=DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birdthdate));
            }

            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException("Number cannot be null or empty.", nameof(number));
            }

            if (string.IsNullOrWhiteSpace(addres))
            {
                throw new ArgumentNullException("Addres cannot be null or empty.", nameof(addres));
            }

            Name = name;

            #endregion

            Name = name;
            Gender = gender;
            BirdthDate = birdthdate;
            Number = number;
            Addres = addres;

        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name+" "+Age;
        }
    }
}
