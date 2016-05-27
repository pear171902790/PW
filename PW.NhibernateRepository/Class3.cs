using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace PW.NhibernateRepository
{
    public class AccountEvent
    {
        public virtual Guid EventId { get; set; }

        public virtual Guid AccountId { get; set; }

        public virtual string Value { get; set; }

        public virtual string EventType { get; set; }

        public virtual DateTime PublishDate { get; set; }
    }

    public class CreateAccountEvent
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UpdateAccountUsernameEvent
    {
        public Guid AccountId { get; set; }
        public string NewUsername { get; set; }
    }

    public class UpdateAccountPasswordEvnet
    {
        public Guid AccountId { get; set; }
        public string NewPassword { get; set; }
    }

    public class AccountEventMap : ClassMap<AccountEvent>
    {
        public AccountEventMap()
        {
            Table("AccountEvent");
            Id(x => x.EventId).GeneratedBy.Assigned();
            Map(x => x.AccountId).Not.Nullable();
            Map(x => x.Value).Not.Nullable();
            Map(x => x.EventType).Not.Nullable();
            Map(x => x.PublishDate).Not.Nullable();
        }
    }
}
