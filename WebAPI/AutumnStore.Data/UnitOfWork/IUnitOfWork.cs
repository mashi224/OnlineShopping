using AutumnStore.Data.Repository.Interfaces;

namespace AutumnStore.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        void Commit();
        void Rollback();
    }
}
