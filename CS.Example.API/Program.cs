using CS.Example.Business.Interfaces;
using CS.Example.Business.Root;
using CS.Example.Data.Interfaces;
using CS.Example.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient(typeof(IUsuarioService), typeof(UsuarioService));
builder.Services.AddTransient(typeof(IBusinessUsuario), typeof(BusinessUsuario));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(options => options
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
