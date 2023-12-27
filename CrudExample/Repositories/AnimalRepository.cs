using CrudExample.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private List<Animal> animals = new List<Animal>();

        public void SaveAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public List<Animal> GetAnimals()
        {
            return animals;
        }

        public Animal GetAnimalById(int id)
        {
            return animals.Find(f => f.Id == id);
        }

        public void DeleteAnimal(int id)
        {
            int index = animals.FindIndex(animal => animal.Id == id);
            if (index != -1)
            {
                animals.RemoveAt(index);
            }
            else
            {
                throw new InvalidOperationException("Animal not found");
            }
        }

        public void DeleteAllAnimals()
        {
            animals.Clear();
        }

        public void UpdateAnimal(Animal updatedAnimal)
        {
            int index = animals.FindIndex(animal => animal.Id == updatedAnimal.Id);
            if (index != -1)
            {
                if (string.IsNullOrWhiteSpace(updatedAnimal.Name))
                {
                    // Si es nulo o una cadena vacía, mantener el valor existente
                    updatedAnimal.Name = animals[index].Name;
                }

                animals[index] = updatedAnimal;
            }
            else
            {
                throw new InvalidOperationException("Animal not found");
            }
        }

        public void message(string message)
        {
            Console.WriteLine(message);
        }

        public void AddDataTest()
        {
            DateOnly birthdate = new DateOnly(2015, 10, 21);
            TimeOnly lifeExpectancy = new TimeOnly(8, 20);
            DateTime deathDate = new DateTime(2019, 05, 09, 09, 15, 00);

            Animal animalTest = new Animal
            {
                Name = "Elefante",
                Description = "Un majestuoso elefante",
                Birthdate = birthdate,
                LifeExpectancy = lifeExpectancy,
                Aggressive = false,
                Gender = 'M',
                DeathDate = deathDate
            };

            animals.Add(animalTest);

        }
    }
}
