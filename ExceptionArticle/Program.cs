using ExceptionArticle.Models;
using ExceptionArticle.Persistence.Repositories;
using ExceptionArticle.Services;
using ExceptionArticle.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IYourEntityRepository, YourEntityRepository>();
builder.Services.AddScoped(typeof(IMessageValidator<YourEntity>), typeof(EntityValidator));
builder.Services.AddScoped<IYourEntityService, YourEntityService>();
builder.Services.AddAutoMapper(typeof(Program));

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

await app.RunAsync();