using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.HELPER
{
    public class ConstantHelper
    {
        public static class SAP_OPTIONS
        {
            public const String YES = "Y";
            public const String NO = "N";
        }

        public static class MSS_ESTA
        {
            public static String PENDIENTE = "1";
            public static String EXITOSO = "2";
            public static String ERROR = "3";
        }

        public const String DATEFORMAT = "dd/MM/yyyy";

        /*public const String URL_INFOREST = "http://validate.jsontest.com/?json=";*/
        public const String INFOREST_URL = "http://161.132.106.116/INFOMATICAWS/ServiceInterfaces.svc/InsertarDocumentoEntrada";
        public const String INFOREST_SUCCESSRESPONSE = "Registro guardado correctamente.";
        public const String INFOREST_JSONPROPERTYCONTAINSRESPONSE = "Mensaje";
        public const String JSONMETHOD = "GET";
        public const String JSONCONTENTTYPE = "application/json";

        public static class JsonConstant
        {
            public const String codigo_tienda = "01";
            public static class Detail
            {
                public const String familia_id = " ";
                public const String subfamilia_id = " ";
                public const String unidadcompra_id = "UND";
                public const String unidadcosto_id = "UND";
                public const Decimal factor = 1;
                public const String observacion = "";
            }
        }

        public const double APPLICATION_STARTUP_TIME = 500;
        public const double APPLICATION_INTERNALCYCLE_TIME = 2000;


        public const string ParameterPath = "ErrorLog/";
        public const string LogApplicationPath = "D://";
        public const string LogApplicationFolderName = "ApplicationLog";
        public const string LogApplicationErrorFolderName = "ErrorLog";
        public const string READMETXT_FILENAME = "readme.txt";
        public const string MESSAGE_APPLICATION_STARTED = "WINDOWS SERVICE STARTED";
        public const string MESSAGE_APPLICATION_STOPPED = "WINDOWS SERVICE STOPPED";

        public static class AppConfigKeys
        {
            public const string APPLICATION_STARTUP_TIME = "APPLICATION_STARTUP_TIME";
            public const string APPLICATION_INTERNALCYCLE_TIME = "APPLICATION_INTERNALCYCLE_TIME";
        }
    }
}
