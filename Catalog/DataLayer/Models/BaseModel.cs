using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class BaseModel
    {
        public bool Status { get; set; }
        public string Author { get; set; }
        public string Date_Creation { get; set; }
        public string Date_Update { get; set; }
    }
}
