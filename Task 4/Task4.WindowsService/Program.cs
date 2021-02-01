using System.ServiceProcess;

namespace Task4.WindowsService
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new FileWatcherService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}