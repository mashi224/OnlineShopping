using AutumnStore.Business.Interfaces;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutumnStore.Business
{
    public class ProductManagement: IProductManagement
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(int categoryId)
        {
            //var products = await _repo.GetProducts(id);
            //return products;
            return await _unitOfWork.ProductRepository.GetProducts(categoryId);
        }
    }
}
