using System;

namespace PW.DomainEvent
{
    public interface IUpdateUsernamePropertyEvent
    {
        string Username { get; set; }
    }

    public interface IUpdatePasswordPropertyEvent
    {
        string Password { get; set; }
    }

    public class CreateAccountEvent:IUpdatePasswordPropertyEvent,IUpdateUsernamePropertyEvent
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}