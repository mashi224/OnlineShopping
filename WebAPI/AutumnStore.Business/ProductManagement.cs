using AutumnStore.Business.Interfaces;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using System;
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
                var productsFromRepo = await _unitOfWork.ProductRepository.GetProducts(categoryId);

                if (productsFromRepo == null)
                {
                    throw new NullReferenceException();
                }

                return productsFromRepo;
        }
    }
}
