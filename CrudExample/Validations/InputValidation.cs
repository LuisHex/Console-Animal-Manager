using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CrudExample.Validations.InputValidation;

namespace CrudExample.Validations
{
    internal class InputValidation : IInputValidation
    {
        public string ValidateStringInput(string prompt)
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

        public DateOnly ValidateDateInput(string prompt)
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

        public TimeOnly ValidateTimeInput(string prompt)
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

        public bool ValidateBoolInput(string prompt)
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

        public char ValidateGenderInput(string prompt)
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

        public DateTime ValidateDateTimeInput(string prompt)
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

        public int OptionValidate()
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

        public string ValidateConfirmation()
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
    }

}


