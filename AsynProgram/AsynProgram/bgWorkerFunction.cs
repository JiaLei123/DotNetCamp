using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynProgram
{
    class bgWorkerFunction : DemoBase
    {

        public bgWorkerFunction(string subDemo)
        {
            subDemoType = subDemo;
        }

        public override void runDemo()
        {
            switch (subDemoType)
            {
                case "simple":
                case "":
                    runSimpleDome();
                    break;
                case "process":
                    runProcessDome();
                    break;
                case "cancel":
                    runCancel();
                    break;
                default:
                    runSimpleDome();
                    break;
            }
        }


        private void runCancel()
        {
            Watch.Restart();
            Console.WriteLine($"Start run Cancel Dome");
            BackgroundWorker bk = new BackgroundWorker();
            bk.WorkerSupportsCancellation = true;
            bk.WorkerReportsProgress = true;
            bk.ProgressChanged += DoworkProcessChanged;
            bk.DoWork += DoworkProcessCancel;
            bk.RunWorkerAsync(100);

            Thread.Sleep(6000);
            bk.CancelAsync();
            printend();
        }
        private void DoworkProcessCancel(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Console.WriteLine($"Do SUM work with Cancel");
            int sum = 0;
            for (int i = 1; i < (int)e.Argument; i++)
            {
                sum++;
                Thread.Sleep(600);
                worker.ReportProgress(sum);

                if (worker.CancellationPending)
                {
                    Console.WriteLine($"Break SUM work used {Watch.ElapsedMilliseconds} ElapsedMilliseconds time");
                    e.Cancel = true;
                    return;
                }
            }

            Console.WriteLine($"Do SUM work with Process used {Watch.ElapsedMilliseconds} ElapsedMilliseconds time");
        }

        private void runProcessDome()
        {
            Watch.Restart();
            Console.WriteLine($"Start runProcessome");
            BackgroundWorker bk = new BackgroundWorker();
            bk.WorkerReportsProgress = true;
            bk.ProgressChanged += DoworkProcessChanged;
            bk.DoWork += DoworkProcess;
            bk.RunWorkerAsync(100);

            printend();
        }

        private void DoworkProcess(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Console.WriteLine($"Do SUM work with Process");
            int sum = 0;
            for (int i = 1; i < (int)e.Argument; i++)
            {
                sum++;
                Thread.Sleep(600);
                worker.ReportProgress(sum);
            }

            Console.WriteLine($"Do SUM work with Process used {Watch.ElapsedMilliseconds} ElapsedMilliseconds time");
        }

        private void DoworkProcessChanged(object sender, ProgressChangedEventArgs e)
        {

            Console.Write($"== {e.ProgressPercentage} ==");
        }


        private void runSimpleDome()
        {
            Watch.Restart();
            Console.WriteLine($"Start runSimpleDome");
            BackgroundWorker bk = new BackgroundWorker();
            bk.DoWork += doSUMwork;
            bk.DoWork += doSUMworkwithParameter;
            bk.RunWorkerAsync(100);

            printend();
        }

        private void doSUMwork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine($"Do SUM work");
            int sum = 0;
            for(int i = 1; i < 10000; i++)
            {
                sum++;
            }
            Console.WriteLine($"Do SUM work used {Watch.ElapsedMilliseconds} ElapsedMilliseconds time");
        }

        private void doSUMworkwithParameter(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine($"Do SUM work with parameter");
            int sum = 0;
            for (int i = 1; i < (int)e.Argument; i++)
            {
                sum++;
            }
            Console.WriteLine($"Do SUM work with parameter used {Watch.ElapsedMilliseconds} ElapsedMilliseconds time");
        }

    }
}
