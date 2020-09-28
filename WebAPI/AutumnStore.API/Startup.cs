using System.Text;
using AutoMapper;
using AutumnStore.Data;
using AutumnStore.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using AutumnStore.Controller.Assembly;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Business.Interfaces;
using AutumnStore.Business;
using Microsoft.OpenApi.Models;
using Serilog;
using AutumnStore.Data.UnitOfWork;
using EmailService;
using Microsoft.AspNetCore.Http.Features;

namespace AutumnStore.API
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
            // reflection
            var assembly = typeof(SharedController).Assembly;
            services.AddControllers()
                .AddApplicationPart(assembly);

            //// Register the Swagger generator, defining 1 or more Swagger documents.
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Autumn Store", Version = "v1" });
            //});

            var emailConfig = Configuration
               .GetSection("EmailConfiguration")
               .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddScoped<IEmailSender, EmailSender>();

            //-----Send attachment with email-----
            //services.Configure<FormOptions>(o =>
            //{
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = int.MaxValue;
            //    o.MemoryBufferThreshold = int.MaxValue;
            //});


            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // for UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.AddCors();

            services.AddAutoMapper(typeof(AuthRepository).Assembly);

            services.AddScoped<ICategoryManagement, CategoryManagement>();
            services.AddScoped<IAuthManagement, AuthManagement>();
            services.AddScoped<IProductManagement, ProductManagement>();
            services.AddScoped<IPaymentManagement, PaymentManagement>();
            //services.AddScoped<IAuthRepository, AuthRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Autumn Store", Version = "v1" });

                /// <summary>Bearer token authentication.</summary>
                OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                };

                x.AddSecurityDefinition("jwt_auth", securityDefinition);

                /// <summary>Make sure swagger UI requires a Bearer token specified</summary>
                OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Id = "jwt_auth",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
                {
                    { securityScheme, new string[] { } },
                };

                x.AddSecurityRequirement(securityRequirements);


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            //app.UseStaticFiles

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autumn Store API V1");
            });

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
