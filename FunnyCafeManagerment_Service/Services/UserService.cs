using FunnyCafeManagerment_DataAccess.Models;
using FunnyCafeManagerment_DataAccess.Repositories;
using FunnyCafeManagerment_DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyCafeManagerment_Service.Services
{
    public class UserService
    {
        UserRepo _repo;

        public UserService()
        {
            _repo = new();
        }

        public User? Login(UserVM u)
        {
            if (u != null)
                return _repo.GetUser(u.Username, u.Password);
            return null;
        }
    }
}
