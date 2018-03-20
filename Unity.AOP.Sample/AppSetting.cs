using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Unity.AOP.Sample
{
    class AppSetting
    {
        [AppSettingMap("001")]
        public string Key001 { get; set; }

        [AppSettingMap("002")]
        public string Key002 { get; set; }

        public string Key003 { get; set; }

        private static AppSetting instance;
        private static readonly object lockObject = new object();


        public static AppSetting GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                        instance = new AppSetting();
                }
            }

            return instance;
        }

        private AppSetting()
        {
            var type = typeof(AppSetting);
            var properties = type.GetProperties();
            foreach(var property in properties)
            {
                var attributes = Attribute.GetCustomAttributes(property, typeof(AppSettingMapAttribute));
                if (attributes.Length <= 0) continue;
                var attribute = attributes[0] as AppSettingMapAttribute;
                var key = attribute.Key;
                if (string.IsNullOrEmpty(key)) continue;
                var value = ConfigurationManager.AppSettings[key];
                property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
            }
        }
    }
}
