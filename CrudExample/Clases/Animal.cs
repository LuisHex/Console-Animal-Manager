using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample.Clases
{
    public class Animal
    {
        public int Id { get; set; }
        //public static int lastId = -1;
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly Birthdate { get; set; }
        public TimeOnly LifeExpectancy { get; set; }
        public bool Aggressive { get; set; }
        public char gender;
        public char Gender /*testing*/
        {
            get { return gender; }
            set
            {
                if (value == 'M' || value == 'F' || value == default)
                {
                    gender = value;
                }
                else
                {
                    throw new ArgumentException("El género debe ser 'M' o 'F'.");
                }
            }
        }
        public DateTime DeathDate { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Name}, Descripción: {Description}, " +
                   $"Fecha de Nacimiento: {Birthdate}, Expectativa de Vida: {LifeExpectancy}, " +
                   $"Género: {Gender}, Fecha de Muerte: {DeathDate}, " +
                   $"Agresivo: {Aggressive}";
        }

    }


}


