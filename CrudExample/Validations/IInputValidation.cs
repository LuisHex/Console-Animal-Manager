using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample.Validations
{
    public interface IInputValidation
    {
        string ValidateStringInput(string prompt);

        DateOnly ValidateDateInput(string prompt);

        TimeOnly ValidateTimeInput(string prompt);

        bool ValidateBoolInput(string prompt);

        char ValidateGenderInput(string prompt);

        DateTime ValidateDateTimeInput(string prompt);

        int OptionValidate();

        string ValidateConfirmation();
    }
}
