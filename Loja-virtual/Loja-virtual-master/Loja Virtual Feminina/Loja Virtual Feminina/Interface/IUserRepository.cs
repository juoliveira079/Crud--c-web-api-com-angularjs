using Loja_Virtual_Feminina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Virtual_Feminina.Interface
{
    interface IUserRepository
    {
        void Add(User b);
        void Edit(User b);
        void Remove(User b);
        IEnumerable<User> GetUsers();
        User FindById(int Id);
    }
}
