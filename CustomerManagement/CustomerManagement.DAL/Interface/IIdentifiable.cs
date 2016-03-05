using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Interface
{
    public interface IIdentifiable<T> where T : struct
    {
        T Id { get; set; }
    }
}
