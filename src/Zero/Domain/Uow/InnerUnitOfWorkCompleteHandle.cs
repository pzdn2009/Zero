using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Zero.Domain.Uow
{
    internal class InnerUnitOfWorkCompleteHandle : IUnitOfWorkCompleteHandle
    {
        private volatile bool _isCompleteCalled;

        private volatile bool _isDisposed;

        public void Dispose()
        {
            if (_isDisposed)
                return;

            Complete();

            if (!_isCompleteCalled)
            {
                if (HasException())
                    return;
                throw new ZeroException("没有调用完成方法");
            }


        }

        public void Complete()
        {
            _isCompleteCalled = true;
        }

        public async Task CompleteAsync()
        {
            _isCompleteCalled = true;
        }

        private static bool HasException()
        {
            try
            {
                return Marshal.GetExceptionCode() != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
