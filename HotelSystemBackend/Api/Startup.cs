﻿using Api.Config.Environments;
using Api.Src.Infra.Ioc;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Api
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

            services.AddControllers().AddJsonOptions(config =>
                config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddCors(options =>
                options.AddPolicy(
                    "AllowAll", p =>
                    {
                        p.AllowAnyOrigin();
                        p.AllowAnyMethod();
                        p.AllowAnyHeader();
                    }));

            services.RegisterConnectionServices();
            services.RegisterDependencies();
            services.RegisterHealthChecks();
            services.AddSwaggerConfig("HotelSystemBackend",
                                        "Api desenvolvida para gerenciar hóspedes, suítes e reservas.");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(swaggerOptions =>
                {
                    swaggerOptions.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                    {
                        swaggerDoc.Servers = new List<OpenApiServer> { new() { Url = Constants.APP_URL } };
                    });
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "HotelSystemBackend v1"));

            }
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks();
            });
        }
    }
}
