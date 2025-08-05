using AutoMapper;
using FracassoShopping.ProductAPI.Data.ValueObjects;
using FracassoShopping.ProductAPI.Model;
using FracassoShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace FracassoShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductVO> Create(ProductVO product)
        {
           Product produto = _mapper.Map<Product>(product);
           _context.Products.Add(produto);
           await _context.SaveChangesAsync();
           return _mapper.Map<ProductVO>(produto);
        }

        public async Task<ProductVO> Update(ProductVO product)
        {
            Product produto = _mapper.Map<Product>(product);
            _context.Products.Update(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(produto);

        }

        public async Task<bool> Delete(long id)
        {
            Product product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            else
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Product product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }
    }
}
