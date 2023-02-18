using BusinessLogicLayer.Interface;
using DataAcccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public  class ProductRepository : Iproduct
    {
        private readonly ModelContext _DBcontext;
        public ProductRepository(ModelContext context) {
        _DBcontext= context;
        }
        public void Add(Product model)
        {

            _DBcontext.Products.Add(model);
            _DBcontext.SaveChanges();

            

        }

        public void Delete(int id)
        {
            var product = _DBcontext.Products.Find(id);
            _DBcontext.Products.Remove(product);
            _DBcontext.SaveChanges();
        }

        public List<Product> Get()
        {
            return _DBcontext.Products.OrderBy(x => x.Category).ToList();
        }

        public Product GetId(int id)
        {
            return _DBcontext.Products.Where(x => x.Id == id).FirstOrDefault();  
        }

        public void Put(Product model)
        {
            _DBcontext.Products.Update(model);
            _DBcontext.SaveChanges();
            
        }
    }
}
