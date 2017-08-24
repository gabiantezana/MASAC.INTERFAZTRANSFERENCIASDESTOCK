using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.HELPER
{
    public static class SerializeHelper
    {
        public static String ToJson(Object o)
        {
            try
            {
                String json = JsonConvert.SerializeObject(o);
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
