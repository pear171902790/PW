namespace PW.DomainEvent
{
    public interface IPropertyPasswordUpdatedEvent : IDomainEvent
    {
        string Password { get; set; }
    }
}