using ConsoleApp_imdb.Data;
using ConsoleApp_imdb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_imdb.CRUD
{
    public class CustomerCRUD
    {
        public int AddCustomer(
            string name,
            string surname,
            string mail,
            string password)
        {
            using (var context = new ImdbContext())
            {
                var customer = new Customer
                {
                    Name = name,
                    Surname = surname,
                    Mail = mail,
                    Password = password
                };

                context.Customers.Add(customer);
                context.SaveChangesAsync();

                return customer.Id;

            }
        }

        //public async Task ShowAllCustomers()
        //{
        //    using (var db = new ImdbContext())
        //    {
        //        var customers = await db.Customers
        //            .Select(c => new
        //            {
        //                Id = c.Id,
        //                Name = c.Name,
        //                Surname = c.Surname,
        //                Mail = c.Mail
        //            })
        //            .OrderBy(c => c.Surname)
        //            .ThenBy(c => c.Name)
        //            .ToListAsync();

        //        foreach (var item in customers)
        //        {
        //            Console.WriteLine(item.Name);
        //        }
        //    }
        //}
    }



}


