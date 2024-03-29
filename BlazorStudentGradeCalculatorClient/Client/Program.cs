using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.Helpers;
using BlazorStudentGradeCalculatorClient.Client.Mappings;
using BlazorStudentGradeCalculatorClient.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("BlazorStudentGradeCalculatorClient.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorStudentGradeCalculatorClient.ServerAPI"));

            builder.Services.AddScoped<ICourseCreditService, CourseCreditService>();
            builder.Services.AddScoped<ICourseDetailService, CourseDetailService>();
            builder.Services.AddScoped<IExammService, ExammService>();
            builder.Services.AddScoped<IHomeWorkService, HomeWorkService>();
            builder.Services.AddScoped<IMidTermService, MidTermService>();
            builder.Services.AddScoped<IOverallGradeService, OverallGradeService>();
            builder.Services.AddScoped<IScoreService, ScoreService>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            builder.Services.AddScoped<IUtility, Utility>();
            builder.Services.AddScoped<IHWUtility, HWUtility>();

            builder.Services.AddAutoMapper(typeof(Mapps));

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
