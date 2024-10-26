using System.Text;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Repository;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IAppDbContext, AppDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("DBCS")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<RoomServices>();
builder.Services.AddScoped<GuestServices>();
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>) );
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x=> new TokenValidationParameters()
{
    ValidIssuer = "Us",
    ValidAudience = "Us",
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWTsecret").Value)),
    ValidateIssuerSigningKey = true
});
/*var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(ToDoItemMapping).Assembly);*/
var app = builder.Build();

// Configure the HTTP request pipeline.
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
