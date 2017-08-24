using Newtonsoft.Json.Linq;
using SAPWT.DTO;
using SAPWT.EXCEPTION;
using SAPWT.HELPER;
using SAPWT.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPWT.LOGIC
{
    public class ApplicationLogic
    {
        private LoadContext LoadContext()
        {
            LoadContext loadCtx = new MODEL.LoadContext();
            loadCtx.context = new MASAC_SEIDOREntities();
            return loadCtx;
        }

        public ApplicationLogic() { }

        public void InitializeService() { ExceptionHelper.LogApplicationInfo(ConstantHelper.MESSAGE_APPLICATION_STARTED); ; }

        public void FinalizeService() { ExceptionHelper.LogApplicationInfo(ConstantHelper.MESSAGE_APPLICATION_STOPPED); ; }

        public void ExecuteProcess()
        {
            ApplicationLog applicationLog = new ApplicationLog();
            try
            {
                List<DataModelDTO> itemsToProces = GetItemsFromDB(LoadContext());

                itemsToProces.ForEach(x => Process(x, ref applicationLog));
                applicationLog.ItemDetail.ForEach(x => UpdateItemInDB(LoadContext(), ref x));
                applicationLog.ItemCount = itemsToProces.Count;
                applicationLog.SuccessCount = applicationLog.ItemDetail.Count(x => x.State == State.Exitoso);
                applicationLog.ErrorCount = applicationLog.ItemDetail.Count(x => x.State != State.Exitoso);
                applicationLog.FinishDate = DateTime.Now;

                ExceptionHelper.LogApplicationInfo(applicationLog);
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogException(ex);
            }

        }

        private void Process(DataModelDTO itemFromDB, ref ApplicationLog applicationLog)
        {
            ItemLog item = new ItemLog();
            try
            {
                String apiResponse = MakeRequest(Serialize(ValidateJsonProperties(ConvertToJosonModel(itemFromDB))));
                item.State = State.Exitoso;
                item.Message = apiResponse;
            }
            catch (Exception ex)
            {
                item.State = State.Error;
                if (ex.GetType() == typeof(CustomException))
                {
                    item.ErrorType = ((CustomException)ex).ApplicationErrorType;
                    item.Message = ex.Message; //TODOG:
                }
                else
                {
                    item.ErrorType = ApplicationErrorType.Internal;
                    item.Message = ex.InnerException.ToSafeString();
                }
            }
            finally
            {
                item.ObjectType = itemFromDB.ObjectType;
                item.DocEntry = itemFromDB.DocEntry;
                applicationLog.ItemDetail.Add(item);
            }
        }

        private List<DataModelDTO> GetItemsFromDB(LoadContext loadContext)
        {
            List<DataModelDTO> stockTransferDBList = new DataModelLogic().GetDataModelList(LoadContext(), ObjectType.StockTransfer);
            List<DataModelDTO> goodsReceiptDBList = new DataModelLogic().GetDataModelList(LoadContext(), ObjectType.GoodsReceipt);

            List<DataModelDTO> itemsToProcess = new List<DataModelDTO>();
            itemsToProcess.AddRange(stockTransferDBList);
            itemsToProcess.AddRange(goodsReceiptDBList);

            return itemsToProcess;
        }

        private JsonModelDTO ConvertToJosonModel(DataModelDTO itemFromDB)
        {
            try
            {
                return new JsonModelLogic().ConvertToJsonModel(itemFromDB);
            }
            catch (Exception ex)
            {
                throw new CustomException(ApplicationErrorType.ConvertToJosonModel, ex);
            }
        }

        private JsonModelDTO ValidateJsonProperties(JsonModelDTO jsonModel)
        {
            try
            {
                new ValidationHelper().Validate(jsonModel);
                return jsonModel;
            }
            catch (Exception ex)
            {
                throw new CustomException(ApplicationErrorType.ValidateJsonProperties, ex);
            }
        }

        private String Serialize(Object o)
        {
            try
            {
                return SerializeHelper.ToJson(o);
            }
            catch (Exception ex)
            {
                throw new CustomException(ApplicationErrorType.Serialize, ex);
            }
        }

        private String MakeRequest(String jsonString)
        {
            try
            {
                String response = ApiRestHelper.MakeRequest(ConstantHelper.INFOREST_URL, jsonString);

                string message = JObject.Parse(response)[ConstantHelper.INFOREST_JSONPROPERTYCONTAINSRESPONSE].ToSafeString();
                if (message != ConstantHelper.INFOREST_SUCCESSRESPONSE)
                    throw new Exception(message);

                return response;
            }
            catch (Exception ex)
            {
                throw new CustomException(ApplicationErrorType.MakeRequest, ex);
            }
        }

        private void UpdateItemInDB(LoadContext loadContext, ref ItemLog item)
        {
            try
            {
                new DataModelLogic().AUpdateItemInDB(loadContext, item);
            }
            catch (Exception ex)
            {
                item.ErrorType = ApplicationErrorType.UpdateItemInDB;
                item.Message = ex.Message;
            }
        }

        private static string ParameterPath
        {
            get
            {
                string pathDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string pathArch = System.IO.Path.Combine(pathDir, ConstantHelper.ParameterPath);
                var localPath = new Uri(pathArch).LocalPath;
                return localPath;
            }
        }
    }
}
