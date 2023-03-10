using Smartshop.Basket.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddStackExchangeRedisCache(x => x.Configuration = 
    builder.Configuration.GetValue<string>("Redis:ConnectionString"));

builder.Services.AddScoped<IBasket, Basket>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
