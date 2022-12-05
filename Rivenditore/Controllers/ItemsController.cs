using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Models;
using System.Data.Entity;

namespace Rivenditore.Controllers
{
    static class ItemsController
    {

        public async static Task<List<Item>> GetAll()
        {
            using(RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    return await context.Items.ToListAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static double? GetItemPriceById(int id)
        {
            using(RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    return context.Items.FirstOrDefault(i => i.Id == id).Price;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

    }
}
