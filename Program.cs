using Microsoft.EntityFrameworkCore;
using RankingAppTT.DAL;
using RankingAppTT.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NewConnection")));
builder.Services.AddTransient<IItemRepository, ItemRepository>();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

