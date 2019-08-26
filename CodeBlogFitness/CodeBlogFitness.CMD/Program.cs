using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложения CodeBlogFitness!");
            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();
            #region Coment
            /*
            Console.WriteLine("Введите пол:");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите Дату рождения:");
            var birthDate = DateTime.Parse( Console.ReadLine()); //TODO: переписать

            Console.WriteLine("Введите вес:");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост:");
            var height = double.Parse(Console.ReadLine());
            
            */
            #endregion
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол:");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("Вес");
                var height = ParseDouble("Рост");
               1:50:34

                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);




            Console.ReadLine();

        }
        /// <summary>
        /// Распарсиваем DateTime.
        /// </summary>
        /// <returns>Число введеное</returns>
        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите Дату рождения (dd:MM:yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильный формат ДАТЫ!");
                }
            }

            return birthDate;
        }

        /// <summary>
        /// Распарсиваем double.
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <returns>Число введеное</returns>
        private static double ParseDouble(string name) 
        {
           
            while (true)
            {
                Console.WriteLine($"Введите {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неправильный формат {name}!");
                }
            }
        }
    }
}
