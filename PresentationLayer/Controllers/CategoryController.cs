using BusinessLogicLayer.Interface;
using DataAcccesLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{

    [ApiController]
    [Route("Api/Category")]
    public class CategoryController : ControllerBase
    {
        private readonly Icategory _Icategory;

        public CategoryController(Icategory Category)
        {

            _Icategory = Category;
        }

        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return _Icategory.Get();
        }


        [HttpPost]
        public ActionResult Create(Category model)
        {
            _Icategory.Add(model);
            return Ok();
        }



        [HttpPut]
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Category model)
        {
            model.IdCategory = id;
            _Icategory.Put(model);
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

            _Icategory.Delete(id);
            return Ok();
        }

   
    }
}
