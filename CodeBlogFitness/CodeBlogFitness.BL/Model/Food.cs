using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Продукт(Еда).
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Название за 100гр.
        /// </summary>
        public string Name { get;  }
        /// <summary>
        /// Белки за 100гр.
        /// </summary>
        public double Proteins { get;  }
        /// <summary>
        /// Жиры за 100гр.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы за 100гр.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории за 100гр.
        /// </summary>
        public double Calorie { get; }
        /// <summary>
        /// Калории за 1гр.
        /// </summary>
        private double CalloriesOneGramm { get { return Calorie / 100.0; } }
        /// <summary>
        /// Белки за 1гр.
        /// </summary>
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        /// <summary>
        /// Жиры за 1гр.
        /// </summary>
        private double FatsOneGramm { get { return Fats / 100.0; } }
        /// <summary>
        /// Углеводы за 1гр.
        /// </summary>
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }


        public Food(string name)
        {
            //TODO: проверка

            Name = name;
        }

        public Food(string name, 
                    double proteins,
                    double fats,
                    double carbohydrates)
        {
            //TODO: проверка
            Name = name;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }
    }
}
