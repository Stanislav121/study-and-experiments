using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Msdn.AsyncAwait.Examples
{
	public class NetFiddle
    {
		//Used for logging duration 
		private static Stopwatch _stopwatch = new Stopwatch();

		public static void Run()
		{
			//MakeBreakfastSync();

			MakeBreakfastAsync().GetAwaiter().GetResult();

			//MakeBreakfastParallel();
		}


		public static void MakeBreakfastSync()
		{
			Console.WriteLine("\n============================");
			Console.WriteLine("\nMakeBreakfastSync\n");

			Console.WriteLine("\nNOTE: The number before the time is current threadId\n");

			StartTimer();

			WriteLog("MakeBreakfastSync Start");

			BoilCoffee();

			ToastBread();

			FryEggs();

			WriteLog("MakeBreakfastSync End");

			Console.WriteLine($"\nTotal time: {_stopwatch.Elapsed.TotalMilliseconds}ms\n");
		}


		private static void StartTimer()
		{
			_stopwatch.Reset();
			_stopwatch.Start();
		}

		private static void BoilCoffee()
		{
			WriteLog("BoilCoffee Start");
			Thread.Sleep(100);   //Do something for 100ms
			WriteLog("BoilCoffee End");
		}

		private static void ToastBread()
		{
			WriteLog("ToastBread Start");
			Thread.Sleep(100);
			WriteLog("ToastBread End");
		}

		private static void FryEggs()
		{
			WriteLog("FryEggs Start");
			Thread.Sleep(100);
			WriteLog("FryEggs End");
		}


		public static void WriteLog(string text)
		{
			string message = Thread.CurrentThread.ManagedThreadId + " " + _stopwatch.Elapsed.ToString(@"mm\:ss\.fff").PadRight(12) + text;
			Console.WriteLine(message);
		}


		public static async Task MakeBreakfastAsync()
		{
			Console.WriteLine("\n============================");
			Console.WriteLine("\nMakeBreakfastAsync");
			Console.WriteLine("\nNOTE: tasks maybe using different threads provided by ThreadPool, but unlike parallel programming, it is only one thread at a time\n");

			StartTimer();

			WriteLog("MakeBreakfastAsync Start");

			Task boilCoffeeTask = BoilCoffeeAsync();
			WriteLog("MakeBreakfastAsync 1");
			//Task toastBreadTask = ToastBreadAsync();
			//WriteLog("MakeBreakfastAsync 2");
			//Task fryEggsTask = FryEggsAsync();
			//WriteLog("MakeBreakfastAsync 3");

			await boilCoffeeTask;
			//await toastBreadTask;
			//await fryEggsTask;

			WriteLog("MakeBreakfastAsync End");

			Console.WriteLine($"\nTotal time: {_stopwatch.Elapsed.TotalMilliseconds}ms\n");
		}


		private static async Task BoilCoffeeAsync()
		{
			WriteLog("BoilCoffeeAsync Start");
			var tsk = Task.Run(SomeWork);
			WriteLog("BoilCoffeeAsync Middle");
			await tsk; //Do steps to boil coffee for 100ms, usually a thread blocking operation that requires async
			WriteLog("BoilCoffeeAsync End");
		}

		private static async Task SomeWork()
		{
			WriteLog("SomeWork Start");
			await Task.Delay(10000);
			WriteLog("SomeWork End");
		}

		private static async Task ToastBreadAsync()
		{
			WriteLog("ToastBreadAsync Start");
			await Task.Delay(100);
			WriteLog("ToastBreadAsync End");
		}

		private static async Task FryEggsAsync()
		{
			WriteLog("FryEggsAsync Start");
			await Task.Delay(100);
			WriteLog("FryEggsAsync End");
		}

		public static void MakeBreakfastParallel()
		{

			Console.WriteLine("\n============================");
			Console.WriteLine("\nMakeBreakfastParallel\n");

			//On .NET FIddle default is 4. We will print it out.
			Console.WriteLine("Available processors: " + Environment.ProcessorCount + "\n");

			//Let's see what happens if only 2 processors are available, since in many cases like IIS under load
			//you will have a lot less processors than tasks running in parallel
			//If you change 2 to 4 than Parallel will work at a bit more like Async, but there is still extra time to start the new threads

			var useProcessors = 2;
			var parallelOptions = new ParallelOptions
			{
				MaxDegreeOfParallelism = useProcessors
			};

			Console.WriteLine("Using processors: " + useProcessors + "\n");

			StartTimer();

			WriteLog("MakeBreakfastParallel Start");

			Parallel.Invoke(parallelOptions,
						   () => BoilCoffee(),
						   () => ToastBread(),
						   () => FryEggs()
						   );

			Console.WriteLine("\nMakeBreakfastParallel End\n");

			Console.WriteLine($"\nTotal time: {_stopwatch.Elapsed.TotalMilliseconds}ms\n");
		}
	}
}
