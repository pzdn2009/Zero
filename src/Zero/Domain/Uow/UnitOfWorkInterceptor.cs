using System;
using PostSharp.Aspects;

namespace Zero.Domain.Uow
{
    [Serializable]
    public class UnitOfWorkInterceptor : PostSharp.Aspects.MethodInterceptionAspect
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UnitOfWorkInterceptor(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            //TODO: 暂时先判断方法名不为Get/Query开头的
            if (args.Method.Name.StartsWith("Get") || args.Method.Name.StartsWith("Query"))
            {
                args.Proceed();
                return;
            }
            using (var uow = _unitOfWorkManager.Begin(new UnitOfWorkOptions()))//TODO: 除了Attribute设置外，有没有其他的办法？
            {
                //TODO: ABP为什么要分开执行同步异步方法
                args.Proceed();
                uow.Complete();
            }
        }
    }
}
