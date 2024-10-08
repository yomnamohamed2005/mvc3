


namespace Business_acess_lyer.interfaces
{
    public interface IEmployee_repositories :IGenericRepositories<employee>
    {
        IEnumerable<employee> Getall(string address);
        IEnumerable<employee> getallwithdepartment();
    }
}
