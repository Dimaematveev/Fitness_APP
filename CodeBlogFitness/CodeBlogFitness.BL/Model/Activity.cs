using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public double CalloriesPerMinute { get; set; }
        public Activity(string name, double calloriesPerMinute)
        {
            //TODO: Проверки
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не должно быть пустым!", nameof(name));
            }

            Name = name;
            CalloriesPerMinute = calloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
