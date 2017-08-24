using SAPWT.HELPER;
using SAPWT.LOGIC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SAPWT
{
    public partial class MainService : ServiceBase
    {
        private Timer timer;
        private ApplicationLogic MainApplication;

        public MainService()
        {
            InitializeComponent();
            MainApplication = new ApplicationLogic();
        }

        protected override void OnStart(string[] args)
        {
            MainApplication.InitializeService();
            timer = new Timer(ConfigHelper.GetValue(ConstantHelper.AppConfigKeys.APPLICATION_STARTUP_TIME, typeof(double)));
            timer.Start();
            timer.Interval = ConfigHelper.GetValue(ConstantHelper.AppConfigKeys.APPLICATION_INTERNALCYCLE_TIME, typeof(double));
            timer.AutoReset = false;
            timer.Elapsed += new ElapsedEventHandler(Elapsed_Event);
            timer.Enabled = true;
        }

        private void Elapsed_Event(object sender, ElapsedEventArgs e)
        {
            try
            {
                timer.Enabled = false;
                MainApplication.ExecuteProcess();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        protected override void OnStop()
        {
            MainApplication.FinalizeService();
            timer.Dispose();
        }
    }
}
