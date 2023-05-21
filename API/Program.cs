using API.Data;
using API.Repos;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

var builder = WebApplication.CreateBuilder(args);
var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
    .SetMinimumLevel(LogLevel.Trace)
    .AddConsole());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IceLibraryConnectionString")));

//Logger
builder.Services.AddLogging();

//Repositories
builder.Services.AddScoped(typeof(IGenericRepos<>), typeof(GenericRepos<>));

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

//Update Quantity
using (var scope = app.Services.CreateScope())
{
    var bookRepos = scope.ServiceProvider.GetRequiredService<IGenericRepos<Book>>();
    var instanceRepos = scope.ServiceProvider.GetRequiredService<IGenericRepos<Instance>>();

    var books = await bookRepos.GetAll();
    var instances = await instanceRepos.GetAll();
    foreach (var book in books!)
    {
        book.Quantity = instances!.Where(i => i.StatusId == 1 && i.BookId == book.Id).Count();
        await bookRepos.Update(book);
    }
}

app.Logger.LogInformation("Starting Application");

app.Run();
