using WcfService.Interfaces;

namespace Repository.SourceContexts
{
    public class ServiceSourceContext<T> where T : class
    {
        public IServiceProxy<T> ServiceProxy { get; set; }
    }
}
