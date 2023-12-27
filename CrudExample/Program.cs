using CrudExample.Clases;
using CrudExample.GetData;
using CrudExample.Repositories;
using CrudExample.Services;
using CrudExample.Validations;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Example application CRUD");
var serviceProvider = new ServiceCollection()
              .AddTransient<IAnimalRepository, AnimalRepository>()
              .AddTransient<IInputValidation, InputValidation>()
              .AddTransient<IGetDataFromUser<Animal>, AnimalData>()
              .AddTransient<AnimalService>()
              .BuildServiceProvider();

var _animalService = serviceProvider.GetService<AnimalService>();
var _animalRepository = serviceProvider.GetService<IAnimalRepository>();
var _animalData = serviceProvider.GetService<IGetDataFromUser<Animal>>();
var _input = serviceProvider.GetService<IInputValidation>();
//Animal data test.
_animalService.DataTest();

while (true)
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Agregar un Animal");
    Console.WriteLine("2. Listar Animales");
    Console.WriteLine("3. Actualizar Animales");
    Console.WriteLine("4. Eliminar Animales");
    Console.WriteLine("5. Salir");
    int option = _input.OptionValidate();

    switch (option)
    {

        case 1:
            Animal animalFromUser = _animalData.GetDataFromUser();
            _animalService.AddAnimal(animalFromUser);
            _animalService.PrintAnimal(animalFromUser);
            Console.WriteLine("Animal agregado con exito. \n");
            Console.ReadKey();

            break;
        case 2:
            List<Animal> listAnimals = _animalService.ListAnimals();
            Console.WriteLine(_animalService.PrintAllAnimals(listAnimals));
            break;
        case 3:
            Console.WriteLine("Ingrese un ID del animal para actualizar: ");
             int idAnimalUpdated = _input.OptionValidate();
            _animalService.GetAnimal(idAnimalUpdated);
            Animal animalUpdatedFromUser = _animalData.GetDataFromUser();
            _animalService.UpdatedAnimal(animalUpdatedFromUser);
            break;
        case 4:
            Console.WriteLine("Ingrese una opcion: ");
            Console.WriteLine("1. Eliminar un animal ");
            Console.WriteLine("2. Eliminar todos los animales ");
            int optionDelete = _input.OptionValidate();

            if (optionDelete == 1)
            {
                Console.WriteLine("Ingrese un ID del animal a eliminar: ");
                int idAnimalDelete = _input.OptionValidate();
                _animalService.GetAnimal(idAnimalDelete);
                _animalService.DeleteAnimal(idAnimalDelete);
                Console.WriteLine("Animal eliminado correctamente ");
                break;
            }
            else if (optionDelete == 2)
            {
                _animalService.ClearList();
                Console.WriteLine("Lista de animales limpiados ");
                break;
            }
            else
            {
                Console.WriteLine("Opcion no valida.");
                break;
            }
        case 5:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            break;
    }
}
