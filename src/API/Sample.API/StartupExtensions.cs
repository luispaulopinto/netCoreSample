﻿using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sample.Api.Middleware;
using Sample.Api.Services;
using Sample.Application;
using Sample.Application.Contracts;
using Sample.Identity;
using Sample.Identity.Models;
using Sample.Infrastructure;
using Sample.Persistence;

namespace Sample.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            //builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            builder.Services.AddHttpContextAccessor();

            builder
                .Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                    // options.SuppressInferBindingSourcesForParameters = true;
                });

            builder.Services.AddCors(options =>
                options.AddPolicy(
                    "open",
                    policy =>
                        policy
                            .WithOrigins(
                                [
                                    builder.Configuration["ApiUrl"] ?? "https://localhost:7081",
                                    builder.Configuration["BlazorUrl"] ?? "https://localhost:7080"
                                ]
                            )
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(pol => true)
                            .AllowAnyHeader()
                            .AllowCredentials()
                )
            );

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            //app.MapIdentityApi<ApplicationUser>();

            // app.MapPost("/Logout", async (ClaimsPrincipal user, SignInManager<ApplicationUser> signInManager) =>
            // {
            //     await signInManager.SignOutAsync();
            //     return TypedResults.Ok();
            // });

            app.UseCors("open");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                // app.UseSwaggerUI();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "Test API V1");
                    c.RoutePrefix = string.Empty; // Set Swagger UI at apps root
                });
            }

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<SampleDbContext>();
                if (context != null)
                {
                    //await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ResetDatabaseAsync Error");
                //add logging here later on
            }
        }
    }
}
