using CrudExample.Clases;
using CrudExample.GetData;
using CrudExample.Repositories;
using CrudExample.Validations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrudExample.Services
{
    internal class AnimalService
    {

        private readonly IAnimalRepository _animalRepository;
        private readonly IInputValidation _inputValidate;
        private readonly IGetDataFromUser<Animal> _animalData;
        public AnimalService(IAnimalRepository animalrepository, IInputValidation inputValidate, IGetDataFromUser<Animal> animalData)
        {
            _animalRepository = animalrepository;
            _inputValidate = inputValidate;
            _animalData = animalData;
        }

        public string AddAnimal(Animal animal)
        {
            try
            {
                _animalRepository.SaveAnimal(animal);
                return "Ticket deleted successfully";
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
        }

        public string PrintAllAnimals(List<Animal> ListAnimals)
        {
            var result = "";
            foreach (var animal in ListAnimals)
            {
                result += $"ID: {animal.Id}, Name: {animal.Name}, Animal Description: {animal.Description}," +
                    $" Birthdate: {animal.Birthdate}, Life Expectancy: {animal.LifeExpectancy}, Agressive: {animal.Aggressive}" +
                    $", Gender: {animal.Gender}, DeathDate: {animal.DeathDate}" +
                    $"  {Environment.NewLine}";
            }
            return result;
        }

        public List<Animal> ListAnimals()
        {
            return _animalRepository.GetAnimals();
        }

        public void PrintAnimal(Animal animalFind)
        {
            Console.WriteLine("Id: " + animalFind.Id);
            Console.WriteLine("Nombre: " + animalFind.Name);
            Console.WriteLine("Descripción: " + animalFind.Description);
            Console.WriteLine("Fecha de nacimiento: " + animalFind.Birthdate.ToString());
            Console.WriteLine("Expectativa de vida: " + animalFind.LifeExpectancy.ToString());
            Console.WriteLine("Agresivo: " + animalFind.Aggressive);
            Console.WriteLine("Género: " + animalFind.Gender);
            Console.WriteLine("Fecha de muerte: " + animalFind.DeathDate.ToString());
            Console.WriteLine();
        }

        public string GetAnimal(int id)
        {
            try
            {
                Animal getAnimal = _animalRepository.GetAnimalById(id);
                if (getAnimal == null)
                {
                    throw new InvalidOperationException("Animal not found");
                }

                PrintAnimal(getAnimal);

                return "Done";
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Failed to get animal", ex);
            }
        }

        public string UpdatedAnimal(Animal updatedAnimal)
        {
            try
            {
                _animalRepository.UpdateAnimal(updatedAnimal); //Falta probarla
                return "Animal updated successfully";
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
        }

        public string DeleteAnimal(int id)
        {
            try
            {
                _animalRepository.DeleteAnimal(id);
                return "Animal deleted successfully";
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
        }

        public void DataTest()
        {
            _animalRepository.AddDataTest();
        }

        public void ClearList()
        {
            _animalRepository.DeleteAllAnimals();
        }
    }
}
