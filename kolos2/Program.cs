using abdp12.Services;
using kolos2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DatabaseContext properly with DI
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer("Data Source=db-mssql;Initial Catalog=s31236;Integrated Security=True;Trust Server Certificate=True;MultipleActiveResultSets=True"));

// Register your service
builder.Services.AddScoped<IDbService, DbService>();

// Other services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();