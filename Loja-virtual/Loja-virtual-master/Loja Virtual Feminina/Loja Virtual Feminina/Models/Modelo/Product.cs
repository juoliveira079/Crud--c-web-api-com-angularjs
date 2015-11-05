using Loja_Virtual_Feminina.Models.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductId{ get; set; }
        public string ProductName { get; set; }
        public string Category_Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

       
    }
    

    
}