using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using X.Serilog.Sinks.Telegram;

namespace Library;

public class Program
{
    public static void Main(string[] args)
    {
       

        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();


            builder.Host.UseSerilog((connect, lc) => lc
            .WriteTo.Console()
            .WriteTo.File("loging.txt")
            .WriteTo.PostgreSQL(connectionString: builder.Configuration.GetConnectionString("default"), tableName: "loggings", needAutoCreateTable: true)
            .WriteTo.Telegram(builder.Configuration["TelegramToken"], builder.Configuration["ChatId"])
            );







            IConfiguration configuration = builder.Configuration;
            builder.Services.AddInfrastructureServices(configuration);
            builder.Services.AddApplicationServices(configuration);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                options =>
                {
                    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Description = "Library",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http
                    });
                    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                    {{new OpenApiSecurityScheme()
                {
                    Reference=new OpenApiReference()
                    {
                        Id="Bearer",
                        Type=ReferenceType.SecurityScheme
                    }},
                    new List<string>()
                } });
                });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new()
                    {
                        
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!)),
                        ClockSkew=TimeSpan.Zero
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();



            app.Run();
        }
        catch (Exception)
        {


        }
    }
}