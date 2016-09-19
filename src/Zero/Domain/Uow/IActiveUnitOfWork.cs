using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zero.Domain.Uow
{
    public interface IActiveUnitOfWork
    {
        event EventHandler Completed;

        event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        event EventHandler Disposed;

        UnitOfWorkOptions Options { set; }

        bool IsDisposed { get; }

        void SaveChanges();

        Task SaveChangesAsync();

        IReadOnlyList<DataFilterConfiguration> Filters { get; }

        IDisposable DisableFilter(params string[] filterNames);

        IDisposable EnableFilter(params string[] filterNames);

        bool IsFilterEnabled(string filterName);

        IDisposable SetFilterParameter(string filterName, string parameterName, object value);
    }
}
