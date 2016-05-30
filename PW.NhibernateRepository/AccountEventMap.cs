using FluentNHibernate.Mapping;

namespace PW.NhibernateRepository
{
    public class AccountEventMap : ClassMap<AccountEvent>
    {
        public AccountEventMap()
        {
            Table("AccountEvent");
            Id(x => x.EventId).GeneratedBy.Assigned();
            Map(x => x.AccountId).Not.Nullable();
            Map(x => x.Event).Not.Nullable();
            Map(x => x.EventType).Not.Nullable();
            Map(x => x.PublishDate).Not.Nullable();
        }
    }
}