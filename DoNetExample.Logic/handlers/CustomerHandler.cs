using DoNetExample.Persistence.connection;
using DoNetExample.Persistence.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Logic.handlers
{
    public class CustomerHandler
    {
        private static readonly CustomerSessionHandler sessionHandler = new CustomerSessionHandler();

        public Customer getCustomerInfo(String Id)
        {
            IList<Customer> customers = sessionHandler.getCustomers("Id = '" + Id.ToString() + "'");
            if (customers.Count > 0)
            {
                return customers[0];
            }
            return null;
        }

        public IList<Customer> getAllCustomers()
        {
            return sessionHandler.getCustomers();
        }

        public void addCustomer(Customer customer)
        {
            sessionHandler.addCustomer(customer);
        }

        public void deleteCustomer(String customerId)
        {
            sessionHandler.deleteCustomer(customerId);
        }

        public void updateCustomer(Customer customer)
        {
            sessionHandler.updateCustomer(customer);
        }
    }
}
