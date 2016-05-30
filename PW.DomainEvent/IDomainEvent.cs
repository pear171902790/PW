using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PW.DomainEvent
{
    public interface IDomainEvent
    {
        
    }


    public abstract class DomainEventBase:IDomainEvent
    {
        public Guid EventId { get; set; }
        public Guid DomainId { get; set; }
    }
}
