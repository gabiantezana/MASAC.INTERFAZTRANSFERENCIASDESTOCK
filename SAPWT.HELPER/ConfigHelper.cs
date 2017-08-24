using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.HELPER
{
    public static class ConfigHelper
    {
        public static dynamic GetValue(String key, Type type, Boolean throwIfNull = true)
        {
            String ruta = ConfigurationManager.AppSettings[key];
            if (ruta == null & throwIfNull)
                throw new Exception("Key '" + key + "' does not exist in app.config file.");

            dynamic obj =  Convert.ChangeType(ruta, type);

            return obj;
        }
    }
}
