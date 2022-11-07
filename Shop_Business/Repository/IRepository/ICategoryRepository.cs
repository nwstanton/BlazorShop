using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Shop_Models;

namespace Shop_Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public CategoryDto Create(CategoryDto objDTO);
        public CategoryDto Update(CategoryDto objDTO);
        public int Delete(int id);
        public CategoryDto Get(int id);
        public IEnumerable<CategoryDto> GetAll();
    }
}
