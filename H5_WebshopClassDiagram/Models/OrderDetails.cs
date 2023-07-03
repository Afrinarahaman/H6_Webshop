﻿using H5_Webshop.DTOs.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5_Webshop.Database.Entities
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string ProductTitle { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal ProductPrice { get; set; }


        [Column(TypeName = "smallint")]
        public int Quantity { get; set; }

        //[Column(TypeName = "Date")]  //this is a columnAttribute from System.CoponentModel.DataAnnotations (defined in enityframework.dll)
        //public DateTime OrderDate { get; set; }


        public int OrderId { get; set; }

    }
}
