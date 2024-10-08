



using Microsoft.EntityFrameworkCore;

namespace Business_acess_lyer.repositories
{
    public class Employee_repositories : GenericRepositories<employee>, IEmployee_repositories
    {
        public Employee_repositories(datacontextcs dbcontext) : base(dbcontext)
        {
            
        }

        public IEnumerable<employee> Getall(string address)
        {
           return _dbset.Where(e => e.address.ToLower().Contains(address.ToLower())).Include(e => e.department).ToList();
        }
       public IEnumerable<employee> getallwithdepartment()
        {
            return _dbset.Include(e => e.department).ToList();
        }
    }
}