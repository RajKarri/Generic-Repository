namespace Repository.Interfaces
{
    public interface IContext<T> where T : class
    {
        T CurrentContext { get; }
        T GetContext();
    }
}
