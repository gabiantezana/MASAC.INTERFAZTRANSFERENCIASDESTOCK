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
    internal class DataModelLogic
    {
        public List<DataModelDTO> GetDataModelList(LoadContext loadContext, ObjectType objectType)
        {
            List<DataModelDTO> list = new List<DataModelDTO>();
            switch (objectType)
            {
                case ObjectType.StockTransfer:
                    list = new StockTransferDataAccess().GetDataModelList(loadContext);
                    break;
                case ObjectType.GoodsReceipt:
                    list = new GoodsReceiptDataAccess().GetDataModelList(loadContext);
                    break;
            }

            list.ForEach(x =>
            {
                x.CodigoTienda = ConstantHelper.JsonConstant.codigo_tienda;
                x.DataModelDetail.ForEach(y =>
                {
                    y.familia_id = ConstantHelper.JsonConstant.Detail.familia_id;
                    y.subfamilia_id = ConstantHelper.JsonConstant.Detail.subfamilia_id;
                    y.unidadcompra_id = ConstantHelper.JsonConstant.Detail.unidadcompra_id;
                    y.unidadcosto_id = ConstantHelper.JsonConstant.Detail.unidadcosto_id;
                    y.factor = ConstantHelper.JsonConstant.Detail.factor;
                    y.observacion = ConstantHelper.JsonConstant.Detail.observacion;
                });
            });
            return list;
        }

        public void AUpdateItemInDB(LoadContext loadContext, ItemLog item)
        {
            switch (item.ObjectType)
            {
                case ObjectType.StockTransfer:
                    new StockTransferDataAccess().UpdateStockTransfer(loadContext, item);
                    break;
                case ObjectType.GoodsReceipt:
                    new GoodsReceiptDataAccess().UpdateGoodsReceipt(loadContext, item);
                    break;
                default:
                    break;
            }
        }
    }
}
