using System;

namespace PW.DomainEvent
{
    public class UpdateAccountPasswordEvnet:IUpdatePasswordPropertyEvent
    {
        public Guid AccountId { get; set; }
        public string Password { get; set; }
    }
}