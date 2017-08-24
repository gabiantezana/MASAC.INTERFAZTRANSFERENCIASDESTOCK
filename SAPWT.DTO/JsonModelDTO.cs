using Newtonsoft.Json;
using SAPWT.HELPER;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.DTO
{
    public class JsonModelDTO
    {
        public JsonModelDTO()
        {
            detalles = new List<JsonToProcessDetailDTO>();
        }

        /// <summary>
        /// Código SAP de la tienda. 
        /// </summary>
        [Required]
        [MaxLength(10)]
        public String codigo_tienda { get; set; }

        /// <summary>
        /// Id del documento en SAP. (Debe ser único). Servirá para enlazar el documento de transferencia generado en SAP con el documento generado en INFOREST. 
        /// </summary>
        [Required]
        [MaxLength(20)]
        public String documento_id { get; set; }

        /// <summary>
        /// Número del documento generado en SAP para el traslado de mercadería.  (Debe ser único). Con este dato se creara el  documento en INFOREST. 
        /// </summary>
        [Required]
        [MaxLength(20)]
        public String documento { get; set; }

        /// <summary>
        /// Fecha de emisión. 
        /// </summary>
        [Required]
        [MaxLength(10)]
        public String fecha_emision { get; set; }

        /// <summary>
        /// Glosa u observación. 
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [MaxLength(150)]
        public String glosa { get; set; }


        public List<JsonToProcessDetailDTO> detalles { get; set; }

        [JsonIgnore]
        public ObjectType ObjectType { get; set; }
    }

    public class JsonToProcessDetailDTO
    {
        /// <summary>
        /// Longitud Descripción numero_item (*) Integer  
        /// </summary>
        public Int32 numero_item { get; set; }

        /// <summary>
        /// Código SAP del producto. 
        /// </summary>
        [Required]
        [MaxLength(20)]
        public String producto_id { get; set; }

        /// <summary>
        /// Descripción del producto. 
        /// </summary>
        [Required]
        [MaxLength(80)]
        public String descripcion { get; set; }

        /// <summary>
        /// código de familia en SAP, ese código hará referencia a la familia del producto, ejemplo: 01 (alimentos) 
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [MaxLength(10)]
        public String familia_id { get; set; }

        /// <summary>
        ///código de subfamilia en SAP, ese código hará referencia a la subfamilia del producto, ejemplo: 0101 (abarrotes) 
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [MaxLength(10)]
        public String subfamilia_id { get; set; }

        /// <summary>
        /// Unidad de compra, ejemplo: 04 (litros) 
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        public String unidadcompra_id { get; set; }

        /// <summary>
        /// Unidad de producción, ejemplo: 05 (mililitros) 
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        public String unidadcosto_id { get; set; }

        /// <summary>
        /// Factor de conversión entre la unidad de compra y producción, ejemplo: 1000.00
        /// </summary>
        public Decimal factor { get; set; }

        /// <summary>
        /// Precio en la cual ingresara al kardex. 
        /// </summary>
        public Decimal precio_compra { get; set; }

        /// <summary>
        /// Cantidad.
        /// </summary>
        public Decimal cantidad { get; set; }

        /// <summary>
        /// Observación a nivel de ítem. 
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [MaxLength(150)]
        public String observacion { get; set; }
    }


}
