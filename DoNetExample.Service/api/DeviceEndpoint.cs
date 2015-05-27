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
    [RoutePrefix("service/device")]
    public class DeviceEndpoint : ApiController
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [Route("{customerId}")]
        [HttpGet]
        public IList<Device> getDeviceByUser(String customerId)
        {
            try
            {
                IApplicationContext context = ContextRegistry.GetContext();
                DeviceHandler hdlr = (DeviceHandler)context["deviceHandler"];
                return hdlr.getDevicesByUser(customerId);
            }
            catch (Exception e)
            {
                log.Error("CyberCastle says: ", e);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [Route("info/{deviceId:long}")]
        [HttpGet]
        public Device getDeviceInfo(Int64 deviceId)
        {
            try
            {
                IApplicationContext context = ContextRegistry.GetContext();
                DeviceHandler hdlr = (DeviceHandler)context["deviceHandler"];
                return hdlr.getDeviceInfo(deviceId);
            }
            catch (Exception e)
            {
                log.Error("CyberCastle says: ", e);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [Route]
        [HttpPut]
        public Int16 addDevice(Device device)
        {
            try
            {
                IApplicationContext context = ContextRegistry.GetContext();
                DeviceHandler hdlr = (DeviceHandler)context["deviceHandler"];
                hdlr.addDevice(device);
                return 0;
            }
            catch (Exception e)
            {
                log.Error("CyberCastle says: ", e);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [Route("{deviceId:long}")]
        [HttpDelete]
        public Int16 deleteDevice(Int64 deviceId)
        {
            try
            {
                IApplicationContext context = ContextRegistry.GetContext();
                DeviceHandler hdlr = (DeviceHandler)context["deviceHandler"];
                hdlr.deleteDevice(deviceId);
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
        public Int16 updateDevice(Device device)
        {
            try
            {
                IApplicationContext context = ContextRegistry.GetContext();
                DeviceHandler hdlr = (DeviceHandler)context["deviceHandler"];
                hdlr.updateDevice(device);
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