using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compsci335_A1.Models;

namespace Compsci335_A1.Data
{
    public interface IWebApiRepo
    {
        IEnumerable<Staff> getAllStaffs();
        string getVersion();
        IEnumerable<Product> getAllItems();
        IEnumerable<Product> getItemsWithPartial(String s);
        Comments addComment(Comments c);
        Staff getStaff(int id);
        IEnumerable<Comments> getAllComments();
        void SaveChanges();

    }
}
