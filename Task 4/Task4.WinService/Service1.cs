using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task4.BL;

namespace WinService
{
    public partial class Service1 : ServiceBase
    {
        Logger logger;
        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }
 
        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
        }
 
        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
        }
    }
 
    class Logger
    {
        FileSystemWatcher watcher;
        bool enabled = true;
        public Logger()
        {
            FileWatcher FW = new FileWatcher();
            watcher = new FileSystemWatcher("D:\\Temp");
            watcher.Created += FW.Watcher_Created;
        }
 
        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while(enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }
    }
}
