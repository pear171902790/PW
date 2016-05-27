﻿using System;
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

namespace PW.NhibernateRepository
{
    [TestFixture]
    public class TestDB
    {
        [Test]
        public void CreateDB()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var accountId = new Guid("9425cb8e-d836-483c-8749-f882a6b00011");
                    var evt = new AccountEvent();
                    evt.EventId=Guid.NewGuid();
                    evt.AccountId = accountId;
                    var createAccountEvent = new CreateAccountEvent()
                    {
                        AccountId = accountId,Username = "aa",Password = "bb"
                    };
                    evt.Value = JsonConvert.SerializeObject(createAccountEvent);
                    evt.EventType = "CreateAccountEvent";
                    evt.PublishDate=DateTime.Now;
                    session.SaveOrUpdate(evt);
                    transaction.Commit();
                }
            }
        }

        [Test]
        public void UpdatePassword()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var accountId = new Guid("9425cb8e-d836-483c-8749-f882a6b00011");
                    var evt = new AccountEvent();
                    evt.EventId = Guid.NewGuid();
                    evt.AccountId = accountId;
                    var createAccountEvent = new UpdateAccountPasswordEvnet()
                    {
                        AccountId = accountId,
                        NewPassword = "cc"
                    };
                    evt.Value = JsonConvert.SerializeObject(createAccountEvent);
                    evt.EventType = "UpdateAccountPasswordEvnet";
                    evt.PublishDate = DateTime.Now;
                    session.SaveOrUpdate(evt);
                    transaction.Commit();
                }
            }
        }

        [Test]
        public void UpdateUsername()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var accountId = new Guid("9425cb8e-d836-483c-8749-f882a6b00011");
                    var evt = new AccountEvent();
                    evt.EventId = Guid.NewGuid();
                    evt.AccountId = accountId;
                    var createAccountEvent = new UpdateAccountUsernameEvent()
                    {
                        AccountId = accountId,
                        NewUsername = "dd"
                    };
                    evt.Value = JsonConvert.SerializeObject(createAccountEvent);
                    evt.EventType = "UpdateAccountUsernameEvent";
                    evt.PublishDate = DateTime.Now;
                    session.SaveOrUpdate(evt);
                    transaction.Commit();
                }
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                  .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c=>c.FromConnectionStringWithKey("PW")))
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AccountEventMap>())
//                  .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
                  .BuildSessionFactory();
        }
    }
}
