using System.Collections.Generic;

namespace Zero.Domain.Uow
{
    /// <summary>
    /// 数据过滤器配置
    /// </summary>
    public class DataFilterConfiguration
    {
        public string FilterName { get; set; }

        public bool IsEnabled { get; set; }

        public IDictionary<string, object> FilterParameters { get; set; }

        public DataFilterConfiguration(string filterName, bool isEnabled)
        {
            FilterName = filterName;
            IsEnabled = isEnabled;
            FilterParameters = new Dictionary<string, object>();
        }

        internal DataFilterConfiguration(DataFilterConfiguration filterToClone, bool? isEnabled = null)
            : this(filterToClone.FilterName, isEnabled ?? filterToClone.IsEnabled)
        {
            foreach (var filterParameter in filterToClone.FilterParameters)
            {
                FilterParameters[filterParameter.Key] = filterParameter.Value;
            }
        }
    }
}
