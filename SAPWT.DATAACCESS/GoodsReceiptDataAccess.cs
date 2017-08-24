using SAPWT.DTO;
using SAPWT.HELPER;
using SAPWT.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.DATAACCESS
{
    public class GoodsReceiptDataAccess
    {
        public List<DataModelDTO> GetDataModelList(LoadContext context)
        {
            List<DataModelDTO> list = context.context.OIGN.Where(x => x.U_MSS_CITR == ConstantHelper.SAP_OPTIONS.YES && x.U_MSS_ESTA == ConstantHelper.MSS_ESTA.PENDIENTE)
                                                            .Select(y => new DataModelDTO
                                                            {
                                                                DocEntry = y.DocEntry,
                                                                Series = y.Series,
                                                                DocNum = y.DocNum,
                                                                TaxDate = y.TaxDate,
                                                                Comments = y.Comments ?? String.Empty,
                                                                ObjectType = ObjectType.GoodsReceipt
                                                            }).ToList();

            list.ForEach(x => context.context.IGN1.Where(y => y.DocEntry == x.DocEntry)
                                                            .Select(y => new DataModelDetailDTO
                                                            {
                                                                LineNum = y.LineNum,
                                                                ItemCode = y.ItemCode,
                                                                Dscription = y.Dscription,
                                                                Price = y.Price,
                                                                Quantity = y.Quantity
                                                            }).ToList()
                                                            .ForEach(z => x.DataModelDetail.Add(z)));
            return list;
        }

        public void UpdateGoodsReceipt(LoadContext context, ItemLog item)
        {
            OIGN goodsReceipt = context.context.OIGN.FirstOrDefault(x => x.DocEntry == item.DocEntry);
            goodsReceipt.U_MSS_ESTA = ((Int32)item.State).ToSafeString();
            if (item.State == State.Error)
                goodsReceipt.U_MSS_ERROR = item.Message;

            context.context.Entry(goodsReceipt);
            context.context.SaveChanges();
        }
    }
}
