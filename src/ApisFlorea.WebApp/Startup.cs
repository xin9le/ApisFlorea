using System.Collections.Generic;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;



namespace ApisFlorea
{
    /// <summary>
    /// アプリケーションのエントリーポイントを提供します。
    /// </summary>
    public class Startup
    {
        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {}
        #endregion


        #region ランタイム
        /// <summary>
        /// This method gets called by a runtime.
        /// Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.ConfigureMvcJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Converters = new List<JsonConverter>{ new StringEnumConverter() };
            });
        }


        /// <summary>
        /// Configure is called after ConfigureServices is called.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            // app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute
                (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
        #endregion
    }
}