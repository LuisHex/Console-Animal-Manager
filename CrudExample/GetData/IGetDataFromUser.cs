using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample.GetData
{
    public interface IGetDataFromUser<T>
    {
        T GetDataFromUser();
    }
}
