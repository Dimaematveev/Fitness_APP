using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    public class Gender
    {
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"Имя пола не должно быть пустым или null!",nameof(name));
            }
            Name = name;
        }

        public string Name { get; }
    }
}
