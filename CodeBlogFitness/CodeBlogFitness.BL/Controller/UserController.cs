using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public class UserController
    {
        public User User { get; }
        public UserController (User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException("Пользователь не может быть равен null!",nameof(user));
            }
            User = user;
        }
        public bool Save()
        {

        }
    }
}
