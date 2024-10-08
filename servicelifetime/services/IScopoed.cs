namespace servicelifetime.services
{
    public interface IScopoed
    {
        string getguid();
    }
    public class Scopoed: IScopoed
    {
        public Guid guid;
        public Scopoed()
        {
            guid = Guid.NewGuid();
        }
        public string getguid()
        {
          return  guid.ToString();
        }
    }
}
