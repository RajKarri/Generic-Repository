using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Repository.SourceContexts;

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
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot Configuration = builder.Build();
            sourceContext.Uri = Configuration[key];
            sourceContext.Uri = sourceContext.Uri != null ? sourceContext.Uri.TrimEnd(new char[] { '/', '\\' }) : null;
            return sourceContext;
        }
    }
}
