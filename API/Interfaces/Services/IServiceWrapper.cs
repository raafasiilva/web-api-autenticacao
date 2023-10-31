using App.Domain.Interfaces.Integrations.V1;
using App.Domain.Interfaces.Kernels;
using AutoMapper;

namespace API.Interfaces.Services
{
    public interface IServiceWrapper
    {
        IExceptionNotificationKernel ExceptionNotification { get; }
        IMapper Mapper { get; }
        IViaCepIntegration ViaCepIntegration { get; }
    }
}