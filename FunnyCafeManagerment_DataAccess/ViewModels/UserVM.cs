using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyCafeManagerment_DataAccess.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
