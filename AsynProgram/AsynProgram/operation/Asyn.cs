using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsynProgram
{
    public class Asyn : AsyncDemoBase
    {
 
        public Asyn()
        {

        }
        public Asyn(string subDemo)
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
        //            runSimpleDomeSync();
        //            break;
        //        default:
        //            runSimpleDome();
        //            break;
        //    }
        //}

        public void simple()
        {
            Console.WriteLine($"Start runSimpleDome which not an sync method");

            Watch.Start();

            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/liqingwen/";

            //两次调用 CountCharacters 方法（同步下载某网站内容，并统计字符的个数）
            int t1 = CountCharacter(1, url1);
            int t2 = CountCharacter(2, url2);

            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            for (var i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }

            //控制台输出
            Console.WriteLine($"{url1} char number：{t1}");
            Console.WriteLine($"{url2} char number：{t2}");

            printend();
        }

        public void Async()
        {
            Console.WriteLine($"Start runSimpleDomeSync");

            Watch.Start();

            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/liqingwen/";

            //两次调用 CountCharactersAsync 方法（异步下载某网站内容，并统计字符的个数）
            Task<int> t1 = CountCharacterAsync(1, url1);
            Task<int> t2 = CountCharacterAsync(2, url2);

            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            for (var i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }

            //控制台输出
            Console.WriteLine($"{url1} char number：{t1.Result}");
            Console.WriteLine($"{url2} char number：{t2.Result}");

            printend();
        }

        #region private method
        private int CountCharacter(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"Begin Inovke id = {id} : {Watch.ElapsedMilliseconds} ms");
            var result = wc.DownloadString(address);

            Console.WriteLine($"End Inovke id ={id} : {Watch.ElapsedMilliseconds} ms");
            return result.Length;
        }

        private async Task<int> CountCharacterAsync(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"Begin Inovke id = {id} : {Watch.ElapsedMilliseconds} ms");
            var result = await wc.DownloadStringTaskAsync(address);

            Console.WriteLine($"End Inovke id ={id} : {Watch.ElapsedMilliseconds} ms");
            return result.Length;
        }
        #endregion
    }
}
