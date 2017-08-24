using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SAPWT.HELPER;

namespace SAPWT.EXCEPTION
{
    public sealed class ExceptionHelper
    {
        private static String RootPath { get { return new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().GetName().CodeBase) + "\\").LocalPath; } }
        private static String LogApplicationPath { get { return new Uri(System.IO.Path.Combine(RootPath + ConstantHelper.LogApplicationFolderName + "\\")).LocalPath; } }
        private static String LogApplicationErrorPath { get { return Path.Combine(LogApplicationPath + ConstantHelper.LogApplicationErrorFolderName + "\\"); } }

        private ExceptionHelper() { }

        public static void LogException(Exception exc)
        {
            System.IO.Directory.CreateDirectory(LogApplicationErrorPath);
            String LogFile = LogApplicationErrorPath + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            if (!File.Exists(LogFile))
                File.Create(LogFile).Close();

            StreamWriter sw = new StreamWriter(LogFile, true);
            sw.WriteLine("********** {0} **********", DateTime.Now);

            sw.Write("Exception Type: ");
            sw.WriteLine(exc.GetType().ToString());
            sw.WriteLine("Exception: " + exc.Message);
            sw.WriteLine("Stack Trace: ");
            if (exc.InnerException != null)
            {
                sw.Write("Inner Exception Type: ");
                sw.WriteLine(exc.InnerException.GetType().ToString());
                sw.Write("Inner Exception: ");
                sw.WriteLine(exc.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(exc.InnerException.StackTrace);
                }
            }

            if (exc.StackTrace != null)
            {
                sw.WriteLine(exc.StackTrace);
                sw.WriteLine();
            }
            sw.Close();
        }

        public static void LogApplicationInfo(ApplicationLog appLog)
        {

            String LogFile = LogApplicationPath + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            if (!File.Exists(LogFile))
                File.Create(LogFile).Close();

            StreamWriter sw = new StreamWriter(LogFile, true);
            sw.WriteLine("");
            sw.WriteLine("*********************************************************** {0} ***********************************************************", DateTime.Now);

            sw.WriteLine("");
            sw.WriteLine(nameof(appLog.StartDate) + ": " + appLog.StartDate);
            sw.WriteLine(nameof(appLog.FinishDate) + ": " + appLog.FinishDate);
            sw.WriteLine(nameof(appLog.ItemCount) + ": " + appLog.ItemCount);
            sw.WriteLine(nameof(appLog.SuccessCount) + ": " + appLog.SuccessCount);
            sw.WriteLine(nameof(appLog.ErrorCount) + ": " + appLog.ErrorCount);

            if (appLog.ItemDetail.Count > 0)
            {
                sw.WriteLine(nameof(appLog.ItemDetail));
                Int32 lineNumber = 1;
                sw.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5}",
                                                                    "#".PadRight(3, ' '),
                                                                    "STATE".PadRight(5, ' '),
                                                                    "DOCENTRY".PadRight(10, ' '),
                                                                    "DOCUMENT TYPE".PadRight(10, ' '),
                                                                    "ERROR TYPE".PadRight(25, ' '),
                                                                    "MESSAGE".PadRight(10, ' '));

                foreach (var item in appLog.ItemDetail.OrderBy(x => x.State).OrderBy(y => y.ObjectType))
                {

                    sw.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5}",
                                                    lineNumber.ToSafeString().PadRight(3, ' '),
                                                    Enum.GetName(item.State.GetType(), item.State).PadRight(5, ' '),
                                                    item.DocEntry.ToSafeString().PadRight(10, ' '),
                                                    Enum.GetName(item.ObjectType.GetType(), item.ObjectType).PadRight(10, ' '),
                                                    Enum.GetName(item.ErrorType.GetType(), item.ErrorType).PadRight(25, ' '),
                                                    item.Message.PadRight(10, ' '));

                    lineNumber++;
                }
            }

            sw.Close();

        }

        public static void LogApplicationInfo(String message)
        {
            String LogFile = LogApplicationPath + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            if (!File.Exists(LogFile))
                File.Create(LogFile).Close();

            StreamWriter sw = new StreamWriter(LogFile, true);
            sw.WriteLine("");
            sw.WriteLine("************************");
            sw.WriteLine(message);
            sw.WriteLine(DateTime.Now);
            sw.WriteLine("************************");
            sw.Close();

        }
    }
}
