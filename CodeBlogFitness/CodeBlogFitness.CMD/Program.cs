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
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол:");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("Вес");
                var height = ParseDouble("Рост");
                

                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);


            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - ввести прием пищи");
            var key=Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
               var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var food in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"{food.Key} {food.Value}");
                }
            }


            Console.ReadLine();

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();


            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");



            var weight = ParseDouble("вес порции");

            var product = new Food(food,calories,prots,fats,carbs);
            return (product, weight);
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
                    Console.WriteLine($"Неправильный формат поля {name}!");
                }
            }
        }
    }
}
