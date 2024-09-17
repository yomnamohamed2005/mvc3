using Data_access_lyer.models;

namespace Business_acess_lyer.repositories
{
    public interface Idata_repositories
    {
        int create(department entity);
        int delete(department entity);
        department Get(int id);
        IEnumerable<department> Getall();
        int update(department entity);
    }
}