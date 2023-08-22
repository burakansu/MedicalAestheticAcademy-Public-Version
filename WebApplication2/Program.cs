using System.Text.Json.Serialization;
using VeronaAkademi.Ui.Custom;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
     .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddSessionStateTempDataProvider();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IPageMetaData, PageMetaData>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

//app.UseMiddleware<ExceptionHandlingMiddleware>();


if (!app.Environment.IsDevelopment())
    app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    
app.Run();
