using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.NhibernateRepository
{
    public class AccountEvent
    {
        public virtual Guid EventId { get; set; }

        public virtual Guid AccountId { get; set; }

        public virtual string Event { get; set; }

        public virtual string EventType { get; set; }

        public virtual DateTime PublishDate { get; set; }
    }
}
