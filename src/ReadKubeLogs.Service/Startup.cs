using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using k8s;
using ReadKubeLogs.Service.config;
using Swashbuckle.AspNetCore.Swagger;

namespace ReadKubeLogs.Service
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
            services.AddMvc();
            InjectKubernetesClient(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v3", new Info
                {
                    Version = "v3",
                    Title = "Kubernetes Log API",
                    Description = "An APi to read Kubernetes logs",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Venkatesh Srinivasan", Email = "venkatesh-5.srinivasan-5@cognizant.com", Url = "http://venkateshoncloud.wordpress.com/" }
                    
                });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "ReadKubeLogs.Service.xml");
                c.IncludeXmlComments(xmlPath);
            });





        }
        private void InjectKubernetesClient(IServiceCollection serviceCollection)
        {
            KubernetesClusterConfigData configData = new KubernetesClusterConfigData();
            Configuration.GetSection("KubernetesClusterConfigData").Bind(configData);
            var k8sClientConfig = new KubernetesClientConfiguration
            {
                Host = configData.Host,
                SkipTlsVerify = configData.SkipSSLVerify,
                ClientCertificateData = configData.ClientCertificateData,
                ClientCertificateKeyData = configData.ClientCertificateKeyData
               ,
                AccessToken = configData.AccessToken
            };
            serviceCollection.AddScoped<IKubernetes, Kubernetes>((service) => new Kubernetes(k8sClientConfig));

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "API to read Kuberenets Log V3");
            });



        }
    }
}
