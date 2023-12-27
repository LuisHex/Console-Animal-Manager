using CrudExample.Clases;
using CrudExample.Repositories;
using CrudExample.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrudExample.GetData
{
    internal class AnimalData : IGetDataFromUser<Animal>
    {
        private readonly IInputValidation _inputValidate;


        public AnimalData(IInputValidation inputValidate)
        {
            _inputValidate = inputValidate;

        }

        public Animal GetDataFromUser()
        {
            //Console.WriteLine("Ingrese los detalles del nuevo animal:");

            string name = _inputValidate.ValidateStringInput("Nombre: ");
            string description = _inputValidate.ValidateStringInput("Descripción: ");
            DateOnly birthdate = _inputValidate.ValidateDateInput("Fecha de Nacimiento (AAAA-MM-DD): ");
            TimeOnly lifeExpectancy = _inputValidate.ValidateTimeInput("Expectativa de Vida (HH:MM): ");
            bool aggressive = _inputValidate.ValidateBoolInput("Es Agresivo (true/false): ");
            char gender = _inputValidate.ValidateGenderInput("Género (M/F): ");
            DateTime deathDate = _inputValidate.ValidateDateTimeInput("Fecha de Muerte (AAAA-MM-DD HH:MM:SS): ");

            Animal newAnimal = new Animal
            {
                Name = name,
                Description = description,
                Birthdate = birthdate,
                LifeExpectancy = lifeExpectancy,
                Aggressive = aggressive,
                Gender = gender,
                DeathDate = deathDate
            };
            return newAnimal;
        }

    }
}

