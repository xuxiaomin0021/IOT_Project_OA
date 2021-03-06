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
using IOT_Project_OA.DAL.IDAL.ILoginDal;
using IOT_Project_OA.DAL.DAL.LoginDal;
using IOT_Project_OA.BLL.IBLL.ILoginBLL;
using IOT_Project_OA.BLL.BLL.LoginBLL;
using IOT_Project_OA.DAL.EmpDAL;
using IOT_Project_OA.BLL.IBLL.SaleIBLL;
using IOT_Project_OA.BLL.BLL.SaleBLL;
using IOT_Project_OA.DAL.IDAL.SaleIDAL;
using IOT_Project_OA.DAL.DAL.SaleDAL;

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
            //跨域配置
            services.AddCors(options =>
            {
                // Policy 名稱 CorsPolicy 是自訂的，可以自己改
                options.AddPolicy("MyCores", builder =>
                {
                    // 設定允許跨域的來源，有多個的話可以用 `,` 隔開
                    builder.WithOrigins("http://localhost:49233", "http://localhost:49236", "")//允许任何来源的主机访问
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();

                });
            });
            //资产档案
            services.AddSingleton<FilesclassIBLL, FilesclassBLL>();
            services.AddSingleton<FilesIBLL, FilesBLL>();
            services.AddSingleton<FilesclassIDAL, FilesclassDAL>();
            services.AddSingleton<FilesIDAL, FilesDAL>();
            //登录注册
            services.AddSingleton<ILogin, Login>();
            services.AddSingleton<ILoginBll, LoginBll>();
            services.AddSingleton<IEmpBLLInterface, EmpBLL>();
            services.AddSingleton<IEmpDAL, EmpDAL>();
            services.AddSingleton<IRegisterBLL, RegisterBLL>();
            services.AddSingleton<IRegisterDal, RegisterDal>();
            //销售管理
            services.AddSingleton<SaleaAdminIBLL, SaleaAdminBLL>();
            services.AddSingleton<SaleaAdminIDAL, SaleaAdminDAL>();

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
