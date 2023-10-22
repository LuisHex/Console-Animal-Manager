using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample
{
    internal class Animal
    {
        private List<Animal> animales = new List<Animal>();

        int Id { get; set; }
        static int lastId = -1;
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected DateOnly Birthdate { get; set; }
        protected TimeOnly LifeExpectancy { get; set; }
        protected bool Aggressive { get; set; }
        private char gender;
        public char Gender /*Public for testing*/
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
        DateTime DeathDate { get; set; }

        public Animal(string name, string description, DateOnly birthdate, TimeOnly lifeExpectancy, bool aggressive, char gender, DateTime deathDate)
        {
            Id = ++lastId;
            Name = name;
            Description = description;
            Birthdate = birthdate;
            LifeExpectancy = lifeExpectancy;
            Aggressive = aggressive;
            Gender = gender;
            DeathDate = deathDate;

        }
        void ListAnimal()
        {
            if (animales.Count == 0)
            {
                Console.WriteLine("No hay animales en la lista.");
            }
            else
            {
                Console.WriteLine("Lista de Animales:");
                foreach (var animal in animales)
                {
                    animal.PrintAttributes();
                }
            }
        }
        void PrintAttributes()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Nombre: " + Name);
            Console.WriteLine("Descripción: " + Description);
            Console.WriteLine("Fecha de nacimiento: " + Birthdate.ToString());
            Console.WriteLine("Expectativa de vida: " + LifeExpectancy.ToString());
            Console.WriteLine("Agresivo: " + Aggressive);
            Console.WriteLine("Género: " + Gender);
            Console.WriteLine("Fecha de muerte: " + DeathDate.ToString());
            Console.WriteLine();
        }
        void PrintAttributes(Animal animalFind)
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

        void AddDataTest()
        {
            DateOnly fechaNacimiento = new DateOnly(2015, 10, 21);
            TimeOnly expectativaVida = new TimeOnly(8, 20);
            DateTime fechaMuerte = new DateTime(2019, 05, 09, 09, 15, 00);

            Animal animal = new Animal("General", "Este es un animal generico", fechaNacimiento, expectativaVida, true, 'M', fechaMuerte);
            animales.Add(animal);

            DateOnly fechaNacimiento2 = new DateOnly(2015, 10, 21);
            TimeOnly expectativaVida2 = new TimeOnly(8, 20);
            DateTime fechaMuerte2 = new DateTime(2019, 05, 09, 09, 15, 00);

            Animal animal2 = new Animal("General", "Este es un animal generico", fechaNacimiento2, expectativaVida2, true, 'M', fechaMuerte2);
            animales.Add(animal2);
        }
        public void PublicAddAnimal()
        {
            AddAnimal();
        }

        public void PublicListAnimal()
        {
            ListAnimal();
        }

        public void PublicPrintAttributes()
        {
            PrintAttributes();
        }

        public void PublicAddDataTest()
        {
            AddDataTest();
        }

        public void PublicClearList()
        {
            ClearList();
        }

        public bool PublicValidateAnimal(int id)
        {
            return OptionValidateAnimal(id);
        }
        public void PublicDeleteAnimal(int id)
        {
            DeleteAnimal(id);
        }
        public void PublicUpdateAnimal(int id)
        {
            UpdateAnimal(id);
        }

        bool OptionValidateAnimal(int? id)
        {
            if (!id.HasValue || id < 0)
            {
                return false;
            }

            bool existId = animales.Any(animal => animal.Id == id);

            return true;
        }
        void DeleteAnimal(int id)
        {
            OptionValidateAnimal(id);
            if (true)
            {
                animales.RemoveAll(animal => animal.Id == id);
                Console.WriteLine("El animal " + id + " se eliminó correctamente.");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al eliminar el animal: ");
            }
        }

        void UpdateAnimal(int id)
        {
            Animal animalSearch = animales.Find(animal => animal.Id == id);

            if (animalSearch != null)
            {
                PrintAttributes(animalSearch);
                string name = ValidateStringInput("Nombre: ");
                string description = ValidateStringInput("Descripción: ");
                DateOnly birthdate = ValidateDateInput("Fecha de Nacimiento (AAAA-MM-DD): ");
                TimeOnly lifeExpectancy = ValidateTimeInput("Expectativa de Vida (HH:MM): ");
                bool aggressive = ValidateBoolInput("Es Agresivo (true/false): ");
                char gender = ValidateGenderInput("Género (M/F): ");
                DateTime deathDate = ValidateDateTimeInput("Fecha de Muerte (AAAA-MM-DD HH:MM:SS): ");

                Console.WriteLine("Ingrese los nuevos atributos para actualizar el animal: ");
                animalSearch.Name = name;
                animalSearch.Description = description;
                animalSearch.Birthdate = birthdate;
                animalSearch.LifeExpectancy = lifeExpectancy;
                animalSearch.Aggressive = aggressive;
                animalSearch.Gender = gender;
                animalSearch.DeathDate = deathDate;
                Console.WriteLine("Animal actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("No existe el ID del animal para actualizar: ");
            }
        }

        void ClearList()
        {
            animales.Clear();
            Console.WriteLine("Se eliminaron los animales");
        }
        void AddAnimal()
        {
            Console.WriteLine("Ingrese los detalles del nuevo animal:");

            string name = ValidateStringInput("Nombre: ");
            string description = ValidateStringInput("Descripción: ");
            DateOnly birthdate = ValidateDateInput("Fecha de Nacimiento (AAAA-MM-DD): ");
            TimeOnly lifeExpectancy = ValidateTimeInput("Expectativa de Vida (HH:MM): ");
            bool aggressive = ValidateBoolInput("Es Agresivo (true/false): ");
            char gender = ValidateGenderInput("Género (M/F): ");
            DateTime deathDate = ValidateDateTimeInput("Fecha de Muerte (AAAA-MM-DD HH:MM:SS): ");

            Animal animal = new Animal(name, description, birthdate, lifeExpectancy, aggressive, gender, deathDate);
            animales.Add(animal);
            Console.WriteLine("Animal agregado con éxito.");
            animal.PrintAttributes();
            Console.ReadLine();
        }

        string ValidateStringInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine("El campo no puede estar vacío.");
            }
        }
        DateOnly ValidateDateInput(string prompt)
        {
            DateOnly date;
            while (true)
            {
                Console.Write(prompt);
                if (DateOnly.TryParse(Console.ReadLine(), out date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Formato de fecha incorrecto. Intente de nuevo.");
                }
            }
        }

        TimeOnly ValidateTimeInput(string prompt)
        {
            TimeOnly time;
            while (true)
            {
                Console.Write(prompt);
                if (TimeOnly.TryParse(Console.ReadLine(), out time))
                {
                    return time;
                }
                else
                {
                    Console.WriteLine("Formato de hora incorrecto. Intente de nuevo.");
                }
            }
        }

        bool ValidateBoolInput(string prompt)
        {
            bool result;
            while (true)
            {
                Console.Write(prompt);
                if (bool.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese 'true' o 'false'.");
                }
            }
        }

        char ValidateGenderInput(string prompt)
        {
            char gender;
            while (true)
            {
                Console.Write(prompt);
                if (char.TryParse(Console.ReadLine(), out gender) && (gender == 'M' || gender == 'F'))
                {
                    return gender;
                }
                else
                {
                    Console.WriteLine("Género debe ser 'M' o 'F'. Intente de nuevo.");
                }
            }
        }

        DateTime ValidateDateTimeInput(string prompt)
        {
            DateTime date;
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Formato de fecha y hora incorrecto. Intente de nuevo.");
                }
            }
        }



    }


}


