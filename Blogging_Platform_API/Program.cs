using Blogging_Platform_API.Models;
using Blogging_Platform_API.MongoRepo;
using Blogging_Platform_API.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// add mongo db
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton(sp =>
    new MongoRepository<BlogPost>(
        sp.GetRequiredService<IOptions<MongoDbSettings>>(),
        "Posts"));

//builder.Services.AddSingleton(sp =>
//    new MongoRepository<User>(
//        sp.GetRequiredService<IOptions<MongoDbSettings>>(),
//        "Users"));

//builder.Services.AddSingleton(sp =>
//    new MongoRepository<Comment>(
//        sp.GetRequiredService<IOptions<MongoDbSettings>>(),
//        "Comments"));

// add services for blogging platform
builder.Services.AddScoped<IPostsService, PostsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello world! API is live.");

app.Run();
