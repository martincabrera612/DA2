namespace DI.WebApi.Services
{
    public sealed class Service : ITransientService, IScopeService, ISingletonService
    {
        private readonly IDependency _dependency;
        private readonly Guid _token = Guid.NewGuid();

        public Service(IDependency dependency)
        {
            _dependency = dependency;
        }

        public Guid GetToken()
        {
            return _token;
        }
    }
}
