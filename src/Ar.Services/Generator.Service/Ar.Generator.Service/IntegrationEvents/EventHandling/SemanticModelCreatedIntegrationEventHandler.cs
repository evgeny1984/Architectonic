using Ar.Generator.Repository.Wrapper;
using Ar.Generator.Service.Properties;
using Ar.Messages.EventBus.EventBus.Abstractions;
using Architect.Dto.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ar.Generator.Service.IntegrationEvents.EventHandling
{
    public class SemanticModelCreatedIntegrationEventHandler : IIntegrationEventHandler<SemanticModelCreatedIntegrationEvent>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILogger<SemanticModelCreatedIntegrationEventHandler> _logger;

        public SemanticModelCreatedIntegrationEventHandler(IRepositoryWrapper wrapper, ILogger<SemanticModelCreatedIntegrationEventHandler> logger)
        {
            _repositoryWrapper = wrapper ?? throw new ArgumentNullException(nameof(wrapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(SemanticModelCreatedIntegrationEvent @event)
        {
            //_logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Resources.AppName);

            await _repositoryWrapper.Solution.CreateAsync(@event.Solution);
        }
    }
}
