using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja_Virtual_Feminina.Models;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class Teste
    {
        [TestMethod]

        public void AddProduto_Deve_Adicionar_Produto()
        {

        }

        [TestMethod]
        public void GetProdutosList_Deve_Exibir_Lista_de_Produtos_Gravados()
        {
            var produto = new List<Produto>
            {
              // Arrange
              new Produto{Id_prod=1,Nome_prod="Vestido",Quantidade=2,Preco=80},
              new Produto{Id_prod=2,Nome_prod="Saia",Quantidade=4,Preco=58},
              new Produto{Id_prod=3,Nome_prod="Calça Jeans",Quantidade=5,Preco=89}
            };

            // Act 

            // Assert
       
        }
         [TestMethod]
        public void GetProduto_Deve_Exibir_Produto()
        {

        }
         [TestMethod]

        public void ModifyProduto_Deve_Editar_Produto_Selecionado()
        {

        }
         [TestMethod]
        public void DeleteProduto_Deve_Excluir_Produto_Selecionado()
        {

        }
    }
}
