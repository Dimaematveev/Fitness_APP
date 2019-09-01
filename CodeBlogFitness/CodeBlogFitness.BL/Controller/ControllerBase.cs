using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public abstract class ControllerBase<T> where T:class
    {
        protected IDataSaver<T> manager = new DatabaseDataSaver<T>();
        protected void Save(T item)
        {
            manager.Save(item);
        }
        protected List<T> Load() 
        {
            return manager.Load();
        }
    }
}
