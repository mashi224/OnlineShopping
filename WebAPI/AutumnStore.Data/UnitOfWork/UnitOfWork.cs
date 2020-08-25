using AutoMapper;
using AutumnStore.Data.Repository;
using AutumnStore.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutumnStore.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;
        private IAuthRepository _authRepository;
        private IProductRepository _productRepository;

        public UnitOfWork(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public IAuthRepository AuthRepository
        {
            get { return _authRepository = _authRepository ?? new AuthRepository(_dataContext, _mapper); }
        }

        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository = _categoryRepository ?? new CategoryRepository(_dataContext, _mapper); }
        }

        public IProductRepository ProductRepository
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_dataContext, _mapper); }
        }

        public void Commit()
        {
            _dataContext.SaveChangesAsync();
        }
        
        public void Rollback()
        {
            //_dbContext.
        }
    }
}
