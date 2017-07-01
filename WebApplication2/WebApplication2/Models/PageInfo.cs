using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class PageInfo
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages 
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
