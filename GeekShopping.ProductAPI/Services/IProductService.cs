using GeekShopping.ProductAPI.Data.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ActionResult<ProductVO>> FindById(long id);
        Task<ActionResult<ProductVO>> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(long id);
    }
}
