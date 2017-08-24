using SAPWT.HELPER;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SAPWT
{
    [RunInstaller(true)]
    public partial class ServiceInstaller : System.Configuration.Install.Installer
    {
        private static String RootPath { get { return new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\").LocalPath; } }
        public ServiceInstaller()
        {
            InitializeComponent();
        }

        private void SEIDOR_MSS_SAPWSS_AfterInstall(object sender, InstallEventArgs e)
        {
            try
            {
                String LogFile = RootPath + ConstantHelper.READMETXT_FILENAME;
                if (File.Exists(LogFile))
                    System.Diagnostics.Process.Start(LogFile);
            }
            catch (Exception) { }

        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
