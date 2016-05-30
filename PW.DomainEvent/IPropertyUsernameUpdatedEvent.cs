namespace PW.DomainEvent
{
    public interface IPropertyUsernameUpdatedEvent : IDomainEvent
    {
        string Username { get; set; }
    }
}