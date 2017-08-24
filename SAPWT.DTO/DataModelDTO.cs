using SAPWT.HELPER;
using SAPWT.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.DTO
{
    public class DataModelDTO : OWTR
    {
        public DataModelDTO()
        {
            DataModelDetail = new List<DataModelDetailDTO>();
        }

        public ObjectType ObjectType { get; set; }
        public List<DataModelDetailDTO> DataModelDetail { get; set; }
        public String CodigoTienda { get; set; }

    }

    public class DataModelDetailDTO : WTR1
    {
        public String familia_id { get; set; }
        public String subfamilia_id { get; set; }
        public String unidadcompra_id { get; set; }
        public String unidadcosto_id { get; set; }
        public Decimal factor { get; set; }
        public String observacion { get; set; }
    }
}
