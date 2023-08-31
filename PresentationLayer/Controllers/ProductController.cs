using BusinessLogicLayer.Interface;
using Commonlayer.Dto;
using DataAcccesLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("Api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly Iproduct _Iproduct;

         public ProductController(Iproduct Product) { 
        
            _Iproduct = Product;
        } 
            
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return _Iproduct.Get();
        }

 
        [HttpPost]
        public ActionResult Create( [FromForm] ProductDto model )
        {
            Product product = new Product()
            {
                IdProduct = model.IdProduct,
                NameProduct = model.NameProduct,
                Price = model.Price,

                Discretion = model.Discretion,
                IdCategory = model.IdCategory,
            };



            //_Iproduct.Add(product);
            return Ok();
        }



        [HttpPut]
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] ProductDto  model)
        {
            model.IdProduct = id;
            Product product = new Product()
            {
                IdProduct = model.IdProduct,
                NameProduct = model.NameProduct,
                Price = model.Price,

                Discretion = model.Discretion,
                IdCategory = model.IdCategory,
            };

            //_Iproduct.Put(product);
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            
            _Iproduct.Delete(id);
            return Ok();
        }

    }
}
