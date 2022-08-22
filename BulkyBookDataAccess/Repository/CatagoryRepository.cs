using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CatagoryRepository : Repository<Catagory>, ICatagoryRepository
    {
        private ApplicationDbContext _db;
        public CatagoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
      
        public void Update(Catagory obj)
        {
            _db.Catagories.Update(obj);
        }
    }
}
