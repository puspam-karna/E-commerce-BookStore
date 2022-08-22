using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
      
        public void Update(Product obj)
        {
            //_db.Products.Update(obj);  //updates all models at once even it changes are not made
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb.Id != null)
            {
                objFromDb.Title=obj.Title;
                objFromDb.Description=obj.Description;
                objFromDb.Author=obj.Author;
                objFromDb.ISBN=obj.ISBN;
                objFromDb.Price=obj.Price;
                objFromDb.ListPrice=obj.ListPrice;
                objFromDb.Price50=obj.Price50;
                objFromDb.Price100=obj.Price100;
                objFromDb.CatagoryId = obj.CatagoryId;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if (objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl=obj.ImageUrl;
                }

            }
        }
    }
}
