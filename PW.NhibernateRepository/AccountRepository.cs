using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NHibernate.Linq;
using PW.Domain;
using PW.DomainEvent;

namespace PW.NhibernateRepository
{
    public class AccountRepository
    {
        public Account Get(Guid accountId)
        {
            var account=new Account() {AccountId = accountId};
            var sessionFactory = DBHelper.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                var list = session.Query<AccountEvent>().Where(x => x.AccountId == accountId).OrderBy(x=>x.PublishDate).ToList();
                list.ForEach(x =>
                {
                    var type = Type.GetType(x.EventType);
                    var evt = JsonConvert.DeserializeObject<dynamic>(x.Value);
                    
                    if (typeof(IUpdateUsernamePropertyEvent).IsAssignableFrom(type))
                    {
                        account.Username = evt.Username;
                    }
                    if (typeof(IUpdatePasswordPropertyEvent).IsAssignableFrom(type))
                    {
                        account.Password = evt.Password;
                    }
                });
            }

            return account;
        }
    }
}
