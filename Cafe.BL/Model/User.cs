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
    public class User
    {
        private readonly string _name;
            /// <summary>
            /// Имя.
            /// </summary>
        public string Name { get;}// только один раз устанавливаем имя при создании класса
            /// <summary>
            /// Полю
            /// </summary>
        public Gender Gender { get; }
            /// <summary>
            /// Дата рождения.
            /// </summary>
        public DateTime BirthDate { get; }
            /// <summary>
            ///Номер.
            /// </summary>
        public string Number { get; set; }
            /// <summary>
            /// Адрес.
            /// </summary>
        public string Addres { get; set; }
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
                    DateTime birthdate, 
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

            if (birthdate < DateTime.Parse("01.01.1900") || birthdate>=DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birthdate));
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
            BirthDate = birthdate;
            Number = number;
            Addres = addres;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
