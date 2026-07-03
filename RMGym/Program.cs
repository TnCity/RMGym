using Microsoft.EntityFrameworkCore;
using RMGym.BLL;
using RMGym.Components;
using RMGym.DAL;
using RMGym.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<GymDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<MemberRepository>();
builder.Services.AddScoped<MemberService>();

builder.Services.AddScoped<MembershipPlanRepository>();
builder.Services.AddScoped<MembershipPlanService>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();