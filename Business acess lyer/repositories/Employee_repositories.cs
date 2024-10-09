



using Microsoft.EntityFrameworkCore;

namespace Business_acess_lyer.repositories
{
    public class Employee_repositories : GenericRepositories<employee>, IEmployee_repositories
    {
        public Employee_repositories(datacontextcs dbcontext) : base(dbcontext)
        {
            
        }

        public IEnumerable<employee> Getall(string name)
        {
           return _dbset.Where(e => e.name.ToLower().Contains(name.ToLower())).Include(e => e.department).ToList();
        }
       public IEnumerable<employee> getallwithdepartment()
        {
            return _dbset.Include(e => e.department).ToList();
        }
    }
}