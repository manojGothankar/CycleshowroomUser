using CycleshoroomUserApi.Services;
using CycleshowroomUserData.Database;
using CycleshowroomUserData.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("us", policy =>
    {
     
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });

});

builder.Services.AddDbContext<CSUserSSDbcontext>();

var dbPath = Path.Combine(Directory.GetParent(builder.Environment.ContentRootPath).FullName, "CycleshowroomUserData", "Database", "csdb.db");

builder.Services.AddDbContext<CSUserSLDbcontext>(options =>
 options.UseSqlite($"Data Source={dbPath}"));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    var config = builder.Configuration.GetSection("Jwt");
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience=true,
        ValidateLifetime = true,
        ValidIssuer = config["Issuer"],
        ValidAudience = config["Audience"],
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Key"]))
    };

});



builder.Services.AddAuthorization();

builder.Services.AddScoped<SqlserverToSqliteService>();
builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddScoped<ICycleRepo, CycleRepo>();
builder.Services.AddScoped<IShowroomCycleRepo, ShowroomCycleRepo>();

builder.Services.AddScoped<JwtService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("us");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
