using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Models;
using System.Data.Entity;
using System.Configuration;

namespace Rivenditore.Controllers
{
    public static class OrdersController
    {

        private static string token = ConfigurationManager.ConnectionStrings["TokenApi"].ConnectionString;

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
                        candidate.DateOrederPlaced = DateTime.Now;
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
                        candidate.DateOrederPlaced = DateTime.Now;
                        context.SaveChanges();
                    }

                    List<OrderDetail> OrderDetailsToSendApi = context.OrderDetails.Where(od => od.IdOrder == order.Id).ToList();



                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public static void InsertOrder(int idCustomer, string note, List<OrderDetail> righeOrdine) {
        
            using(RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                
                    Order orderToInsert = new Order
                    {
                        IdCustomer = idCustomer,
                        IdOrderStates = 10,
                        OrderDate = DateTime.Now,
                        Notes = note,
                        
                        
                    } ;


                    orderToInsert.OrderDetails = new List<OrderDetail>();

                    foreach (OrderDetail od in righeOrdine)
                    {
                        orderToInsert.OrderDetails.Add(new OrderDetail {
                            IdItem = od.Item.Id,
                            SinglePrice = od.SinglePrice,
                            Quantity = od.Quantity

                        });
                    }

                    context.Orders.Add(orderToInsert);
                    

                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static void ModifyOrder(Order orderToModify, int idCustomer, string note, List<OrderDetail> righeOrdine)
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    Order candidateO = context.Orders.FirstOrDefault(o => o.Id == orderToModify.Id);
                    candidateO.IdCustomer = idCustomer;
                    candidateO.Notes = note;


                    context.OrderDetails.RemoveRange(context.OrderDetails.Where(od => od.IdOrder == candidateO.Id).ToList());

                    foreach (var od in righeOrdine)
                    {
                        od.IdOrder = candidateO.Id;
                        od.IdItem = od.Item.Id;
                    }

                    context.OrderDetails.AddRange(righeOrdine);



                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static List<OrderDetail> GetRowByOrder(Order order)
        {
            using(RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    return context.OrderDetails.Where(od => od.IdOrder == order.Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        public static DateTime? CalculateDeliveryDate(Order order)
        {
            using(RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    var d1 = context.Orders.FirstOrDefault(o => o.Id == order.Id).DateOrederPlaced;
                    var d2 = context.OrderDetails.Include(od => od.Item).Where(od => od.IdOrder == order.Id).Max(m => m.Item.LeadTime);

                    if(d1 != null && d2 != null)
                    {
                        var v = (DateTime)d1;
                        var v2 =  (double)d2;

                        return v.AddDays(v2); 
                    }
                    return null;  
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}