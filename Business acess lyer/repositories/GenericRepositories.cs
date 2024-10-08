

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Business_acess_lyer.repositories
{
    public class GenericRepositories<TEntity> :IGenericRepositories<TEntity>  where TEntity : class
    {
        //ctor injection
        private  datacontextcs _datacontext;
       protected DbSet<TEntity> _dbset;
        public GenericRepositories(datacontextcs dbcontext)
        {
            _datacontext = dbcontext;
            _dbset = dbcontext.Set<TEntity>();
        }
        public TEntity? Get(int id)
        {
            return _dbset.Find(id);
        }
        public IEnumerable<TEntity> Getall()
       
             => _dbset.ToList();
        
        public void create(TEntity entity)
        {
            _dbset.Add(entity);
            
        }
        public void update(TEntity entity)
        {
            _dbset.Update(entity);
         
           
        }
        public void delete(TEntity entity)
        {
            _dbset.Remove(entity);
          
        }
    }
}
