using Loja_Virtual_Feminina.Models;
using Loja_Virtual_Feminina.Models.Context;
using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
    public class SaleRepository
    {
        SaleContext context = new SaleContext();
        public void Add(Sale b)
        {
            context.Sales.Add(b);
            context.SaveChanges();
        }

        public void Edit(Sale b)
        {
            context.Entry(b).State = System.Data.Entity.EntityState.Modified;

        }

        public void Remove(int Id)
        {
            Sale b = context.Sales.Find(Id);
            context.Sales.Remove(b);
            context.SaveChanges();
        }

        public IEnumerable<Sale> GetSales()
        {
            return context.Sales;
        }

        public Sale FindById(int Id)
        {
            var c = (from r in context.Sales where r.SaleId == Id select r).FirstOrDefault();
            return c;
        }
    }
}