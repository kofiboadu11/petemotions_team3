using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetEmotionsApp.Data;
using PetEmotionsApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PetEmotionsAppContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PetEmotionsAppContext") ?? throw new InvalidOperationException("Connection string 'PetEmotionsAppContext' not found.")));

var app = builder.Build();

// Seed data into database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
