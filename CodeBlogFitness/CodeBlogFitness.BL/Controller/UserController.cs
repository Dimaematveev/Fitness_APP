﻿using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контролер пользователя.
    /// </summary>
    public class UserController
    {
        //ПОльзователь приложения.
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController (User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException("Пользователь не может быть равен null!",nameof(user));
            }
            User = user;
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat",FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns> Пользователь приложения!</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: Что делать если пользователя не прочитали?
            }
            
        }
    }
}