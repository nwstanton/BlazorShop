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
        public Task<CategoryDto> Create(CategoryDto objDTO);
        public Task<CategoryDto> Update(CategoryDto objDTO);
        public Task<int> Delete(int id);
        public Task<CategoryDto> Get(int id);
        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}
