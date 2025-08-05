using FracassoShopping.ProductAPI.Data.ValueObjects;

namespace FracassoShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductVO>> FindAll();
        public Task<ProductVO> FindById(long id);
        public Task<ProductVO> Create(ProductVO product); 
        public Task<ProductVO> Update(ProductVO product);
        public Task<bool> Delete(long id);

    }
}
