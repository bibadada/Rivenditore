using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Models;
using System.Data.Entity;
using System.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using Rivenditore.DtoResponse;

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
                    return await context.Orders.Include(c => c.Customer).Include(x => x.OrderState).ToListAsync();
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


        public static async Task GetOrderStates()
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    var ListaOrdini = await context.Orders.Where(q => q.IdApi != null).ToListAsync();
                    
                    var options = new RestClientOptions("https://80.211.144.168/api/v1/orders/{id}/state")
                    {
                        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                    };
                    var client = new RestClient(options)
                    {
                        Authenticator = new JwtAuthenticator(token)
                    };

                    foreach (var order in ListaOrdini)
                    {
                        var request = new RestRequest();
                        request.AddParameter("id", order.IdApi, ParameterType.UrlSegment);
                        var response = await client.GetAsync<OrderStatesDTO>(request);
                        order.IdOrderStates = response.Id;
                    }
                    context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }
            }

        }


        public static async Task ConfirmOrderState(Order order)
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    List<OrderDetail> OrderDetailsApi = context.OrderDetails.Where(od => od.IdOrder == order.Id).ToList();
                    List<DtoRequest.OrderItemDTO> orderItems = new List<DtoRequest.OrderItemDTO>();
                    foreach (var item in OrderDetailsApi)
                    {
                        orderItems.Add(new DtoRequest.OrderItemDTO
                        {
                            ItemId = item.Item.Id,
                            Quantity = item.Quantity,
                            UnitaryPrice = item.SinglePrice
                        });
                    }

                    var options = new RestClientOptions("https://80.211.144.168/api/v1/orders")
                    {
                        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                    };
                    var client = new RestClient(options)
                    {
                        Authenticator = new JwtAuthenticator(token)
                    };
                    var request = new RestRequest();
                    request.AddBody(new DtoRequest.OrderDTO
                    {
                        CustomerId = order.IdCustomer,
                        OrderDate = DateTime.Now,
                        Notes = order.Notes,
                        OrderItems = orderItems

                    });

                    var response = client.Post<DtoResponse.OrderResponseDTO>(request);

                    Order candidate = context.Orders.FirstOrDefault(o => o.Id == order.Id);


                    candidate.IdOrderStates = 20;
                    candidate.DateOrederPlaced = DateTime.Now;
                    candidate.IdApi = response.Id;
                    context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public static void InsertOrder(int idCustomer, string note, List<OrderDetail> righeOrdine)
        {

            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {

                    Order orderToInsert = new Order
                    {
                        IdCustomer = idCustomer,
                        IdOrderStates = 10,
                        OrderDate = DateTime.Now,
                        Notes = note,


                    };


                    orderToInsert.OrderDetails = new List<OrderDetail>();

                    foreach (OrderDetail od in righeOrdine)
                    {
                        orderToInsert.OrderDetails.Add(new OrderDetail
                        {
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
                        od.Item = context.Items.FirstOrDefault(i => i.Id == od.Item.Id);
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
            using (RivenditoreEntities context = new RivenditoreEntities())
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
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    var d1 = context.Orders.FirstOrDefault(o => o.Id == order.Id).DateOrederPlaced;
                    var d2 = context.OrderDetails.Include(od => od.Item).Where(od => od.IdOrder == order.Id).Max(m => m.Item.LeadTime);

                    if (d1 != null && d2 != null)
                    {
                        var v = (DateTime)d1;
                        var v2 = (double)d2;

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