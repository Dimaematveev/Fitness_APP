using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //var culture = CultureInfo.CreateSpecificCulture("en-us");
            var culture = CultureInfo.CurrentCulture;
            var resourseManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Message", typeof(Program).Assembly);
            Console.WriteLine(resourseManager.GetString("Hello",culture));
            Console.WriteLine(resourseManager.GetString("EnterName",culture));
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
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол:");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("Вес");
                var height = ParseDouble("Рост");
                

                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Е - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - Выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var food in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"{food.Key} {food.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.activity, exe.begin, exe.end);
                        foreach (var exercise in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{exercise.Activity} c {exercise.Start.ToShortTimeString()} до {exercise.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

            }
            Console.ReadLine();

        }

        private static (DateTime begin, DateTime end, Activity activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения:");
            var name = Console.ReadLine();
            var energy = ParseDouble("расзод энергии в минуту");
            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");
            var activity = new Activity(name, energy);
            return (begin, end, activity);
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
        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Введите {value} (dd.MM.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неправильный формат поля {value}!");
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
