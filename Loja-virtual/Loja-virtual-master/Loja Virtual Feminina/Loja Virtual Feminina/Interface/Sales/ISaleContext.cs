using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Virtual_Feminina.Interface.Sales
{
    public interface ISaleContext : IDisposable
    {
        DbSet<Sale> Sales { get; }
        int SaveChanges();
        void MarkAsModified(Sale item);
    }
}
