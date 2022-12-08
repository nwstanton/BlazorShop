﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Shop_Models;

namespace Shop_Business.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<ProductDTO> Create(ProductDTO objDTO);
        public Task<ProductDTO> Update(ProductDTO objDTO);
        public Task<int> Delete(int id);
        public Task<ProductDTO> Get(int id);
        public Task<IEnumerable<ProductDTO>> GetAll();
    }
}