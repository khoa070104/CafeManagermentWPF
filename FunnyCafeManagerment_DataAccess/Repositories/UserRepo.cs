using FunnyCafeManagerment_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyCafeManagerment_DataAccess.Repositories
{
    public class UserRepo
    {
        ManageCafeShopContext _context;
        public User? GetUser(string username, string password)
        {
            _context = new ManageCafeShopContext();
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if(user == null) 
                return null;
            return user.Password == password ? user : null;
        }
    }
}
