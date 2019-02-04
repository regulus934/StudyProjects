using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.InventoryDb
{
    public class Request
    {
        public int id { get; set; }
        public DateTime Month { get; set; }
        public virtual List<Instrument> Instruments { get; set; }
        public Request()
        {
            Instruments = new List<Instrument>();
        }
    }
}