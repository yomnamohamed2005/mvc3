namespace servicelifetime.services
{
    public interface ISingleton
    { 
        string getguid();
    }
    public class Singleton : ISingleton
    {
        public Guid guid;
        public Singleton()
        {
            guid = Guid.NewGuid();
        }
        public string getguid()
        {
            return guid.ToString();
        }
    }
}

