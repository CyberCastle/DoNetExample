using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Persistence.model
{
    public class Customer
    {
        public virtual String Name { get; set; }
        public virtual String Id { get; set; }
        public virtual String Email { get; set; }
        public virtual Int64 Phone { get; set; }
        public virtual Int64 Movil { get; set; }
        public virtual Nullable<DateTime> BirthDate { get; set; }
        public virtual String Address { get; set; }
    }
}
