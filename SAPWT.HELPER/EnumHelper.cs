using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.HELPER
{
    public class EnumHelper
    {
    }

    public enum ObjectType
    {
        StockTransfer = 1,
        GoodsReceipt = 2
    }

    public enum State
    {
        Pendiente = 1,
        Exitoso = 2,
        Error = 3
    }

    public enum ApplicationErrorType
    {
        ConvertToJosonModel = 1,
        ValidateJsonProperties = 2,
        Serialize = 3,
        MakeRequest = 4,
        UpdateItemInDB = 5,
        Internal = 6
    }

}
