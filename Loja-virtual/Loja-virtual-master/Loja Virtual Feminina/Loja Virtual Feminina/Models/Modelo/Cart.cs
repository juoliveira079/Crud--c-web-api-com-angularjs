using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
    public class Cart
    {
       
        public int CartId { get; set; }
        public string Cart_Product { get; set; }
        public  string Client { get; set; }
        public decimal Total { get; set; }

    }
 

}