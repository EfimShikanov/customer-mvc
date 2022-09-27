using CustomerDatalayer.BusinessEntities;

namespace CustomerDatalayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(Customer entity);
        TEntity Read(int entityId);
        void Update(TEntity entity);
        void Delete(int entityCode);
        List<TEntity> GetAll();
        void DeleteAll();
    }
}