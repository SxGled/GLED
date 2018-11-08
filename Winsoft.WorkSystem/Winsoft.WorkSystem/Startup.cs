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
using static Winsoft.WorkSystem.Filter.CheckLoginValidationAttribute;

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
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
