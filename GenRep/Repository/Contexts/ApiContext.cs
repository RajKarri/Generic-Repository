using Repository.Interfaces;
using Repository.SourceContexts;
using System.Configuration;

namespace Repository.Contexts
{
    public class ApiContext<T> : IContext<ApiSourceContext>
    {
        private ApiSourceContext apiSourceContext = null;
        private string key = string.Empty;        

        public ApiContext(string url)
        {
            this.key = url;
            this.apiSourceContext = GetContext();
        }

        public ApiSourceContext CurrentContext
        {
            get
            {
                return this.apiSourceContext;
            }
        }

        public ApiSourceContext GetContext()
        {
            ApiSourceContext sourceContext = new ApiSourceContext();
            sourceContext.Uri = ConfigurationManager.AppSettings[key];
            return sourceContext;
        }
    }
}
