using DoNetExample.Persistence.model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNetExample.Persistence.connection
{
    public class CustomerSessionHandler: AbstractSessionHandler
    {

        public IList<Customer> getCustomers(String filter = "")
        {
            try
            {
                ISessionFactory sessionFactory = CreateSessionFactory();
                using (ISession session = sessionFactory.OpenSession())
                {
                    String stament = "FROM Customer";
                    if (filter != "")
                    {
                        stament += " WHERE " + filter;
                    }

                    Console.Write(stament);

                    IQuery query = session.CreateQuery(stament);
                    return query.List<Customer>();
                }
            }
            catch (Exception ex)
            {
                throw new SessionHandlerException("Error al obtener los registros.", ex, "Cod-001");
            }
        }

        public void addCustomer(Customer customer)
        {
            ISessionFactory sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(customer);
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

        public void deleteCustomer(String customerId)
        {
            ISessionFactory sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        IQuery query = session.CreateQuery("FROM Customer WHERE Id = '" + customerId + "'");
                        Customer customer = query.List<Customer>()[0];
                        session.Delete(customer);
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

        public void updateCustomer(Customer customer)
        {
            ISessionFactory sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(customer);
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
