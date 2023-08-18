using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Template.WebAPI.Data;
using Template.WebAPI.DBContext;

var builder = WebApplication.CreateBuilder(args);

//Configuring Connection String
var templateConnectionString = builder.Configuration.GetConnectionString("TemplateCS");
builder.Services.AddDbContext<TemplateDBContext>(options => options.UseSqlServer(templateConnectionString));

builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<TemplateDBContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
