namespace Repository.Contexts
{
    using System;
    using Repository.Interfaces;
    using SourceContexts;

    public class FileSystemContext<T> : IContext<FileSystemSourceContext>
    {
        private string key = string.Empty;

        public FileSystemContext(string key)
        {
            this.key = key;
        }

        public FileSystemSourceContext CurrentContext
        {
            get
            {
                return this.GetContext();
            }
        }

        public FileSystemSourceContext GetContext()
        {
            // Use key or T or both to get the context
            // Implement logic to return API source context
            throw new NotImplementedException();
        }
    }
}
