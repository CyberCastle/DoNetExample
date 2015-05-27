using DoNetExample.Persistence.model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Persistence.mappings
{
    class DeviceMap : ClassMap<Device>
    {
        public DeviceMap()
        {
            Id(x => x.Id);
            Map(x => x.Type);
            Map(x => x.Brand);
            Map(x => x.Model);
            Map(x => x.SerialNumber);
            Map(x => x.Customer_Id);
        }
    }
}
