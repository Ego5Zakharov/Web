using Core.Entities;
using Core.Interfaces;
using Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Repositories
{
    public class CustomerReposityoryAsync : GenericRepository<Customer>, ICustomerRepositoryAsync
    {
        private readonly DbSet<Customer> _customer;
        public CustomerReposityoryAsync(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _customer = dbcontext.Set<Customer>();
        }
    }
}
