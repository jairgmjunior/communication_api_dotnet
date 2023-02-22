using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private IMapper _mapper;
        private IProductRepository _repository;

        public ProductService(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);

            var hasCreated = await _repository.Create(product);

            var productVo = _mapper.Map<ProductVO>(product);

            return productVo;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _repository.FindAll();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);

            product = await _repository.Update(product);

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _repository.FindById(id);

                if (product == null) return false;

                var hasDeleted = await _repository.Delete(product);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
