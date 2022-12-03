using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Models;
using System.Data.Entity;

namespace Rivenditore.Controllers
{
    public static class OrdersController
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

        public static List<Order> Delete(Order o, List<Order> list)
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    List<OrderDetail> orderDetailsDaEliminare = new List<OrderDetail>();
                    orderDetailsDaEliminare = context.OrderDetails.Where(od => od.IdOrder == o.Id).ToList();


                    foreach (OrderDetail od in orderDetailsDaEliminare)
                    {
                        context.OrderDetails.Remove(od);
                    }

                    Order ordineDaEliminare = context.Orders.FirstOrDefault(order => order.Id == o.Id);

                    if (ordineDaEliminare != null)
                        context.Orders.Remove(ordineDaEliminare);

                    context.SaveChanges();

                    list.Remove(o);

                    return list;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        //metodo che modifica lo stato di un ordine a confermato
        public static void ConfirmOrderState(int id)
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    Order candidate = context.Orders.FirstOrDefault(o => o.Id == id);
                    if (candidate != null)
                    {
                        candidate.IdOrderStates = 20;
                        context.SaveChanges();
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        //metodo che modifica lo stato di un ordine a confermato
        public static void ConfirmOrderState(Order order)
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    Order candidate = context.Orders.FirstOrDefault(o => o.Id == order.Id);
                    if (candidate != null)
                    {
                        candidate.IdOrderStates = 20;
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