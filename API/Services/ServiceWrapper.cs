using API.Interfaces.Services;
using App.Domain.Interfaces.Integrations.V1;
using App.Domain.Interfaces.Kernels;
using AutoMapper;

namespace API.Services
{
    public class ServiceWrapper(IServiceProvider serviceProvider) : IServiceWrapper
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public IExceptionNotificationKernel ExceptionNotification => GetService<IExceptionNotificationKernel>();

        public IMapper Mapper => GetService<IMapper>();

        public IViaCepIntegration ViaCepIntegration => GetService<IViaCepIntegration>();

        private TService GetService<TService>() => _serviceProvider.GetService<TService>();
    }
}
