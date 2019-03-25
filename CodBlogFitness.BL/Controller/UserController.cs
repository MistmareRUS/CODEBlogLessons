using CodBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер польлзователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Рользователь приложения.
        /// </summary>
        public User User { get; }
        public UserController(string userName,string genderName,DateTime birthDay,double weight,double height)
        {//TODO: проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                //TODO: что делать, если пользователя не прочитали
            }
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using(var fs=new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        
    }
}
