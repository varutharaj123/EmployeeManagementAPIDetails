using System.Text;

using EmployeeManagement.Application;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services
.AddAuthentication(
JwtBearerDefaults.AuthenticationScheme)

.AddJwtBearer(options =>
{

    options.TokenValidationParameters =
    new TokenValidationParameters
    {

        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,


        ValidIssuer =
    builder.Configuration["Jwt:Issuer"],


        ValidAudience =
    builder.Configuration["Jwt:Audience"],


        IssuerSigningKey =
    new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(
    builder.Configuration["Jwt:Key"]!
    ))

    };

});



builder.Services.AddAuthorization();


builder.Services.AddControllers();



builder.Services.AddDbContext<EmployeeDbContext>
(
options =>
options.UseSqlServer(
builder.Configuration
.GetConnectionString("DefaultConnection"))
);



builder.Services.AddApplication();

builder.Services.AddInfrastructure();






builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


//builder.Services.AddSwaggerGen(option =>
//{

//    option.AddSecurityDefinition(
//    "Bearer",
//    new OpenApiSecurityScheme
//    {

//        Name = "Authorization",

//        Type = SecuritySchemeType.Http,

//        Scheme = "Bearer",

//        BearerFormat = "JWT",

//        In = ParameterLocation.Header,

//        Description = "Enter JWT Token"

//    });



//    option.AddSecurityRequirement(
//    new OpenApiSecurityRequirement
//    {

//{
//new OpenApiSecurityScheme
//{

//Reference =
//new OpenApiReference
//{

//Type=ReferenceType.SecurityScheme,

//Id="Bearer"

//}

//},

//Array.Empty<string>()

//}

//    });

//});



var app = builder.Build();



if (app.Environment.IsDevelopment())
{

    app.UseSwagger();

    app.UseSwaggerUI();

}



app.UseHttpsRedirection();


app.UseAuthentication();


app.UseAuthorization();


app.MapControllers();


app.Run();