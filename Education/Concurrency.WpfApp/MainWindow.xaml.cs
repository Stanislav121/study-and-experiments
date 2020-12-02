using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Concurrency.Msdn.AsyncAwait.Helpers;

namespace Concurrency.WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            LogHelper.Write("Exception");
        }

        private static readonly HttpClient s_httpClient = new HttpClient();

        private void downloadBtnSC_Click(object sender, RoutedEventArgs e)
        {
            SynchronizationContext sc = SynchronizationContext.Current;
            s_httpClient.GetStringAsync("http://csharpindepth.com").ContinueWith(downloadTask =>
            {
                sc.Post(delegate
                {
                    Label1.Content = downloadTask.Result;
                }, null);
            });
        }

        private async void downloadBtn_Clickff(object sender, RoutedEventArgs e)
        {
            object scheduler = SynchronizationContext.Current;
            if (scheduler is null && TaskScheduler.Current != TaskScheduler.Default)
            {
                scheduler = TaskScheduler.Current;
            }
        }


        private void downloadBtn_Click(object sender, RoutedEventArgs e)
        {
            LogHelper.Write(TaskScheduler.FromCurrentSynchronizationContext().ToString());
            s_httpClient.GetStringAsync("http://csharpindepth.com").ContinueWith(downloadTask =>
            {
                Label1.Content = downloadTask.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SynchronizationContext a = SynchronizationContext.Current;
            LogHelper.Write(a.ToString());
               Label1.Content = PressMe().Result.Length;
        }

        private async Task<string> PressMe()
        {
            string line;
            Task<string> task;
            using (HttpClient client = new HttpClient())
            {
                task = client.GetStringAsync("http://csharpindepth.com");
                line = await task.ConfigureAwait(false);
            }
            throw new Exception("Hha");
            return line;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SynchronizationContext a = SynchronizationContext.Current;
            LogHelper.Write("sc= " + a.ToString());
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
            var task = FooAsyncConfigureAwait();
            a = SynchronizationContext.Current;
            LogHelper.Write("sc= " + a.ToString());
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
            task.Wait();
            Label1.Content = "No Deadlock";
        }

        private async Task FooAsyncConfigureAwait()
        {
            SynchronizationContext a = SynchronizationContext.Current;
            LogHelper.Write("sc= " + a.ToString());
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
            var task = Task.Delay(10000);
            a = SynchronizationContext.Current;
            LogHelper.Write("sc= " + a.ToString());
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
            await task.ConfigureAwait(false);
            a = SynchronizationContext.Current;
            LogHelper.Write("ts= " + TaskScheduler.Current.ToString());
            //LogHelper.Write(a.ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var task = FooAsync();
            task.Wait();
            Label1.Content = "Deadlock";
        }

        private async Task FooAsync()
        {
            await Task.Delay(1000);
        }
    }
}
