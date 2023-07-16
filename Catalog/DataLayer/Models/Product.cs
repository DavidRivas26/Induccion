using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Product : BaseModel
    {
        public int Id_Product { get; set; }
        public string Id_Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string Detail { get; set; }
    }
}
