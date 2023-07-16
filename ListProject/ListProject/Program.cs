using ListProject.DAL;
using ListProject.DAL.Interfaces;
using ListProject.DAL.Repositories;
using ListProject.Domain.Entity;
using ListProject.Service.implementation;
using ListProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//......Подключение к дб через AppDbContext (DbContext)............//
var connectstr = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectstr);
});
//..................................//

//..........Регистрация репозитория и сервиса.......................//
builder.Services.AddScoped<IBaseRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
//..................................//

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); // .AddRazorRuntimeCompilation() для изменений view через перезапуск страницы

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
     app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
