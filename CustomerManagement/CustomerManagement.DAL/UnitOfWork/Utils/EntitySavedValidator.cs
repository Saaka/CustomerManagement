using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.UnitOfWork.Utils
{
    public class EntitySavedValidator : IEntitySavedValidator
    {
        public bool IsEntitySaved(object entity)
        {
            if (entity is Interface.IIdentifiable<Guid>)
                return (entity as Interface.IIdentifiable<Guid>).Id != Guid.Empty;
            else
                throw new ArgumentException("Unsupported entity identity type");
        }
    }
}
