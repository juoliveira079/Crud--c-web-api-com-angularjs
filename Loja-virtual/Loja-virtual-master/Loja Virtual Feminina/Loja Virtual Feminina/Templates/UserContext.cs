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
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
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
