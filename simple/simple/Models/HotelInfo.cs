using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple.Models
{
    public class HotelInfo
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public string Address { get; set; }
      
    }
}
