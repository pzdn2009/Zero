using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Zero.Domain.Uow
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        protected UnitOfWorkBase(IUnitOfWorkDefaultOptions defaultOptions)
        {
            DefaultOptions = defaultOptions;
            Id = Guid.NewGuid().ToString("N");
            _filters = defaultOptions.Filters.ToList();
        }
        protected IUnitOfWorkDefaultOptions DefaultOptions { get; }

        /// <summary>
        /// 执行成功的事件
        /// </summary>
        public event EventHandler Completed;

        /// <summary>
        /// 失败的事件
        /// </summary>
        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        /// <summary>
        /// 释放的事件
        /// </summary>
        public event EventHandler Disposed;

        /// <summary>
        /// 外部传入的uow选项
        /// </summary>
        public UnitOfWorkOptions Options { get; set; }

        /// <summary>
        /// 是否已经释放
        /// </summary>
        public bool IsDisposed { get; private set; }
        
        public IReadOnlyList<DataFilterConfiguration> Filters => _filters.ToImmutableList();

        private readonly List<DataFilterConfiguration> _filters;

        /// <summary>
        /// begin是否已经被调用
        /// </summary>
        private bool _isBeginCalledBefore;

        /// <summary>
        /// complete是否已经被调用
        /// </summary>
        private bool _isCompleteCalledBefore;

        /// <summary>
        /// uow是否已经成功完成
        /// </summary>
        private bool _succeed { get; set; }

        /// <summary>
        /// uow执行失败的异常
        /// </summary>
        private Exception _exception;

        public IDisposable DisableFilter(params string[] filterNames)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 启用过滤器
        /// </summary>
        /// <param name="filterNames"></param>
        /// <returns></returns>

        /// <summary>
        /// 禁用过滤器
        /// </summary>
        /// <param name="filterNames"></param>
        /// <returns></returns>
        public IDisposable EnableFilter(params string[] filterNames)
        {
            var enabledFilters = new List<string>();
            foreach (var filterName in filterNames)
            {
                var filterIndex = GetFilterIndex(filterName);
                if (_filters[filterIndex].IsEnabled)
                {
                    enabledFilters.Add(filterName);
                    _filters[filterIndex] = new DataFilterConfiguration(_filters[filterIndex], false);
                }
            }
            //TODO:应用全部过滤器设置
            return new DisposeAction(() => { Console.WriteLine("应用全部过滤器设置"); });
        }

        private int GetFilterIndex(string filterName)
        {
            var filterIndex = _filters.FindIndex(f => f.FilterName == filterName);

            if (filterIndex < 0)
            {
                throw new ZeroException($"不存在的过滤器名称：{filterName}");
            }

            return filterIndex;
        }

        /// <summary>
        /// 过滤器是否启用
        /// </summary>
        /// <param name="filterName"></param>
        /// <returns></returns>
        public bool IsFilterEnabled(string filterName)
        {
            return GetFilter(filterName).IsEnabled;
        }

        private DataFilterConfiguration GetFilter(string filterName)
        {
            var filter = _filters.FirstOrDefault(f => f.FilterName == filterName);
            if (filter == null)
            {
                throw new ZeroException($"不存在的过滤器名称：{filterName}");
            }

            return filter;
        }

        /// <summary>
        /// 设置过滤器的参数
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IDisposable SetFilterParameter(string filterName, string parameterName, object value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            if (!_succeed)
            {
                Failed?.Invoke(this,new UnitOfWorkFailedEventArgs(_exception));
            }

            DisposeUow();
            Disposed?.Invoke(this,EventArgs.Empty);
        }

        /// <summary>
        /// 完成
        /// </summary>
        public void Complete()
        {
            try
            {
                CompleteUow();
                _succeed = true;
                Completed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                _exception = ex;
                throw;
            }

        }

        /// <summary>
        /// 异步完成方法
        /// </summary>
        /// <returns></returns>
        public async Task CompleteAsync()
        {
            try
            {
                await CompleteUowAsync();
                _succeed = true;
                Completed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                _exception = ex;
                throw;
            }
        }

        /// <summary>
        /// uow的Id
        /// </summary>
        public string Id { get; private set; }

        //TODO: ???
        public IUnitOfWork Outer { get; set; }

        /// <summary>
        /// 对外的开始方法
        /// </summary>
        /// <param name="options"></param>
        public void Begin(UnitOfWorkOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            PreventMultipleBegin();

            Options = options;
            SetFilters(options.FilterOverrides);
            BeginUow();
        }

        /// <summary>
        /// 开始Uow
        /// </summary>
        protected abstract void BeginUow();

        /// <summary>
        /// 完成Uow
        /// </summary>
        protected abstract void CompleteUow();

        /// <summary>
        /// 施放Uow
        /// </summary>
        protected abstract void DisposeUow();

        // <summary>
        /// 开始Uow
        /// </summary>
        protected abstract Task BeginUowAsync();

        /// <summary>
        /// 完成Uow
        /// </summary>
        protected abstract Task CompleteUowAsync();

        /// <summary>
        /// 施放Uow
        /// </summary>
        protected abstract Task DisposeUowAsync();

        /// <summary>
        /// 保存动作
        /// </summary>
        public abstract void SaveChanges();

        /// <summary>
        /// 保存动作
        /// </summary>
        public abstract Task SaveChangesAsync();

        /// <summary>
        /// 预防多个Begin运行
        /// </summary>
        private void PreventMultipleBegin()
        {
            if (_isBeginCalledBefore)
                throw new ZeroException("uow正在运行");
            _isBeginCalledBefore = true;
        }

        /// <summary>
        /// 设置被重写的过滤器
        /// </summary>
        /// <param name="filterOverrides"></param>
        private void SetFilters(List<DataFilterConfiguration> filterOverrides)
        {
            for (var i = 0; i < _filters.Count; i++)
            {
                var filterOverride = filterOverrides.FirstOrDefault(f => f.FilterName == _filters[i].FilterName);
                if (filterOverride != null)
                {
                    _filters[i] = filterOverride;
                }
            }
        }

        /// <summary>
        /// 预防多个Complete调用
        /// </summary>
        private void PreventMultipleComplete()
        {
            if (_isCompleteCalledBefore)
            {
                throw new ZeroException("uow已经被完成");
            }

            _isCompleteCalledBefore = true;
        }
    }
}
