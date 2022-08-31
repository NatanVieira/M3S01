using Escola.Domain.Interfaces.Repository;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Services;
using Escola.Infra.Database;
using Escola.Infra.Database.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EscolaDbContexto>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAlunoRepository,AlunoRepository>();
builder.Services.AddScoped<IAlunoService,AlunoService>();


var app = builder.Build();
app.MapControllers();

if(app.Environment.IsDevelopment()){

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
        options.RoutePrefix = string.Empty;
    });
}

app.Run();