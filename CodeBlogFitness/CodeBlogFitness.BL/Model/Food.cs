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
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        /// <summary>
        /// Название за 1гр.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Белки за 1гр.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры за 1гр.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы за 1гр.
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Калории за 1гр.
        /// </summary>
        public double Calorie { get; set; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name,
                    double calorie,
                    double proteins,
                    double fats,
                    double carbohydrates)
        {
            //TODO: проверка
            Name = name;
            Calorie = calorie / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public Food()
        {
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
