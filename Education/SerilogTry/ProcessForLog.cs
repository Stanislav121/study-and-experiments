using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.Elasticsearch;

namespace SerilogTry
{
    class ProcessForLog
    {
        private Logger _log;

        public ProcessForLog()
        {
            //_log = new LoggerConfiguration()
            // .MinimumLevel.Verbose() // ставим минимальный уровень в Verbose для теста, по умолчанию стоит Information 
            // .WriteTo.ColoredConsole()  // выводим данные на консоль
            // .WriteTo.RollingFile(@"C:\Logs\RollingLog-{Date}.txt") // а также пишем лог файл, разбивая его по дате
            // .WriteTo.File(@"C:\Logs\Log-{Date}.txt")
            //  // есть возможность писать Verbose уровень в текстовый файл, а например, Error в Windows Event Logs
            // .CreateLogger();
            _log = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                    IndexFormat = "education-{0:yyyy.MM}"
                })
                .WriteTo.ColoredConsole()
                .CreateLogger();
        }

        public void Run()
        {
            _log.Information("Run");
            var car = new Car(1, "Land Rower", "3Y");
            _log.Information("Car {@Car} was created", car, true);

            var position = new { Latitude = 25, Longitude = 134 };
            var elapsedMs = 34;
            _log.Information("Processed {@Position} in {Elapsed:000} ms.", position, elapsedMs);

            var user = new User() { Id = 3, Login = "Jhon" };
            _log.WithUser(user).Information("Look additional info WithUser");// TODO Don't find info about User in fies, maybe look in elasticksearch?

            _log.ForContext("Car", car, true).Information("Look additional info ForContext {@User}", user, true);
        }
    }
}
