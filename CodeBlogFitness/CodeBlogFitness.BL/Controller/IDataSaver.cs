using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Интерфейс сохранения и загрузки коллекций из данных(текст, БД)!
    /// </summary>
    public interface IDataSaver
        
    {
        /// <summary>
        /// Метод для сохранения элементов.
        /// </summary>
        /// <typeparam name="T">Тип который будем сохранять.</typeparam>
        /// <param name="item">Коллекция элементов которые сохраняем.</param>
        void Save<T>(List<T> item) where T : class;
        /// <summary>
        /// Метод для загрузки элементов.
        /// </summary>
        /// <typeparam name="T">Тип который будем сохранять.</typeparam>
        /// <returns>Коллекция элементов которые загружаем.</returns>
        List<T> Load<T>() where T : class;

    }
}
