using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp10.DB
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Artikul { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Manufacture { get; set; }
        public string Catrgory { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }
        public double Sale { get; set; }
    }
}
