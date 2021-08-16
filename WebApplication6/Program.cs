using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.ConfigAdapter;
using Com.Ctrip.Framework.Apollo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo.Logging;
using Com.Ctrip.Framework.Apollo.Core;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WebApplication6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

             .ConfigureAppConfiguration((hostingContext, builder) =>
             {
                 builder
                 .AddApollo(builder.Build().GetSection("apollo"))
                 .AddDefault();
                 //.AddNamespace("UUPT-Service.DbConnectConfig"); //Apollo中NameSpace的名称

             })
                //.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
                //{
                //    //注入配置 把阿波罗的日志级别调整为最低
                //    LogManager.UseConsoleLogging(Com.Ctrip.Framework.Apollo.Logging.LogLevel.Trace);
                //    configurationBuilder
                //        .AddApollo(configurationBuilder.Build().GetSection("apollo"))
                //        .AddDefault()
                //     .AddNamespace(ConfigConsts.NamespaceApplication);
                //})
                //.AddApollo(new ApolloOptions
                //{
                //    AppId = ConfigurationManager.AppSettings["Apollo:AppId"],
                //    MetaServer = ConfigurationManager.AppSettings["Apollo:MetaServer"],
                //    Secret = ConfigurationManager.AppSettings["Apollo:Secret"]
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
