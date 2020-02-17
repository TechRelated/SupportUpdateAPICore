using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SupportUpdateAPICore.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.AccessTokenValidation;
using NSwag.AspNetCore;

namespace SupportUpdateAPICore
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
            services.AddDbContextPool<SupportUpdateContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

          
            // services.AddSwagger();

            services.AddControllers();

            services.AddMvc(setupAction => {
                setupAction.EnableEndpointRouting = false;
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
              .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerDocument(o => o.Title = "Core API");

            //new
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<SupportUpdateContext>().AddDefaultTokenProviders();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Tokens:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminAccess", policy =>
                       policy.RequireRole("Admin"));
            });

            /*
             * 
               services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<SupportUpdateContext>()
               .AddDefaultTokenProviders();
              
            ////Configure JWT Token Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = "http://localhost:59001",
                        ValidIssuer = "http://localhost:59001",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SecureKey1234567890123456789012345678901234567890123456789012345678901234567890"))
                    };
                });
             */

            /*  services.AddSession(so =>
              {
                  so.IdleTimeout = TimeSpan.FromSeconds(60);
              });

             // services.AddDistributedMemoryCache();
              //Provide a secret key to Encrypt and Decrypt the Token
              var SecretKey = Encoding.ASCII.GetBytes("supportupdatesecretkey");

              //Configure JWT Token Authentication
              services.AddAuthentication(auth =>
              {
                  auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })

              .AddJwtBearer(token =>
              {
                  token.RequireHttpsMetadata = false;
                  token.SaveToken = true;
                  token.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      //Same Secret key will be used while creating the token
                      IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
                      ValidateIssuer = true,
                      //Usually, this is your application base URL
                      ValidIssuer = "http://localhost:59001/",
                      ValidateAudience = true,
                      //Here, we are creating and using JWT within the same application.
                      //In this case, base URL is fine.
                      //If the JWT is created using a web service, then this would be the consumer URL.
                      ValidAudience = "http://localhost:59001/",
                      RequireExpirationTime = true,
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero
                  };
              });
              */

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<ISupportUpdateRepository, SupportUpdateRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //SeedDB.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
            app.UseRouting();

            //app.UseSession();
            ////Add JWToken to all incoming HTTP Request Header
            //app.Use(async (context, next) =>
            //{
            //    var JWToken = context.Session.GetString("JWToken");
            //    if (!string.IsNullOrEmpty(JWToken))
            //    {
            //        context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
            //    }
            //  //  await next();
            //});
            // Add your NSwag Extension here  
            //app.UseOpenApi();
            //  app.UseSwaggerUi3();

            app.UseSwaggerUi3(options =>
            {
                options.SwaggerRoutes.Add(new SwaggerUi3Route("v1", "/SupportUpdateAPICore/swagger/v1/swagger.json"));
              //  options.Path = "/swagger1";
            });


            /// app.UseOpenApi();
          // app.UseSwaggerUi3(c => c.SwaggerEndpoint("/swagger/V1/swagger.json", "Core API"));


            //Add JWToken Authentication service
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
