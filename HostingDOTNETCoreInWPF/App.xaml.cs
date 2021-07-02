using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace HostingDOTNETCoreInWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
#if GENERICHOST
        private IHost _host;
#else
        private IWebHost _host;
#endif
        private MainWindow mMainWindow;

        private static string WEBROOT = @"S:\w\ExtServer\MVC5\wwwroot\";

#if GENERICHOST

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                     .UseStartup<MVC5.Startup>()
                     .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
                     .UseWebRoot(WEBROOT)         

                          ;

            });


#else
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
                .UseWebRoot(WEBROOT)          


                .UseStartup<MVC5.Startup>()

            ;

#endif



        public App()
        {
#if GENERICHOST
            var bd = CreateHostBuilder(null)

#else
            var bd = CreateWebHostBuilder(null)
#endif

 

            ;

            _host = bd.Build();
            _host.RunAsync();





        }

    }
}
