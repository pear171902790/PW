using System;

namespace PW.DomainEvent
{
    public class AccountCreatedEvent :DomainEventBase, IPropertyPasswordUpdatedEvent, IPropertyUsernameUpdatedEvent
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}