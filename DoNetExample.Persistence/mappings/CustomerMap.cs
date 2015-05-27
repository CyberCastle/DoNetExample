using DoNetExample.Persistence.model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Persistence.mappings
{
    class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.BirthDate);
            Map(x => x.Phone);
            Map(x => x.Movil);
            Map(x => x.Email);
            Map(x => x.Address);
        }
    }
}
