using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Zero.Domain.Uow
{
    /// <summary>
    /// 针对程序集内的uow选项
    /// </summary>
    internal class UnitOfWorkDefaultOptions : IUnitOfWorkDefaultOptions
    {
        public UnitOfWorkDefaultOptions()
        {
            _filters = new List<DataFilterConfiguration>();
        }

        public TransactionScopeOption Scope { get; set; } = TransactionScopeOption.Required;

        public bool IsTransactional { get; set; } = true;

        public TimeSpan? Timeout { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }

        public IReadOnlyList<DataFilterConfiguration> Filters
        {
            get { return _filters; ; }
        }

        private readonly List<DataFilterConfiguration> _filters;

        public void RegisterFilter(string filterName, bool isEnabledByDefault)
        {
            if (_filters.Any(t => t.FilterName == filterName))
                throw new ZeroException($"过滤器:{filterName}已存在");
            _filters.Add(new DataFilterConfiguration(filterName, isEnabledByDefault));
        }

        public void OverrideFilter(string filterName, bool isEnabledByDefault)
        {
            _filters.RemoveAll(f => f.FilterName == filterName);
            _filters.Add(new DataFilterConfiguration(filterName, isEnabledByDefault));
        }
    }
}
