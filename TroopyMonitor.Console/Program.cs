
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace TroopyMonitor.Consolex
{
    public class TownCrier
    {
        private readonly Timer _timer;

        public TownCrier()
        {
            _timer = new Timer(3000) { AutoReset = true };

            // _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} and all is well", DateTime.Now);
            _timer.Elapsed += ElapsedEventHandler;
        }

        public void ElapsedEventHandler(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("It is {0} and all is well", DateTime.Now);

            //var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
            var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady);

            Console.WriteLine("Drives: {0} found", drives.Count());

            foreach (var item in drives)
            {
                Console.WriteLine("  {0}", item.Name);
            }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }

    public class Program
    {
        public static void Main()
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<TownCrier>(s =>
                {
                    s.ConstructUsing(name => new TownCrier());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("4WDPC Host");
                x.SetDisplayName("4WDPC");
                x.SetServiceName("4WDPC");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}