using LibraryManagment.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data
{
    public static class DbInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();


                //Add Customers
                var justice = new Customer { Name = "Justice Ngwenya" };
                var sadio = new Customer { Name = "Sadio Mane" };
                var Leonel = new Customer { Name = "Leonel Messi" };

                context.Customers.Add(justice);
                context.Customers.Add(sadio);
                context.Customers.Add(Leonel);

                //Add Author

                var authorDeMarco = new Author
                {
                    Name = "M J DeMarco",
                    Books = new List<Book>()
                    {
                        new Book{Title = "The Millionaire Fastlane"},
                        new Book{Title = "Unscripted"}
                    }
                };

                var authorCardone = new Author
                {
                    Name = "Grant Cardone",
                    Books = new List<Book>()
                    {
                        new Book{Title = "The 10X Rule "},
                        new Book{Title = "If you're Not First, You're Last"},
                        new Book{Title = "Sell To Survive"}
                    }
                };
                context.Authors.Add(authorDeMarco);
                context.Authors.Add(authorCardone);

                context.SaveChanges();
            }
        }

    }
}
