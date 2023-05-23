using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

builder.Services.addServices();


builder.Services.AddControllers();  

//que conozca las entidades
//builder.Services.AddDbContext<DbProyectoInaContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("dbINA") ?? throw new InvalidOperationException()));
builder.Services.AddDbContext<DbProyectoInaContext>(opt =>opt.UseSqlServer("name=dbINA"));

// Configure the HTTP request pipeline.
 
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//automap
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var MyAllowSpecificOrigins = "apiAngular";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200").WithHeaders("content-type").WithMethods("GET","POST","PATCH","DELETE");
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

