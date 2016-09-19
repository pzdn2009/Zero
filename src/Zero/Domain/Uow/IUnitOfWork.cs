
namespace Zero.Domain.Uow
{
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        string Id { get;}

        IUnitOfWork Outer { get; set; }

        void Begin(UnitOfWorkOptions options);
    }
}
