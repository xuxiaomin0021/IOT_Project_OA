using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IOT_Project_OA.DAL;
using IOT_Project_OA.BLL;
using IOT_Project_OA.BLL.IBLL.AssetsIBLL;
using IOT_Project_OA.BLL.BLL.AssetsBLL;
using IOT_Project_OA.DAL.IDAL.AssetsIDAL;
using IOT_Project_OA.DAL.DAL.AssetsDAL;

namespace IOT_Project_OA.API
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
            services.AddControllers();
            //��������
            services.AddCors(options =>
            {
                // Policy ���Q CorsPolicy ����ӆ�ģ������Լ���
                options.AddPolicy("MyCores", builder =>
                {
                    // �O�����S����ā�Դ���ж�����Ԓ������ `,` ���_
                    builder.WithOrigins("http://localhost:49233", "http://localhost:49236")//�����κ���Դ����������
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
            });
            //�ʲ�����
            services.AddSingleton<FilesclassIBLL, FilesclassBLL>();
            services.AddSingleton<FilesIBLL, FilesBLL>();
            services.AddSingleton<FilesclassIDAL, FilesclassDAL>();
            services.AddSingleton<FilesIDAL, FilesDAL>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("MyCores");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
