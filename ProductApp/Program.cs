using ProductApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<MvcMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext")
    ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

// Add MVC with feature-folder view locations
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Clear();
        options.ViewLocationFormats.Add("/Features/{1}/Views/{0}.cshtml"); // feature-specific views
        options.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");     // shared views in features
        options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");         // standard controller views
        options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");        // fallback to standard shared views
    });

// Register singleton service
builder.Services.AddSingleton<ITimeProvider, AppTimeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Attribute routes will handle HelloWorld routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();