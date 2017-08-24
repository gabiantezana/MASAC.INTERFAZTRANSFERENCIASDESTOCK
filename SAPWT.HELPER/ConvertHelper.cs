using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.HELPER
{
    public static class ConvertHelper
    {
        public static String ToSafeString(this object val)
        {
            return (val ?? String.Empty).ToString();
        }

        public static String ToShortStringDate(this DateTime? date, Boolean throwIfNull = true)
        {
            String value = String.Empty;
            try
            {
                if (date == null && throwIfNull)
                    throw new Exception("Can't convert a null value to datetime.");

                return date.Value.ToString(ConstantHelper.DATEFORMAT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
