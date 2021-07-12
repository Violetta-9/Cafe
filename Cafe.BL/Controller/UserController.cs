﻿using System;
using System.Collections.Generic;
using System.Data;
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
        public List<User> Users { get; }
        public User CurrentUser { get; set; }
        public bool IsNewUser { get; } = false;


        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
               
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,Users);
            }

        }
        /// <summary>
        /// Получить список  пользователей из файла.
        /// </summary>
        /// <returns>Список пользователей приложения.</returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    var usersLoad = formatter.Deserialize(fs) as List<User>;// один пользователь получается 
                    if (usersLoad != null)//избежать десериализации пустого потока 
                    {
                        return usersLoad;
                    }
                }

                
               

               return new List<User>();
            }
        }

        public void SetNewUserData(string genderName, DateTime birdthDate, string number, string addres)
        {
            // Проверка 
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirdthDate = birdthDate;
            CurrentUser.Number = number;
            CurrentUser.Addres = addres;
            Save();

        }
    }
}
