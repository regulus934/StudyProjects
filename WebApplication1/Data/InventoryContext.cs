using WebApplication1.Models;
using WebApplication1.Models.InventoryDb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext()
            : base("DefaultConnection")
        {}

    public DbSet<Request> Request { get; set; }
    public DbSet<Instrument> Instruments {get;set;}
    }
}