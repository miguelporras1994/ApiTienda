using BusinessLogicLayer.Interface;
using DataAcccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class CategoryRepository : Icategory
    {

        private readonly ModelContext _DBcontext;
        public CategoryRepository(ModelContext context)
        {
            _DBcontext = context;
        }
        public void Add(Category model)
        {

            _DBcontext.Categories.Add(model);
            _DBcontext.SaveChanges();



        }

        public void Delete(int id)
        {
            var Category = _DBcontext.Categories .Find(id);
            _DBcontext.Categories .Remove(Category);
            _DBcontext.SaveChanges();
        }

        public List<Category> Get()
        {
            return _DBcontext.Categories .ToList();
        }

        public Category GetId(int id)
        {
            return _DBcontext.Categories .Where(x => x.IdCategory == id).FirstOrDefault();
        }

        public void Put(Category model)
        {
            _DBcontext.Categories .Update(model);
            _DBcontext.SaveChanges();

        }
    }
}
