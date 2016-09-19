
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Zero.Domain.Uow
{
    /// <summary>
    /// 对外的uow选项
    /// </summary>
    public class UnitOfWorkOptions
    {
        /// <summary>
        /// 事务范围
        /// </summary>
        public TransactionScopeOption? Scope { get; set; }

        /// <summary>
        /// 是否为uow事务
        /// </summary>
        public bool? IsTransactional { get; set; }

        /// <summary>
        /// 事务超时时间(分钟)
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 隔离级别
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 跨事务级别选项
        /// </summary>
        public TransactionScopeAsyncFlowOption? AsyncFlowOption { get; set; }

        /// <summary>
        /// 启用/禁用过滤器
        /// </summary>
        public List<DataFilterConfiguration> FilterOverrides { get; private set; }

        public UnitOfWorkOptions()
        {
            FilterOverrides = new List<DataFilterConfiguration>();
        }

        internal void FillDefaultsForNonProvidedOptions(IUnitOfWorkDefaultOptions defaultOptions)
        {
            //TODO: Do not change options object..?

            if (!IsTransactional.HasValue)
            {
                IsTransactional = defaultOptions.IsTransactional;
            }

            if (!Scope.HasValue)
            {
                Scope = defaultOptions.Scope;
            }

            if (!Timeout.HasValue && defaultOptions.Timeout.HasValue)
            {
                Timeout = defaultOptions.Timeout.Value;
            }

            if (!IsolationLevel.HasValue && defaultOptions.IsolationLevel.HasValue)
            {
                IsolationLevel = defaultOptions.IsolationLevel.Value;
            }
        }
    }
}
