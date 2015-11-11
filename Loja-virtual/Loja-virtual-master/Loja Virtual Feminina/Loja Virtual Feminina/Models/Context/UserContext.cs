using Loja_Virtual_Feminina.Interface.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
    public class UserContext : DbContext ,IUserContext
    {
       
    
        public UserContext() : base("name=UserContext")
        {
        }

        public System.Data.Entity.DbSet<User> Users { get; set; }

        public void MarkAsModified(User item)
        {
            Entry(item).State = EntityState.Modified;
        }
    
    }
}
