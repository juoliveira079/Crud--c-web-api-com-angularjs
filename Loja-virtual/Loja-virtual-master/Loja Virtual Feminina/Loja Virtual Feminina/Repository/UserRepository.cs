using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
    public class UserRepository
    {
        UserContext context = new UserContext();
        public void Add(User b)
        {
            context.Users.Add(b);
            context.SaveChanges();
        }

        public void Edit(User b)
        {
            context.Entry(b).State = System.Data.Entity.EntityState.Modified;

        }

        public void Remove(int Id)
        {
            User b = context.Users.Find(Id);
            context.Users.Remove(b);
            context.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public User FindById(int Id)
        {
            var c = (from r in context.Users where r.UserId == Id select r).FirstOrDefault();
            return c;
        }
    }
}