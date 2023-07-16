using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Category : BaseModel
    {
        public int Id_Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
