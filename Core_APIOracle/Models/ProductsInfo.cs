﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_APIOracle.Models
{
    [Table("CM_HINMO_ALL")]
    public class ProductsInfo
    {
        [Key]
        //public int ProductRecordId { get; set; }
        //[Required]
        //[StringLength(100)]
        //public string ProductId { get; set; } = String.Empty;
        //[StringLength(400)]
        //public string ProductName { get; set; } = String.Empty;
        //[StringLength(200)]
        //public string Manufacturer { get; set; } = String.Empty;
        //[StringLength(1000)]
        //public string Description { get; set; } = String.Empty;
        //public int Price { get; set; }
        
        public string ITM_CD { get; set; }
        
        public string CO_CD { get; set; }

        public string ITM_NM { get; set; }

        public string UNIT_CD { get; set; }

        public string PROD_ITM_GRP_CD { get; set; }

        //public custItemCd CustItemCd { get; set; }


    }
}
