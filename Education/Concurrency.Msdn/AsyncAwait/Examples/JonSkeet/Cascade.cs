using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency.Msdn.AsyncAwait.Examples
{
    class Cascade
    {
        public static void PrintPageLenghtAsync()
        {
            Task<int> lenghtTask = GetPageLenghtAsync3("http://csharpindepth.com");
            Console.WriteLine("PrintPageLenghtAsync");
            var a = lenghtTask.Result;
            Console.WriteLine(a);
        }

        private static async Task<int> GetPageLenghtAsync3(string url)
        {
            var a = await GetPageLenghtAsync2(url);
            Console.WriteLine("GetPageLenghtAsync3");
            return a;
        }

        private static async Task<int> GetPageLenghtAsync2(string url)
        {
            var a = await GetPageLenghtAsync1(url);
            Console.WriteLine("GetPageLenghtAsync2");
            return a;
        }

        private static async Task<int> GetPageLenghtAsync1(string url)
        {
            var a = await GetPageLenghtAsync(url);
            Console.WriteLine("GetPageLenghtAsync1");
            return a;
        }

        private static async Task<int> GetPageLenghtAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> fetchTextTask = client.GetStringAsync(url);
                int lenght = (await fetchTextTask).Length;
                Console.WriteLine("Ready");
                return lenght;
            }

        }

        public static void PrintPageLenght()
        {
            int lenghtTask = GetPageLenght("http://csharpindepth.com");
            var a = lenghtTask;
            Console.WriteLine(a);
        }

        private static int GetPageLenght(string url)
        {
            using (WebClient client = new WebClient())
            {
                string fetchTextTask = client.DownloadString(url);
                int lenght = (fetchTextTask).Length;
                return lenght;
            }

        }
    }
}
