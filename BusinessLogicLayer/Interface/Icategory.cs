using DataAcccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public  interface Icategory
    {
        void Add(Category model);
        void Delete(int id);
        void Put(Category model);
        List<Category> Get();
        Category GetId(int id);
    }
}
