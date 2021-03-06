﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        public User()
        {

        }
        #endregion
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол./param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя должно быть заполненым.",nameof(name));
            }
            if (gender==null)
            {
                throw new ArgumentNullException("Необходимо указать пол.", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900")||birthDate>DateTime.Now)
            {
                throw new ArgumentException("Дата рождения указана некорректно.", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес должен быть выше 0.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Рост должен быть выше 0.", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Необходимо заполнить имя", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name+" "+Age;
        }
    }
}
