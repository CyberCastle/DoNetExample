using DoNetExample.Persistence.mappings;
using DoNetExample.Persistence.model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Persistence.connection
{
    public abstract class AbstractSessionHandler
    {
        protected ISessionFactory CreateSessionFactory()
        {
            ISessionFactory isessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString("Server=.; Database=DotNetExample; Integrated Security=SSPI;"))
                .Mappings(m => m.FluentMappings.Add<CustomerMap>())
                .Mappings(m => m.FluentMappings.Add<DeviceMap>())
                .BuildSessionFactory();
            return isessionFactory;
        }
    }
}
