using Compsci335_A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Compsci335_A1.Data
{
    public class WebApiRepo : IWebApiRepo
    {
        private readonly WebApiDBContext _dbContext;

        public WebApiRepo(WebApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> getAllItems()
        {
            IEnumerable<Product> products = _dbContext.products.ToList<Product>();
            return products;
        }

        public IEnumerable<Staff> getAllStaffs()
        {
            IEnumerable<Staff> staffs = _dbContext.staffs.ToList<Staff>();
            return staffs;
        }

        public IEnumerable<Product> getItemsWithPartial(String s)
        {
            IEnumerable<Product> products = _dbContext.products.ToList<Product>().Where(p => p.Name.ToLower().Contains(s.ToLower()));
            return products;
        }

        public string getVersion()
        {
            return "V1";
        }

        public Comments addComment(Comments c)
        {
            EntityEntry<Comments> e = _dbContext.comments.Add(c);
            Comments com = e.Entity;
            _dbContext.SaveChanges();
            return com;
        }

        public IEnumerable<Comments> getAllComments()
        {
            IEnumerable<Comments> comments = _dbContext.comments.ToList<Comments>();
            return comments;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Staff getStaff(int id)
        {
            Staff staff = _dbContext.staffs.FirstOrDefault(e => e.Id == id);
            return staff;
        }
    }
}
