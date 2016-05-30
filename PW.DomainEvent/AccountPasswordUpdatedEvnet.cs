using System;

namespace PW.DomainEvent
{
    public class AccountPasswordUpdatedEvnet: DomainEventBase, IPropertyPasswordUpdatedEvent
    {
        public string Password { get; set; }
    }
}