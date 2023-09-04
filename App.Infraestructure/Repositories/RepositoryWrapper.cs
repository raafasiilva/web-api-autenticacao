using App.Domain.Interfaces.Repositories;
using App.Domain.Interfaces.Repositories.V1;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infraestructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryWrapper(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider;

        public IAddressRepository Address => GetRepository<IAddressRepository>();

        private TRepository GetRepository<TRepository>() => _serviceProvider.GetService<TRepository>();
    }
}
