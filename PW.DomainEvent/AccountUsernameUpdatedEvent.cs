using System;

namespace PW.DomainEvent
{
    public class AccountUsernameUpdatedEvent: DomainEventBase, IPropertyUsernameUpdatedEvent
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
    }
}