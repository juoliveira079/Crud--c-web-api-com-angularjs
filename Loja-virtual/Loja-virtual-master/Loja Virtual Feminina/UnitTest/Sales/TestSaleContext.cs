using Loja_Virtual_Feminina.Interface.Sales;
using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Sales
{
    class TestSaleContext: ISaleContext
    {
        public TestSaleContext()
        {
            this.Sales = new TestSaleDBset();
        }

        public DbSet<Sale> Sales { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Sale item) { }
        public void Dispose() { }
    }
}
