using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using System.Configuration;
using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql;
using Hotel;
using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.Identity.Client;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Hotel.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.OpenApi.Models;

namespace Hotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "Введите токен авторизации",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                            },
                            Scheme = "oauth2",
                            Name = JwtBearerDefaults.AuthenticationScheme,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            builder.Services.AddTransient<IVisitorsService,  VisitorsService>();
            builder.Services.AddTransient<IRoomsService, RoomsService>();
            builder.Services.AddTransient<IOrdersService, OrdersService>();
            builder.Services.AddTransient<IAuth, AuthService>();
            builder.Services.AddTransient<IUsers, UserService>();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(builder.Configuration.GetConnectionString("MySql"), new MySqlServerVersion(new Version(8, 0, 33)));
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,

                    };
                });
            var app = builder.Build();

            // Configure the HTTP request pipeline
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opt => opt.DefaultModelExpandDepth(-1));

            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            
            app.MapControllers();

            app.Run();
        }
    }
}

/*using Microsoft.EntityFrameworkCore;
using CoolerLibrary.Entities.Data;
using System.Configuration;
using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql;

namespace CoolerLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI a
            //builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Library"));
            //builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql("server = localhost;user = root; password = Niggers; Port = 5433; Database = Library.db"), new MySqlServerVersion(8.0.33));
            // builder.Services.AddDbContext<DataContext>(options =>
            //options.UseMySql(DataContext.GetConnectionString("server = localhost;user = root; password = Niggers; Port = 5433; Database = Library.db"))
            builder.Services.AddDbContext < DataContext>(options  =>
            {
                options.UseMySql(builder.Configuration.GetConnectionString("MySql"),new MySqlServerVersion(new Version(8, 0, 33)));
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.DefaultModelsExpandDepth(-1));
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}*/