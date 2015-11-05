using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Repository
{
    public class UserDbInitalize : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            context.Users.Add(
               new User
               {                                                                      
                  UserId = 1,
                  Name = "Debora ",
                  Cpf = "145697557854",
                  End = "Rua Souza",
                  Phone = "27591364"
               });

            context.Users.Add(
              new User
              {
                  UserId = 2,
                  Name = "Carla ",
                  Cpf = "145697557854",
                  End = "Rua Souza",
                  Phone = "27591364"
              });

           
            context.SaveChanges();

            base.Seed(context);
        }
    }
}