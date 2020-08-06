using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Core.Helpers;
using Core.Security;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
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

            //services.AddCors ile apiye kimin eriþip eriþmediði iznini veriyoruz.

            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IAdvertDal, EfAdvertDal>();
            services.AddScoped<ICompanyDal, EfCompanyDal>();
            services.AddScoped<IProfileDal, EfProfileDal>();
            services.AddScoped<IRecourseDal, EfRecourseDal>();

            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IAdvertManager, AdvertManager>();
            services.AddScoped<ICompanyManager, CompanyManager>();
            services.AddScoped<IProfileManager, ProfileManager>();
            services.AddScoped<IRecourseManager, RecourseManager>();

            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddAutoMapper(cfg=>cfg.AddProfile<AutoMapperProfiles>(),AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
