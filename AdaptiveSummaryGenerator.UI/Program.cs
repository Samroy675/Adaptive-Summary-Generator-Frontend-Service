

using AdaptiveSummaryGenerator.UI.Components;
using AdaptiveSummaryGenerator.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ── Services ──────────────────────────────────────────────────────────────────
// Shared app state (thought process toggle, etc.)
builder.Services.AddScoped<AppState>();

// Summary service — swap this line when integrating with your backend:
// builder.Services.AddScoped<ISummaryService, RealSummaryService>();
builder.Services.AddScoped<ISummaryService, DummySummaryService>();

// ── HTTP Client for RealSummaryService (uncomment when integrating) ───────────
// builder.Services.AddHttpClient<ISummaryService, RealSummaryService>(client =>
// {
//     client.BaseAddress = new Uri("https://your-api-base-url/");
// });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
