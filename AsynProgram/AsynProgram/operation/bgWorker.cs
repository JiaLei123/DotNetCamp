using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynProgram
{
    class bgWorker : AsyncDemoBase
    {

        public bgWorker(string subDemo)
        {
            subDemoType = subDemo;
        }

        //public override void runSyncDemo()
        //{
        //    switch (subDemoType)
        //    {
        //        case "simple":
        //        case "":
        //            runSimpleDome();
        //            break;
        //        case "process":
        //            runProcessDome();
        //            break;
        //        case "cancel":
        //            runCancel();
        //            break;
        //        case "exception":
        //            break;
        //        default:
        //            runSimpleDome();
        //            break;
        //    }
        //}

        public void Simple()
        {
            Watch.Restart();
            Console.WriteLine($"Start runSimpleDome");
            BackgroundWorker bk = new BackgroundWorker();
            bk.DoWork += doSUMwork;
            bk.DoWork += doSUMworkwithParameter;
            bk.RunWorkerAsync(100);

            printend();
        }

        //在worker内部产生process change事件，由process change event来通知外部程序：例如通知processbar
        public void ProcessChange()
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

        public void Exception()
        {
            Watch.Restart();
            Console.WriteLine($"Start run Exception Dome");
            BackgroundWorker bk = new BackgroundWorker();
            bk.WorkerSupportsCancellation = true;
            bk.WorkerReportsProgress = true;
            bk.ProgressChanged += DoworkProcessChanged;
            bk.DoWork += DoworkProcessCancel;
            bk.RunWorkerCompleted += DoWorkCompleted;
            bk.RunWorkerAsync(100);

            Thread.Sleep(6000);
            bk.CancelAsync();
            printend();
        }

        public void Cancel()
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


        #region worker function

        private void doSUMwork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine($"Do SUM work");
            int sum = 0;
            for (int i = 1; i < 10000; i++)
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

        private void DoWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Type errorType = e.Error.GetType();
            }
            throw new NotImplementedException();
        }
        #endregion
    }
}
