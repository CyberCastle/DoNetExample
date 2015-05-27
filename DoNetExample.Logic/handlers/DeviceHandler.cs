using DoNetExample.Persistence.connection;
using DoNetExample.Persistence.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Logic.handlers
{
    public class DeviceHandler
    {
        private static readonly DeviceSessionHandler sessionHandler = new DeviceSessionHandler();

        public IList<Device> getDevicesByUser(String userId)
        {
            return sessionHandler.getDevices("Customer_Id = '" + userId + "'");
        }

        public Device getDeviceInfo(Int64 deviceId)
        {
            IList<Device> devices = sessionHandler.getDevices("Id = " + deviceId.ToString());
            if (devices.Count > 0)
            {
                return devices[0];
            }
            return null;
        }

        public void addDevice(Device device)
        {
            sessionHandler.addDevice(device);
        }

        public void deleteDevice(Int64 deviceId)
        {
            sessionHandler.deleteDevice(deviceId.ToString());
        }

        public void updateDevice(Device device)
        {
            sessionHandler.updateDevice(device);
        }
    }
}
