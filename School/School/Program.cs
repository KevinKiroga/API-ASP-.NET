using School.Mediator.Handlers;
using School.Modules.Student.Infraestructure;
using School.Modules.Student.Logic;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add CORS policy
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectar la dependencia de infraestructura
builder.Services.AddDependencyInfraestructure(builder.Configuration);

// Inyectar la dependencia de logica
builder.Services.AddDependencyLogic();




// Inyectar el AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(School.Modules.Student.Infraestructure.Mapping.MappingProfile));

// Inyectar el MediaTR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(StudentHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Use CORS policy
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();
