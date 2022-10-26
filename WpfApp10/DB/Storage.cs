using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp10.DB
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
