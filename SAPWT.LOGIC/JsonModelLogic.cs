using SAPWT.DATAACCESS;
using SAPWT.DTO;
using SAPWT.HELPER;
using SAPWT.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.LOGIC
{
    internal class JsonModelLogic
    {
        public JsonModelDTO ConvertToJsonModel(DataModelDTO dataModel)
        {
            JsonModelDTO jsonToProcess = new JsonModelDTO();
            jsonToProcess.ObjectType = dataModel.ObjectType;
            jsonToProcess.codigo_tienda = dataModel.CodigoTienda;
            jsonToProcess.documento_id = dataModel.DocEntry.ToString();
            jsonToProcess.documento = dataModel.Series + "-" + dataModel.DocNum;
            jsonToProcess.fecha_emision = dataModel.TaxDate.ToShortStringDate();
            jsonToProcess.glosa = dataModel.Comments;
            jsonToProcess.detalles = dataModel.DataModelDetail.Select(x => ConvertToJsonModel(x)).ToList();
            return jsonToProcess;
        }

        public JsonToProcessDetailDTO ConvertToJsonModel(DataModelDetailDTO dataModelDetail)
        {
            JsonToProcessDetailDTO jsonToProcessDetail = new JsonToProcessDetailDTO();
            jsonToProcessDetail.numero_item = dataModelDetail.LineNum;
            jsonToProcessDetail.producto_id = dataModelDetail.ItemCode;
            jsonToProcessDetail.descripcion = dataModelDetail.Dscription;
            jsonToProcessDetail.familia_id = dataModelDetail.familia_id;
            jsonToProcessDetail.subfamilia_id = dataModelDetail.subfamilia_id;
            jsonToProcessDetail.unidadcompra_id = dataModelDetail.unidadcompra_id;
            jsonToProcessDetail.unidadcosto_id = dataModelDetail.unidadcosto_id;
            jsonToProcessDetail.factor = dataModelDetail.factor;
            jsonToProcessDetail.precio_compra = dataModelDetail.Price ?? default(int);
            jsonToProcessDetail.cantidad = dataModelDetail.Quantity ?? default(int);
            jsonToProcessDetail.observacion = dataModelDetail.observacion;
            return jsonToProcessDetail;
        }

    }
}
