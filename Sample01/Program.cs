﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace Sample01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContent, config) =>
                {
                    var evn = hostingContent.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile(path: $"appsetting.{evn.EnvironmentName}.json", optional: true,
                            reloadOnChange: true)
                        .AddJsonFile(path: "Content.json", optional: false, reloadOnChange: false)
                        .AddEnvironmentVariables();
                })
                .UseStartup<Startup>();
    }
}
