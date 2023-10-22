using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample
{
    internal class Dog : Race
    {
        public Dog(string name, string description, DateOnly birthdate, TimeOnly lifeExpectancy, bool aggressive, char gender, DateTime deathDate) : base(name, description, birthdate, lifeExpectancy, aggressive, gender, deathDate)
        {
        }

        int Edad { get; set; }
        string? Fur {  get; set; } /*Pelo*/
        string? ImagenUrl { get; set; }

    }
}
