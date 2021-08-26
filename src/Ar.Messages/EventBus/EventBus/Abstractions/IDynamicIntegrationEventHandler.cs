using System.Threading.Tasks;

namespace Ar.Messages.EventBus.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
