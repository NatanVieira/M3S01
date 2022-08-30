var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

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