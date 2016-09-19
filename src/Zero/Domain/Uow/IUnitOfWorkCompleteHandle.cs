using System;
using System.Threading.Tasks;

namespace Zero.Domain.Uow
{
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        void Complete();

        Task CompleteAsync();
    }
}
