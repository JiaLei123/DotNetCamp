using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
                default:
                    runSimpleDome();
                    break;
            }
        }


        private void runSimpleDome()
        {
            Watch.Restart();
            BackgroundWorker bk = new BackgroundWorker();
            bk.DoWork += doSUMwork;
            bk.RunWorkerAsync();
            printend();
        }

        private void doSUMwork(object sender, DoWorkEventArgs e)
        {
            int sum = 0;
            for(int i = 1; i < 10000; i++)
            {
                sum++;
            }
        }


    }
}
