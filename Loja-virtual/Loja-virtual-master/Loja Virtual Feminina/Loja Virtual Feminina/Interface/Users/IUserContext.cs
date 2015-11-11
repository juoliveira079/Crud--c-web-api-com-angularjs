using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Virtual_Feminina.Interface.Users
{
    public interface IUserContext : IDisposable
    {
        DbSet<User> Users { get; }
        int SaveChanges();
        void MarkAsModified(User item);
    }
}
