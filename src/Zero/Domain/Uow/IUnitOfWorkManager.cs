
using System.Transactions;

namespace Zero.Domain.Uow
{
    public interface IUnitOfWorkManager
    {
        IActiveUnitOfWork Current { get; }

        IUnitOfWorkCompleteHandle Begin();

        IUnitOfWorkCompleteHandle Begin(TransactionScopeOption scope);

        IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options);
    }
}
