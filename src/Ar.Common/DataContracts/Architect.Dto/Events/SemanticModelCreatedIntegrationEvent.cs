using Ar.Messages.EventBus.EventBus.Events;
using Architect.Dto.Dto;

namespace Architect.Dto.Events
{

    public record SemanticModelCreatedIntegrationEvent : IntegrationEvent
    {
        public SolutionDto Solution { get; private init; }

    public SemanticModelCreatedIntegrationEvent(SolutionDto solution)
    {
        Solution = solution;
    }
}
}
