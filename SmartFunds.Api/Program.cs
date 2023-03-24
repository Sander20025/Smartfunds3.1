using Microsoft.EntityFrameworkCore;
using SmartFunds.Core;
using SmartFunds.Services;
//Test change
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<SmartFundsDbContext>(options =>
{
    options.UseInMemoryDatabase(nameof(SmartFundsDbContext));
});

builder.Services.AddScoped<OrganizationService>();
builder.Services.AddScoped<TransactionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<SmartFundsDbContext>();

    if (dbContext.Database.IsInMemory())
    {
        dbContext.Seed();
    }
}
app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
