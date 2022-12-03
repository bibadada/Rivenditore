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

        public async static Task<List<int>> GetAllIds()
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    List<int> retVal = await context.Items.Select(select => select.Id).ToListAsync();
                    return retVal;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

    }
}
