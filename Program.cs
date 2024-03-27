using Microsoft.EntityFrameworkCore;
using WoodWorks.Data;
using WoodWorks.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WoodWorkContext>(options => options
	.EnableSensitiveDataLogging()
	.UseSqlServer(builder.Configuration.GetConnectionString("WoodWorksContextDb")));
builder.Services.AddTransient<IWoodWorkSeeder, WoodWorkSeeder>();
builder.Services.AddScoped<IWoodWorkRepository, WoodWorkRepository>();
builder.Services.AddSingleton<IShoppingCartService, ShoppingCartService>();
//builder.Services.AddSession();
//builder.Services.AddHttpContextAccessor();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=App}/{action=Index}/{id?}");


if (args.Length == 1 && args[0].ToLower().Equals("/seed"))
{
	RunSeeding(app);
}
else
{
	app.Run();
}



app.Run();





static void RunSeeding(IHost app)
{
	var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
	using (var scope = scopeFactory.CreateScope())
	{
		var seeder = scope.ServiceProvider.GetService<IWoodWorkSeeder>();
		seeder.SeedData();
	}
}
