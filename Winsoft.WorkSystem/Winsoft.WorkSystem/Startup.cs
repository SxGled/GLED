using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Winsoft.WorkSystem.Context;
using Winsoft.WorkSystem.Filter;
using Swashbuckle.AspNetCore.Swagger;
using static Winsoft.WorkSystem.Filter.CheckLoginValidationAttribute;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Winsoft.WorkSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //进行数据库连接
            services.AddDbContext<basisContext>(d => d.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMemoryCache();
            //全局使用过滤器
            services.AddMvc(options => {
                options.Filters.Add(typeof(ModelValidationAttribute));//模型验证
                options.Filters.Add(typeof(CheckLoginValidationAttributeImpl));
                //options.Filters.Add(typeof(ModelValidationAttribute));
            });
            //services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "工作台系统API接口文档"
                });
                //Determine base path for the application.    
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Winsoft.WorkSystem.xml");

                c.IncludeXmlComments(xmlPath);
            });
            }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,  ILoggerFactory loggerFactory)
        {
            //添加Log日志
            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
#if !DEBUG
            //设置exception handler 异常处理程序
            app.UseExceptionHandlingMiddleware();
#endif


            //创建wwwroot目录
            //app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Template")),
            //    RequestPath = new PathString("/xls")
            //});
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "JsonFile")),
            //    RequestPath = new PathString("/json")
            //});

            //总支数据
            //departmentContext.EnsureSeedDataForContext();
            //departmentContext.EnsureSeedDataForContexts();

            //跨域请求
            //app.Use(async (context, next) =>
            //{
            //    //支持全域名访问，不安全，部署后需要限制为
            //    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //    //支持的http动作
            //    context.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,OPTIONS,DELETE");
            //    //响应头
            //    context.Response.Headers.Add("Access-Control-Allow-Headers", "X-PINGOTHER,X-Requested-With,Content-Type,Authorization");
            //    if (context.Request.Method == "OPTIONS")
            //        context.Response.StatusCode = 204;
            //    else
            //        await next();
            //});

            //添加swagger启动
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Winsoft.WorkSystem API PrivateCase");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors(builder => builder
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials());
            app.UseMvc();
        }
    }
}
