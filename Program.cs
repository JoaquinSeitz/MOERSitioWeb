using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MOERSitioWeb;
using MOERSitioWeb.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


// 1. Configurar HttpClient apuntando a tu backend local de MOER Estética
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7133/") });

// 2. Registrar nuestro LocalStorageService
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<CatalogoService>();
builder.Services.AddScoped<TurnoService>();
builder.Services.AddScoped<PedidoService>(); // Agregado
builder.Services.AddScoped<CarritoService>(); // Agregado
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<ProductoAdminService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ServicioAdminService>();
builder.Services.AddScoped<PagoService>();

// 3. Registrar el proveedor de estado de autenticación
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

// 4. Registrar los servicios de MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();