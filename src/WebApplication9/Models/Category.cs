using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryLevel { get; set; }

        public List<Post> Posts { get; set; }
    }
}
