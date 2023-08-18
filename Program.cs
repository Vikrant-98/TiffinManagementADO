using Business.Interface;
using Business.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.Interface;
using Repository.Services;
using System.Text;
using TiffinManagement.Business.Interface;
using TiffinManagement.Business.Services;
using TiffinManagement.DatabaseServices;
using TiffinManagement.MapperServices;
using TiffinManagement.Repository.Interface;
using TiffinManagement.Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITiffinServices, TiffinServices>();
builder.Services.AddTransient<IOrderServices, OrderServices>();
builder.Services.AddTransient<IUserBusiness, UserBusiness>();
builder.Services.AddTransient<ITiffinBusiness, TiffinBusiness>();
builder.Services.AddTransient<IOrderBusiness, OrderBusiness>();
builder.Services.AddTransient<DatabaseMapper>();
builder.Services.AddTransient<DBService>(_=> new DBService(builder.Configuration.GetSection("ConnectionString").Get<string>()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:key").Get<string>()));
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = serverSecret,
                        ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Get<string>(),
                        ValidAudience = builder.Configuration.GetSection("JWT:Audience").Get<string>()
                    };
                });
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Tiffin API",
            Description = "Swagger Api",
            Version = "v1"
        });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            new string[] {}
                    }
                });
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("CorsPolicy");
    app.UseAuthentication();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
