using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Loja_Virtual_Feminina.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string End { get; set; }
        public string Phone { get; set; }
    }
  
}