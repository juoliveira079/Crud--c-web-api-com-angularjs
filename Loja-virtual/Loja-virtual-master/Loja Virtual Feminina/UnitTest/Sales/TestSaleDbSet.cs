using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Sales
{
    class TestSaleDBset : TestDbSet<Sale>
    {
        public override Sale Find(params object[] keyValues)
        {
            return this.SingleOrDefault(sale => sale.SaleId == (int)keyValues.Single());
        }
    }
}
