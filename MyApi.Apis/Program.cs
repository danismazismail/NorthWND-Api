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
    //a.UseSqlServer(builder.Configuration["nrtConn"]);
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
        //ValidateIssuerSigningKey = true,
        //IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        //ValidateIssuer = false,
        //ValidateAudience = false
        //
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
/*

WCF => SOAP security 
Authentication (Kimlik Doğrulama) / Authorization (yetkilendirme)  middleware ları aktive edin.


Web Api=> JWT => Json web Token   

Token = Base64 şifrelenmiş 

Client   istek  -> server   (Token oluşturur client dön)


Orderprocess + post
Client   istek + Token  -> server (token tanırsa action ını kullanabilir. Tanımazsa 401 (UnAuthorized))


istek = header +body

Token Örnek :
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdGF0dXMiOiJ0ZWJyaWtsZXIhIDopIn0.sTLXY5iAs1IzJJ-8GVP_pMR65qqgCUpbMl-aSPcrQHc

Token = Header+Payload+Signature

Header: Json olduğunu belirtiriz.  HMAC SHA512 ,RSA  ---->(Base 64, MD5)
{
  "alg": "HS256",
  "typ": "JWT"
}

Payload: bilgi(ler) => claim (tc,username,doğrum tarihi,role,isim,tel)  =base64

{
  "sub": "1234567890",
  "name": "John Doe",
  "iat": 1516239022
}

Signature: min 128 bit => "husamettincindoruk1040"








 
 CORS =>KökenPaylaşımı
JS istekleri (getjson, ajax)
Frontend (css,custom js)

domain paylaşımı ?
api:
http://localhost:15857

http://localhost:5217

UI :

http://localhost:14763
http://localhost:5192

http://www.melike.com
 
 */