

namespace Business_acess_lyer.interfaces
{
    public interface IGenericRepositories<TEntity>
    {
        void create(TEntity entity);
        void delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> Getall();
        void update (TEntity entity);
    }
}
