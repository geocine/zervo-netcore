﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Zervo.Data.Models;
using Zervo.Data.Repositories.Contracts;
using Zervo.Data.Repositories.Database;

namespace Zervo.Data.Repositories
{
    public class CustomerRepository : Repository<Customer> , ICustomerRepository
    {
        private readonly ZervoContext _context;

        public CustomerRepository(ZervoContext context)
            : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Customer> GetAll()
        {
            return _context.Set<Customer>().Include(x => x.Person).AsEnumerable();
        }

    }
}
