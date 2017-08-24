using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWT.DTO
{
    [XmlRoot("object")]
    public class CompanyDTO
    {
        public Boolean? XMLAsString { get; set; }
        public String Server { get; set; }
        public String LicenseServer { get; set; }
        public BoDataServerTypes DbServerType { get; set; }
        public String DbUserName { get; set; }
        public String DbPassword { get; set; }
        public String CompanyDB { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public BoSuppLangs language { get; set; }
        public Boolean UseTrusted { get; set; }
        public Boolean Connected { get; set; }

        public CompanyDTO()
        {
            XMLAsString = null;
            LicenseServer = String.Empty;
            DbUserName = String.Empty;
            DbPassword = String.Empty;
            CompanyDB = String.Empty;
            UserName = String.Empty;
            Password = String.Empty;
            DbServerType = BoDataServerTypes.dst_MSSQL2012;
            language = BoSuppLangs.ln_English;
        }
    }
}
