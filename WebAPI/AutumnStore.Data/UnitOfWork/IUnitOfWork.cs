using AutumnStore.Data.Repository.Interfaces;

namespace AutumnStore.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        void Commit();
        void Rollback();
    }
}
