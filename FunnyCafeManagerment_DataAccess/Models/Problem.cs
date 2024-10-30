using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyCafeManagerment_DataAccess.Models
{
    public class Problem
    {
        public int ProblemId { get; set; }
        public string ProblemName { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}
