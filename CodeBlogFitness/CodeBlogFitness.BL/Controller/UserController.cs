using CodeBlogFitness.BL.Model;
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
    public class UserController : ControllerBase
    {
      
        /// <summary>
        /// ПОльзователи приложения.
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public User CurrentUser { get; }
        /// <summary>
        /// Флаг нового пользователя.
        /// </summary>
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не должно быть пустым!",nameof(userName));
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
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns> Пользователь приложения!</returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
           

        }
        /// <summary>
        /// Добавление свойств нашему новому пользователю.
        /// </summary>
        public void SetNewUserData(string genderName, 
                                   DateTime birthDate, 
                                   double weight = 1, 
                                   double height = 1)
        {
            //TODO: Проверка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(Users);
        }
        
    }
}
