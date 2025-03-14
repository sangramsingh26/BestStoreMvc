﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeastStoreMvc.Models
{
    public class CategoryMaster
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "* CategoryName can't be blank")]
        public string CategoryName { get; set; } = " ";

        public string Description { get; set; } = " ";


    }

    public class ProductMaster
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "* ProductName can't be blank")]
        public string ProductName { get; set; } = " ";

        public int CategoryId { get; set; }

        public string? Description { get; set; } // Nullable Description

        [Required(ErrorMessage = "* Price can't be blank")]
        public long? Price { get; set; } // Nullable Price

        [NotMapped]
        public string CategoryName { get; set; } = " ";
    }
}