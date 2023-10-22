using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample
{
    internal class Race : Animal
    {
        public Race(string name, string description, DateOnly birthdate, TimeOnly lifeExpectancy, bool aggressive, char gender, DateTime deathDate) : base(name, description, birthdate, lifeExpectancy, aggressive, gender, deathDate)
        {
        }

        //public Race(int id, string nombre, string description, DateOnly birthdate, TimeOnly lifeExpectancy, bool aggressive, char gender, DateTime deathDate) : base(id, nombre, description, birthdate, lifeExpectancy, aggressive, gender, deathDate)
        //{
        //}

        int Id { get; set; }
        string? Origin { get; set; }
        protected string? Cluster { get; set; }/* Grupo*/


    }
}
