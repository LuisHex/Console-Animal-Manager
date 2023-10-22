using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample
{
    internal class Cat : Race
    {
        public Cat(string name, string description, DateOnly birthdate, TimeOnly lifeExpectancy, bool aggressive, char gender, DateTime deathDate) : base(name, description, birthdate, lifeExpectancy, aggressive, gender, deathDate)
        {
        }

        int Id { get; set; }
        string? Color { get; set; }
        string? ImagenUrl { get; set; }


    }
}
