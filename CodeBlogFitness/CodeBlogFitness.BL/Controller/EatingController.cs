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
    /// Контроллер приема пищи!
    /// </summary>
    public class EatingController
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;
        /// <summary>
        /// Список продуктов!
        /// </summary>
        public List<Food> Foods { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(user));
            Foods = GetAllFoods();
        }

        private List<Food> GetAllFoods()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("foods.dat", FileMode.OpenOrCreate))
            {

                if (fs.Length > 0 && formatter.Deserialize(fs) is List<Food> foods)
                {
                    return foods;
                }
                else
                {
                    return new List<Food>();
                }

            }
        }

        private 
    }
}
