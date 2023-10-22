using CrudExample;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
Console.WriteLine("Application CRUD");
Animal animal = new Animal(default, default, default, default, default, default, default);
animal.PublicAddDataTest();


while (true)
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Agregar un Animal");
    Console.WriteLine("2. Listar Animales");
    Console.WriteLine("3. Actualizar Animales");
    Console.WriteLine("4. Eliminar Animales");
    Console.WriteLine("5. Salir");
    int option = OptionValidate();

    switch (option)
    {

        case 1:
            animal.PublicAddAnimal();
            break;
        case 2:
            animal.PublicListAnimal();
            break;
        case 3:
            Console.WriteLine("Ingrese un ID del animal para actualizar: ");
            int optionUpdateAnimal = OptionValidate();
            animal.PublicUpdateAnimal(optionUpdateAnimal);
            //Console.WriteLine("Animal eliminado correctamente ");
            break;
        case 4:
            Console.WriteLine("Ingrese una opcion: ");
            Console.WriteLine("1. Eliminar un animal ");
            Console.WriteLine("2. Eliminar todos los animales ");
            int optionResult = OptionValidate();
            if (optionResult == 1)
            {
                Console.WriteLine("Ingrese un ID del animal a eliminar: ");
                int optionSearchAnimal = OptionValidate();
                animal.PublicDeleteAnimal(optionSearchAnimal);
                Console.WriteLine("Animal eliminado correctamente ");
                break;
            }
            else if (optionResult == 2)
            {
                animal.PublicClearList();
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
int OptionValidate()
{
    string optionInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(optionInput) && int.TryParse(optionInput, out int valorEntero))
    {
        return valorEntero;
    }
    else
    {
        return -1;
    }
}
string ValidateConfirmation()
{
    while (true)
    {
        string input = Console.ReadLine().Trim().ToLower();
        if (!string.IsNullOrWhiteSpace(input) && (input == "si" || input == "no"))
        {
            return input;
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor, escribe 'Si' o 'No': ");
        }
    }
}