using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PornApp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();// konfigurise server i glavni pipeline za procesuiranje
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => // ova metoda provajduje neke defolte izmedju ostalog konfigurise licni interni server koji se zove Kestrel- kreiramo hosta
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();// preciziramo Startup klasu koristeci UseStartup metodu 
                });
    }
}
