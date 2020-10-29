using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Concurrency.Msdn.AsyncAwait.Helpers;

namespace Concurrency.Msdn.AsyncAwait.Examples.JonSkeet
{
    class ProcessingErrors
    {
        public static void Foo()
        {
            try
            {
                var task = GetNameAsync();
                LogHelper.Write("Result " + task.Result);
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex.GetType().Name);

            }
            
        }

        private static async Task<string> GetNameAsync()
        {
            LogHelper.Write("GetNameAsync1");
            var task = Task.Run(GetName);
            //await Task.Delay(1000);
            LogHelper.Write("GetNameAsync2");
            string line = string.Empty;
            try
            {
                line = await task;
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex.GetType().Name);

            }

            LogHelper.Write("GetNameAsync3");
            return line;
        }

        private static string GetName()
        {
            LogHelper.Write("GetName");
            throw new InvalidOperationException("Exception in GetName");
            return "aaa";
        }
    }
}
