using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commonlayer.Dto
{
   public  class ProductDto
    {
        public int IdProduct { get; set; }

        public string NameProduct { get; set; } = null!;

        public double Price { get; set; }

        public string Discretion { get; set; } = null!;

        public int? IdCategory { get; set; }

        public IFormFile Img { get; set; }

    }
}
