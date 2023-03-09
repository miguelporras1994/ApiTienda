using BusinessLogicLayer.Interface;
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
        public ActionResult Create(Product model )
        {
            _Iproduct.Add(model);
            return Ok();
        }



        [HttpPut]
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Product model)
        {
            model.IdProduct = id;
            _Iproduct.Put(model);
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
