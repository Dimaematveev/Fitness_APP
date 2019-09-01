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
    /// Базовый контроллер. Для сохранения и загрузки данных!
    /// </summary>
    public abstract class ControllerBase
    {
        /// <summary>
        /// Класс из которого будет вызываться методы сохранения и загрузки!
        /// </summary>
        private readonly IDataSaver manager = new DatabaseSaver();
        /// <summary>
        /// Метод для сохранения элементов.
        /// </summary>
        /// <typeparam name="T">Тип который будем сохранять.</typeparam>
        /// <param name="item">Коллекция элементов которые сохраняем.</param>
        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }
        /// <summary>
        /// Метод для загрузки элементов.
        /// </summary>
        /// <typeparam name="T">Тип который будем сохранять.</typeparam>
        /// <returns>Коллекция элементов которые загружаем.</returns>
        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
