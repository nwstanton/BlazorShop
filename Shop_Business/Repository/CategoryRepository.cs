using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop_Business.Repository.IRepository;
using Shop_DataAccess;
using Shop_DataAccess.Data;
using Shop_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryDto objDTO)
        {
            var category = _mapper.Map<CategoryDto, Category>(objDTO);
            category.CreatedDate = DateTime.Now;
            var addedObj = _db.Categories.Add(category);

            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDto>(addedObj.Entity);
            
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u=>u.Id == id);
            if(obj != null)
            {
                _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDto> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
              return  _mapper.Map<Category, CategoryDto>(obj);
            }
            return new CategoryDto();
        }
    
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_db.Categories);
        }

        public async Task<CategoryDto> Update(CategoryDto objDTO)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDto>(objFromDb);
            }
            return objDTO;
        }
    }
}
