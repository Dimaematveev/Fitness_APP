﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        /// <summary>
        /// Момент приема пищи.
        /// </summary>
        public DateTime Moment { get; set; }
        /// <summary>
        /// Список продуктов приема!
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }
        
        public int UserId { get; set; }
        /// <summary>
        /// Кто ел.
        /// </summary>
        public virtual User User { get; set; }

        public Eating(User user)
        {

            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым!",nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public Eating()
        {
        }

        /// <summary>
        /// Добавить продукт что съели и сколько!
        /// </summary>
        /// <param name="food">Продукт.</param>
        /// <param name="weight">Вес в граммах.</param>
        public void Add(Food food,
                        double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product==null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }

        }
    }
}
