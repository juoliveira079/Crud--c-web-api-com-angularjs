using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SaleId{ get; set;}
        public String User_Sale {get; set; }
        public String Product_Sale {get; set;}
        public int Cart_Sale {get; set;}
        public decimal Total_Sale { get; set; }
    }
 
}