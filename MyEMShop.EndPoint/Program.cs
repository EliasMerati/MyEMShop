using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace MyEMShop.EndPoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
            
    }
}
