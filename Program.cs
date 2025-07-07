using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Services;
using ProjetoFinal.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// ========== REGISTRO DE SERVIÇOS (ANTES do Build) ========== //

// 1. Configurações MVC
builder.Services.AddControllersWithViews();

// 2. Configuração do DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 3. Registro dos serviços
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>(); 

builder.Services.AddScoped<IFornecedorService, FornecedorService>();

// Adicione ANTES do builder.Build()
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.Name = "ProjetoFinal.Auth";
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => 
        policy.RequireClaim("Admin"));
});



// ========== CONSTRUÇÃO DA APLICAÇÃO ========== //
var app = builder.Build();  // NUNCA adicione serviços depois desta linha

// ========== CONFIGURAÇÃO DO PIPELINE ========== //

// 1. Migrações automáticas
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// 2. Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 3. Rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "produtos",
    pattern: "produtos/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "relatorios",
    pattern: "relatorios/{action=Index}/{id?}");



app.Run();

