using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyApi.Core;
using MyApi.DAL.Concrete;
using MyApi.DAL.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyAppDbContext>(a =>
{    
    a.UseSqlServer(builder.Configuration.GetConnectionString("nrtConn"));
});

builder.Services.AddScoped<IOrderDAL, OrderDAL>();
builder.Services.AddScoped<IAuthDAL, AuthDAL>();
builder.Services.AddScoped<IProductDAL, ProductDAL>();

builder.Services.AddCors(a =>
{
    a.AddDefaultPolicy(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

//JWT
var secretKey = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenSettings:TokenSignature").Value);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidateActor = false,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});

//-----------------------------------------

var app = builder.Build();
app.UseCors();
app.UseCors(a => a.WithOrigins("http://localhost:14763").AllowAnyHeader());

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
