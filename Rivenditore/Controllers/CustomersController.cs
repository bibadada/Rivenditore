using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Rivenditore.Models;

namespace Rivenditore.Controllers
{
    public static class CustomersController
    {
        public async static Task<List<Customer>> GetAll()
        {
            using(RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    List<Customer> test = await context.Customers.ToListAsync();
                    return test;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public static void Insert(Customer c)
        {
            using(RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    if(c != null)
                    {
                        context.Customers.Add(c);
                        context.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
