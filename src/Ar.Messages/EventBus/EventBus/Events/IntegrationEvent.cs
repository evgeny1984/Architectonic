using System;
using System.Text.Json.Serialization;

namespace Ar.Messages.EventBus.EventBus.Events
{
    // Integration Events notes: 
    // An Event is “something that has happened in the past”, therefore its name has to be   
    // An Integration Event is an event that can cause side effects to other microsrvices, Bounded-Contexts or external systems.
    public record IntegrationEvent
    {        
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createDate)
        {
            Id = id;
            CreationDate = createDate;
        }

        [JsonInclude]
        public Guid Id { get; private init; }

        [JsonInclude]
        public DateTime CreationDate { get; private init; }
    }
}
