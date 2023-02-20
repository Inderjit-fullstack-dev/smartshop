using Microsoft.EntityFrameworkCore;
using Smartshop.Discount.API.Repository.Implementations;
using Smartshop.Discount.gRPC.Data;
using Smartshop.Discount.gRPC.Repository.Contracts;
using Smartshop.Discount.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddDbContext<ApplicationDBContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IDiscountRepository, DiscountRepository>();

var app = builder.Build();


//app.MapGrpcService<GreeterService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
