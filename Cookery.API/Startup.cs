using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Cookery.API.Database;
using Cookery.API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cookery.API
{
  public class Startup
  {
    public Startup (IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices (IServiceCollection services)
    {
      // microsoft entity framework sqlite
      services.AddDbContext<DataContext> (x => x.UseSqlite (Configuration.GetConnectionString ("DefaultConnection")));
      services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

      // enable cors service
      services.AddCors ();

      // singleton, transient : light weight stateless services,
      services.AddScoped<IAuthRepository, AuthRepository> ();

      // authorization with JWT
      services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer (options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
          // need to validate the sign
          ValidateIssuerSigningKey = true,
          // use the same signature key 
          IssuerSigningKey = new SymmetricSecurityKey (Encoding.ASCII
          .GetBytes (Configuration.GetSection ("AppSettings:Token").Value)),
          // we dont need to validate issurt & audience
          ValidateIssuer = false,
          ValidateAudience = false
          };
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment ())
      {
        app.UseDeveloperExceptionPage ();
      }
      else
      {
        // catch all errors globally
        app.UseExceptionHandler (builder =>
        {
          builder.Run (async context =>
          {
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            var error = context.Features.Get<IExceptionHandlerFeature> ();
            if (error != null)
            {
              // slap header to the response
              context.Response.AddApplicationError (error.Error.Message);
              await context.Response.WriteAsync (error.Error.Message);
            }
          });
        });
        // app.UseHsts();
      }

      // app.UseHttpsRedirection();

      // enable cors 
      app.UseCors (x => x.AllowAnyOrigin ().AllowAnyMethod ().AllowAnyHeader ());

      // Authentication middle ware
      app.UseAuthentication ();

      // middleware
      app.UseMvc ();
    }
  }
}