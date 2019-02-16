using AspLearn.Common;
using AspLearn.Common.Exceptions.GlobalHandler;
using AspLearn.Common.Exceptions.GlobalHandler.Contracts;
using AspLearn.Common.Heloers;
using AspLearn.Common.ResponseBuilder;
using AspLearn.Common.ResponseBuilder.Contracts;
using AspLearn.Data.Repositories.Cities;
using AspLearn.Data.SQL;
using AspLearn.Data.SQL.Contracts;
using AspLearn.Data.TransactionUnits;
using AspLearn.Data.TransactionUnits.Contracts;
using AspLearn.DataBase;
using AspLearn.Services.Cities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;

namespace AspLearn {
    public class Startup {

        /// <summary>
        ///     ASP.NET hosting environment.
        /// </summary>
        private readonly IHostingEnvironment _environment;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment) {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(hostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables();

            Configuration = builder.Build();

            _environment = hostingEnvironment;

            ConfigurationManager.SetAppSettingsProperties(Configuration);
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            //Application database.
            ConfigurateDbConext(services);

            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors();

            //Add mvc.
            services
                .AddMvc()               
                .AddJsonOptions(options => {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1); 

            // Factories.
            services.AddScoped<IResponseFactory, ResponseFactory>();
            services.AddScoped<IGlobalExceptionHandler, GlobalExceptionHandler>();
            services.AddScoped<IGlobalExceptionFactory, GlobalExceptionFactory>();

            // Services.
            services.AddScoped<ICityService, CityService>();

            // Repositories.
            services.AddScoped<ICityRepository, CityRepository>();

            // Transaction unit.
            services.AddTransient<ITransactionUnit, TransactionUnit>();

            //ContextProvider.
            services.AddTransient<ISqlDbContext, SqlDbContext>(); //Resolve DbContext here
            services.AddTransient<ISqlContextFactory, SqlContextFactory>();

            services.Add(new ServiceDescriptor(typeof(ISqlDbContext),
                t => new SqlDbContext(new EfTestDbContext(t.GetService<DbContextOptions<EfTestDbContext>>())), ServiceLifetime.Transient)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGlobalExceptionFactory globalExceptionFactory) {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseDefaultFiles();

            app.UseStaticFiles(new StaticFileOptions {
                RequestPath = "/Data",
                FileProvider = new PhysicalFileProvider(_environment.ContentRootPath + "\\Data"),
                ServeUnknownFileTypes = true
            });

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseCookiePolicy();

            app.UseExceptionHandler(builder => {
                builder.Run(
                        async context => {
                            IExceptionHandlerFeature error = context.Features.Get<IExceptionHandlerFeature>();
                            IGlobalExceptionHandler globalExceptionHandler = globalExceptionFactory.New();

                            await globalExceptionHandler.HandleException(context, error, _environment.IsDevelopment());
                        });
            });

            app.UseMvc();
        }

        /// <summary>
        ///     Configurate database context.
        /// </summary>
        /// <param name="services"></param>
        private void ConfigurateDbConext(IServiceCollection services) {

            services.AddDbContext<EfTestDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringNames.LOCAL_APP));
            });

            //services.AddDbContext<ParentAppIdentityDbContext>(options => {
            //    options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringNames.LOCAL_APP));
            //});

            services.AddScoped(p => new EfTestDbContext(p.GetService<DbContextOptions<EfTestDbContext>>()));
        }
    }
}
