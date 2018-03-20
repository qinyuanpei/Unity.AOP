using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.AOP.Sample
{
    [AttributeUsage(AttributeTargets.Property)]
    class AppSettingMapAttribute : Attribute
    {
        public AppSettingMapAttribute(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }
    }
}
