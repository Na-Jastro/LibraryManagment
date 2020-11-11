using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{
    public class CustomerRespository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRespository(LibraryDbContext context) : base(context)
        {
        }
    }
}
