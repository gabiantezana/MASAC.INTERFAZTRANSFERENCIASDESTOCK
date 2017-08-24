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
    public class StockTransferDataAccess
    {
        public List<DataModelDTO> GetDataModelList(LoadContext context)
        {
            List<DataModelDTO> list = context.context.OWTR.Where(x => x.U_MSS_CITR == ConstantHelper.SAP_OPTIONS.YES && x.U_MSS_ESTA == ConstantHelper.MSS_ESTA.PENDIENTE)
                                                            .Select(y => new DataModelDTO
                                                            {
                                                                DocEntry = y.DocEntry,
                                                                Series = y.Series,
                                                                DocNum = y.DocNum,
                                                                TaxDate = y.TaxDate,
                                                                Comments = y.Comments ?? String.Empty,
                                                                ObjectType = ObjectType.StockTransfer
                                                            }).ToList();

            list.ForEach(x => context.context.WTR1.Where(y => y.DocEntry == x.DocEntry)
                                                                .Select(y => new DataModelDetailDTO
                                                                {
                                                                    LineNum = y.LineNum,
                                                                    ItemCode = y.ItemCode,
                                                                    Dscription = y.Dscription,
                                                                    Price = y.Price,
                                                                    Quantity = y.Quantity,
                                                                }).ToList()
                                                                .ForEach(z => x.DataModelDetail.Add(z)));
            return list;
        }

        public void UpdateStockTransfer(LoadContext context, ItemLog item)
        {
            OWTR stockTransfer = context.context.OWTR.FirstOrDefault(x => x.DocEntry == item.DocEntry);
            stockTransfer.U_MSS_ESTA = ((Int32)item.State).ToSafeString();
            if (item.State == State.Error)
                stockTransfer.U_MSS_ERROR = item.Message;

            context.context.Entry(stockTransfer);
            int response = context.context.SaveChanges();
        }
    }
}
