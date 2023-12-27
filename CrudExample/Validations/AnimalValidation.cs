using CrudExample.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample.Validations
{
    internal class AnimalValidation
    {
        public void PublicValidateAnimal(int id) //return bool estaba 
        {
            //return OptionValidateAnimal(id);
        }
        public void PublicDeleteAnimal(int id)
        {
            //DeleteAnimal(id);
        }
        public void PublicUpdateAnimal(int id)
        {
            //UpdatedAnimal(id);
        }

        //bool OptionValidateAnimal(int? id)
        //{
        //    if (!id.HasValue || id < 0)
        //    {
        //        return false;
        //    }

        //    bool existId = animales.Any(animal => animal.Id == id);

        //    return true;
        //}
    }
}
