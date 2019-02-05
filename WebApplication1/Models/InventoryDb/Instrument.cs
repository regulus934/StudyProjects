using WebApplication1.Models.InventoryDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Instrument
    {
        public int InstrumentID { get; set; }
        public string Name { get; set; }
        public int Kolvo { get; set; }
        public string Comments { get; set; }

        public Request RequestId { get; set; }

    }
}