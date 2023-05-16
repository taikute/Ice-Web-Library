using WEB.Helpers;
using WEB.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<ApiHelper>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(new MyAuthorization(1, 2, 3));

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
app.UseRouting();
app.UseAuthorization();

//Use TempData
app.UseSession();

//Update Quantity
var apiHelper = new ApiHelper();
var books = await apiHelper.GetAll<Book>("Books");
var instances = await apiHelper.GetAll<Instance>("Instances");
foreach (var book in books!)
{
    book.Quantity = instances!.Where(i => i.StatusId == 1 && i.BookId == book.Id).Count();
    await apiHelper.Put(book, "Books");
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
