using DataAcccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public  interface Iproduct
    {
        void Add( Product model);
        void Delete(int id);
        void Put(Product model);
        List<Product> Get();
        Product GetId(int id);

    }
}
