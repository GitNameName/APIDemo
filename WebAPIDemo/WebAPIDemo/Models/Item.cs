using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Models
{
    public class Item
    {

        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupID { get; set; }
        public Group ItemGroup { get; set; }
    }
}
