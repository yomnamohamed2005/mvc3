using servicelifetime.services;

namespace servicelifetime.services
{
    public interface ITransient
    {

        string getguid();
}
   public class Transient : ITransient
{
    public Guid guid;
    public    Transient()
    {
        guid = Guid.NewGuid();
    }
    public string getguid()
    {
        return guid.ToString();
    }
}
}
