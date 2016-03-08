namespace CustomerManagement.DAL.UnitOfWork.Utils
{
    public interface IEntitySavedValidator
    {
        bool IsEntitySaved(object entity);
    }
}