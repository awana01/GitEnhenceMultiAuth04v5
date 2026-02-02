using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnhenceMultiAuth04v4.Core
{
    //public static class LoggerSetup
    //{
    //    public static void Init()
    //    {
    //        Log.Logger = new LoggerConfiguration()
    //            .WriteTo.Console()
    //            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    //            .CreateLogger();
    //    }
    //}

    //public static class LoggerBootstrap
    //{
    //    public static void Initialize(string environment)
    //    {
    //        var configuration = new ConfigurationBuilder()
    //            .AddJsonFile("Config/appsettings.json")
    //            .AddJsonFile($"Config/appsettings.{environment}.json", optional: true)
    //            .Build();

    //        Log.Logger = new LoggerConfiguration()
    //            .ReadFrom.Configuration(configuration)
    //            .Enrich.WithProperty("EnvironmentName", environment)
    //            .CreateLogger();
    //    }

    //    public static void Shutdown()
    //    {
    //        Log.CloseAndFlush();
    //    }
//    }

}
