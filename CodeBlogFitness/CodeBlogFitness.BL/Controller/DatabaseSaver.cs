using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Сохранение и загрузка данных через БД!
    /// </summary>
    public class DatabaseSaver : IDataSaver
    {
        /// <summary>
        /// Загрузить данные!
        /// </summary>
        /// <typeparam name="T">Тип данных которые загрузятся!</typeparam>
        /// <returns>Список данных.</returns>
        public List<T> Load<T>() where T : class
        {
            using (var db= new FitnessContext())
            {
                var result = db.Set<T>().Where(t=>true).ToList();
                return result;
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        /// <typeparam name="T">Тип данных которые сохранится!</typeparam>
        /// <param name="item">Список данных.</param>
        public void Save<T>(List<T> item) where T : class
        {
            
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
