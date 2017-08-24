using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.HELPER
{
    public class EntityHelper
    {

    }

    public class ApplicationLog
    {
        public ApplicationLog()
        {
            StartDate = DateTime.Now;
            ItemDetail = new List<ItemLog>();
        }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Int32 ItemCount { get; set; }
        public Int32 SuccessCount { get; set; }
        public Int32 ErrorCount { get; set; }
        public List<ItemLog> ItemDetail { get; set; }
    }


    public class DetailLog
    {
        public DetailLog()
        {
            ItemLog = new List<ItemLog>();
        }

        public Int32 Count { get; set; }
        public List<ItemLog> ItemLog { get; set; }
    }

    public class ItemLog
    {
        public Int32 DocEntry { get; set; }
        public ObjectType ObjectType { get; set; }
        public State State { get; set; }
        public ApplicationErrorType ErrorType { get; set; }
        public String Message { get; set; }
    }
}
