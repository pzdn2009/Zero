using System;
using System.Collections.Generic;

namespace Zero.Domain.Entities
{
    public abstract class EntityBase<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }

        /// <summary>
        /// 主键Key没有赋值/默认值说明是新建的
        /// </summary>
        /// <returns></returns>
        public virtual bool IsNewCreate()
        {
            if (EqualityComparer<TPrimaryKey>.Default.Equals(Id, default(TPrimaryKey)))
            {
                return true;
            }

            if (typeof(TPrimaryKey) == typeof(int))
            {
                return Convert.ToInt32(Id) <= 0;
            }

            if (typeof(TPrimaryKey) == typeof(long))
            {
                return Convert.ToInt64(Id) <= 0;
            }

            return false;
        }
    }
}
