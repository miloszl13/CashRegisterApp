﻿using Domain;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private BillsDbContext _db;
        public ProductRepository(BillsDbContext context)
        {
            _db = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _db.Products;
        }
    }
}
