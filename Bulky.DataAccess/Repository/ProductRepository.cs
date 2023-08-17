using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }
        public void Update(Product product)
        {
            var productInDb = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if(productInDb != null)
            {
                productInDb.Title = product.Title;
                productInDb.Description = product.Description;
                productInDb.ISBN = product.ISBN;
                productInDb.Author = product.Author;
                productInDb.ListPrice = product.ListPrice;
                productInDb.Price = product.Price;
                productInDb.Price50 = product.Price50;
                productInDb.Price100 = product.Price100;
                productInDb.CategoryId = product.CategoryId;
                if(product.ImageUrl  != null)
                {
                    productInDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
