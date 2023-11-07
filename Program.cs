var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();  
builder.Services.AddSession();
builder.Services.AddControllersWithViews();  
var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.UseSession();

// Resto de la configuración de rutas y lógica de la aplicación

app.MapControllerRoute(name: "default",    
    pattern: "{controller=PrincipalController}/{action=Index}/{id?}");

app.Run();
