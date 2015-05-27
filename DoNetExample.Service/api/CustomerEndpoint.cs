using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DoNetExample.Persistence.model;
using DoNetExample.Persistence.connection;
using DoNetExample.Logic.handlers;
using Spring.Context;
using Spring.Context.Support;
using log4net;
using System.Reflection;
using System.Net;
using System.Web.Http.Cors;

namespace DoNetExample.Service.api
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("service/customer")]
    public class CustomerEndpoint : ApiController
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [Route]
        [HttpGet]
        public IList<Customer> getAllCustomers()
        {
            IApplicationContext context = ContextRegistry.GetContext();
            CustomerHandler hdlr = (CustomerHandler)context["customerHandler"];
            return hdlr.getAllCustomers();
        }

        [Route("{customerId}")]
        [HttpGet]
        public Customer getCustomerInfo(String customerId)
        {
            try
            {
                IApplicationContext context = ContextRegistry.GetContext();
                CustomerHandler hdlr = (CustomerHandler)context["customerHandler"];
                return hdlr.getCustomerInfo(customerId);
            }
            catch (Exception e)
            {
                log.Error("CyberCastle says: ", e);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [Route]
        [HttpPut]
        public Int16 addCustomer(Customer customer)
        {
            try
            {
                IApplicationContext context = ContextRegistry.GetContext();
                CustomerHandler hdlr = (CustomerHandler)context["customerHandler"];
                hdlr.addCustomer(customer);
                return 0;
            }
            catch (Exception e)
            {
                log.Error("CyberCastle says: ", e);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [Route("{customerId}")]
        [HttpDelete]
        public Int16 deleteCustomer(String customerId)
        {
            try
            {
                IApplicationContext context = ContextRegistry.GetContext();
                CustomerHandler hdlr = (CustomerHandler)context["customerHandler"];
                hdlr.deleteCustomer(customerId);
                return 0;
            }
            catch (Exception e)
            {
                log.Error("CyberCastle says: ", e);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [Route]
        [HttpPost]
        public Int16 updateCustomer(Customer customer)
        {
            try
            {
                IApplicationContext context = ContextRegistry.GetContext();
                CustomerHandler hdlr = (CustomerHandler)context["customerHandler"];
                hdlr.updateCustomer(customer);
                return 0;
            }
            catch (Exception e)
            {
                log.Error("CyberCastle says: ", e);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}