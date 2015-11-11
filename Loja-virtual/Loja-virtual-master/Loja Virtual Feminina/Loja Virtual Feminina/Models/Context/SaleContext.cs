using Loja_Virtual_Feminina.Interface.Sales;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
    public class SaleContext : DbContext,ISaleContext
    {

        public SaleContext()
            : base("name=DefaultConnection")
        {
        }
        public System.Data.Entity.DbSet<Sale> Sales { get; set; }

        public void MarkAsModified(Sale item)
        {
            Entry(item).State = EntityState.Modified;
        }
    
    
    }
}
