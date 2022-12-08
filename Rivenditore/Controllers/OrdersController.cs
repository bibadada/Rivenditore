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
                    context.Orders.Add(
                    new Order
                    {
                        IdCustomer = idCustomer,
                        IdOrderStates = 10,
                        OrderDate = DateTime.Now,
                        Notes = note,
                        OrderDetails = righeOrdine
                    });

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

                    List<OrderDetail> CandidateOd = context.OrderDetails.Where(od => od.IdOrder == candidateO.Id).ToList(); 
                    if(CandidateOd != null && CandidateOd.Count() == righeOrdine.Count)
                    {
                        for(int i = 0; i < CandidateOd.Count; i++)
                        {
                            CandidateOd[i].IdOrder = righeOrdine[i].IdOrder;
                            CandidateOd[i].IdItem = righeOrdine[i].IdItem;
                            CandidateOd[i].Quantity = righeOrdine[i].Quantity;
                            CandidateOd[i].SinglePrice = righeOrdine[i].SinglePrice;
                        }
                    }
                    
                    

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