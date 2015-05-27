using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Persistence.model
{
    public class Device
    {
        public virtual Int64 Id { get; set; }
        public virtual String Type { get; set; }
        public virtual String Brand { get; set; }
        public virtual String Model { get; set; }
        public virtual Int64 SerialNumber { get; set; }
        public virtual String Customer_Id { get; set; }
    }
}
