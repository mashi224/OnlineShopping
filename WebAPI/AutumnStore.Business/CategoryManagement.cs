using AutumnStore.Business.Interfaces;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutumnStore.Business
{
    public class CategoryManagement: ICategoryManagement
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<IEnumerable<CategoryDto>> GetCategories()
        public async Task<List<CategoryDto>> GetCategories()
        {
                var categoryFromRepo = await _unitOfWork.CategoryRepository.GetCategories();

                if (categoryFromRepo == null)
                {
                    throw new ArgumentNullException();
                }

                return categoryFromRepo;

        }
    }
}
