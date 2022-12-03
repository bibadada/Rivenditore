
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

        public async static Task<List<int>> GetAllIds()
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    List<int> retVal = await context.Customers.Select(select => select.Id).ToListAsync();
                    return retVal;
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

       //da ricordarsi i vincoli di integrità referenziale
        public static List<Customer> Delete(Customer c, List<Customer> list)
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    Customer candidate = context.Customers.Where(w => w.Id == c.Id).FirstOrDefault();
                    if(candidate != null)
                    {
                        //rimuovo l'oggetto dal database
                        context.Customers.Remove(candidate);
                        context.SaveChanges();

                        //rimuovo l'oggetto dalla lista che andrò a ritornare nel VM e a qui associero proprietà
                        list.Remove(c);
                        
                    }

                    return list;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }

        public static void Modify(Customer sc)
        {
            using (RivenditoreEntities context = new RivenditoreEntities())
            {
                try
                {
                    Customer candidate = context.Customers.FirstOrDefault(u => u.Id == sc.Id);
                    candidate.Name = sc.Name;
                    candidate.Surname = sc.Surname;
                    candidate.FiscalCode = sc.FiscalCode;
                    candidate.Address = sc.Address;
                    candidate.City = sc.City;
                    candidate.Cap = sc.Cap;
                    candidate.Mail = sc.Mail;
                    candidate.Phone = sc.Phone;

                    context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
