using System;

namespace PW.DomainEvent
{
    public class UpdateAccountUsernameEvent:IUpdateUsernamePropertyEvent
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
    }
}