using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Models;
using System.Data.Entity;

namespace Rivenditore.Controllers
{
    class OrdersController
    {

        public async static Task<List<Order>> GetAll()
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    return await context.Orders.ToListAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
