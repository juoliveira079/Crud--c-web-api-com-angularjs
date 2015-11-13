using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Categories
{
    class TestCategoryDBset : TestDbSet<Category>
    {
        public override Category Find(params object[] keyValues)
        {
            return this.SingleOrDefault(category => category.CategoryId == (int)keyValues.Single());
        }
    }
}
