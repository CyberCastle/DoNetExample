using DoNetExample.Persistence.model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Persistence.connection
{
    public class DeviceSessionHandler: AbstractSessionHandler
    {
        public IList<Device> getDevices(String filter = "")
        {
            try
            {
                ISessionFactory sessionFactory = CreateSessionFactory();
                using (ISession session = sessionFactory.OpenSession())
                {
                    String stament = "FROM Device";
                    if (filter != "")
                    {
                        stament += " WHERE " + filter;
                    }
                    IQuery query = session.CreateQuery(stament);
                    return query.List<Device>();
                }
            }
            catch (Exception ex)
            {
                throw new SessionHandlerException("Error al obtener los registros.", ex, "Cod-001");
            }
        }

        public void addDevice(Device device)
        {
            ISessionFactory sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(device);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new SessionHandlerException("Error al agregar los registros.", ex, "Cod-002");
                    }
                }
            }
        }


        public void deleteDevice(String deviceId)
        {
            ISessionFactory sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        IQuery query = session.CreateQuery("FROM Device WHERE Id = '" + deviceId + "'");
                        Device device = query.List<Device>()[0];
                        session.Delete(device);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new SessionHandlerException("Error al borrar los registros.", ex, "Cod-003");
                    }
                }
            }
        }


        public void updateDevice(Device device)
        {
            ISessionFactory sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(device);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new SessionHandlerException("Error al actualizar los registros.", ex, "Cod-004");
                    }
                }
            }
        }
    }
}
