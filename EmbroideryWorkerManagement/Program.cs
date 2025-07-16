using EmbroideryWorkerManagement.Interfaces;
using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Repositories;
using EmbroideryWorkerManagement.Services.Interfaces;
using EmbroideryWorkerManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IAdvanceSalaryService, AdvanceSalaryService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<IMachineWorkService, MachineWorkService>();
builder.Services.AddScoped<IMonthlyTargetService, MonthlyTargetService>();
//builder.Services.AddScoped<IOvertimePolicyService, OvertimePolicyService>();
//builder.Services.AddScoped<MonthlyPaymentCalculation>();
builder.Services.AddScoped<PaymentSlipPdfService>();
builder.Services.AddScoped<MonthlyPaymentService>();
builder.Services.AddScoped<AutoSalaryGenerator>();
builder.Services.AddScoped<ISalaryCalculationService, SalaryCalculationService>();

var app = builder.Build();

// Automatically apply migrations in production
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Dashboard}/{action=Index}/{id?}");
});

app.Run();
