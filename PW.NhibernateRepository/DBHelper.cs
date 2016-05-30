using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using PW.DomainEvent;

namespace PW.NhibernateRepository
{
    public class DBHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                  .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("PW")))
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AccountEventMap>())
                  .BuildSessionFactory();
        }

        public static void CreateTables()
        {
            Fluently.Configure()
                  .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("PW")))
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AccountEventMap>()).ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false)).BuildSessionFactory().OpenSession().Close();
        }

        public static void Seed()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var accountId = new Guid("9425cb8e-d836-483c-8749-f882a6b00011");
                    var evt = new AccountEvent
                    {
                        EventId = Guid.NewGuid(),
                        AccountId = accountId
                    };
                    var accountCreatedEvent = new AccountCreatedEvent()
                    {
                        Username = "PeterLee",
                        Password = "123456",
                        DomainId= accountId,
                        EventId = evt.EventId
                    };
                    evt.Event = JsonConvert.SerializeObject(accountCreatedEvent);
                    evt.EventType = typeof(AccountCreatedEvent).ToClassFullName();
                    evt.PublishDate = DateTime.Now;
                    session.SaveOrUpdate(evt);

                    evt = new AccountEvent
                    {
                        EventId = Guid.NewGuid(),
                        AccountId = accountId
                    };
                    var accountPasswordUpdatedEvnet = new AccountPasswordUpdatedEvnet()
                    {
                        Password = "456789",
                        DomainId = accountId,
                        EventId = evt.EventId
                    };
                    evt.Event = JsonConvert.SerializeObject(accountPasswordUpdatedEvnet);
                    evt.EventType = typeof(AccountPasswordUpdatedEvnet).ToClassFullName();
                    evt.PublishDate = DateTime.Now.AddHours(1);
                    session.SaveOrUpdate(evt);

                    transaction.Commit();
                }
            }
        }
    }

    public static class Extension
    {
        public static string ToClassFullName(this Type type)
        {
            return type.AssemblyQualifiedName.Substring(0, type.AssemblyQualifiedName.IndexOf(", Version"));
        }
    }
}
