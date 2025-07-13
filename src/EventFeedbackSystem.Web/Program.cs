using EventFeedbackSystem.Application.Auth;
using EventFeedbackSystem.Application.Events;
using EventFeedbackSystem.Application.Shared.Auth;
using EventFeedbackSystem.Application.Shared.Events;
using EventFeedbackSystem.Core.Auth.Repositories;
using EventFeedbackSystem.Core.Events.Entities;
using EventFeedbackSystem.Core.Events.Repositories;
using EventFeedbackSystem.EntityFrameworkCore.Auth.Repositories;
using EventFeedbackSystem.EntityFrameworkCore.Events.Repositories;
using EventFeedbackSystem.EntityFrameworkCore.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

//EntityFramework Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Events
builder.Services.AddTransient<IEventsRepository, EventRepository>();
builder.Services.AddTransient<IRegisterationRepository, RegisterationRepository>();
builder.Services.AddTransient<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddTransient<IEventsService, EventsService>();
builder.Services.AddTransient<IFeedbackService, FeedbackService>();

//Authentication and Authorization
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Secret"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(oprions =>
{
    oprions.AllowAnyOrigin();
    oprions.AllowAnyHeader();
    oprions.AllowAnyMethod();
});
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        var logger = services.GetRequiredService<ILogger<Program>>();

        await context.Database.MigrateAsync();
        logger.LogInformation("Migrations applied successfully");

        if (context.Events.AsNoTracking().Count() == 0)
        {
            context.Events.Add(new Event("Event 1", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", DateTime.UtcNow - TimeSpan.FromDays(1), "Tehran"));
            context.Events.Add(new Event("Event 2", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", DateTime.UtcNow + TimeSpan.FromDays(1), "Tehran"));
            context.Events.Add(new Event("Event 3", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", DateTime.UtcNow + TimeSpan.FromDays(2), "Tehran"));
            context.Events.Add(new Event("Event 4", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", DateTime.UtcNow + TimeSpan.FromDays(3), "Tehran"));
            context.Events.Add(new Event("Event 5", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", DateTime.UtcNow + TimeSpan.FromDays(4), "Tehran"));
            context.SaveChanges();
        }

    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

app.Run();
