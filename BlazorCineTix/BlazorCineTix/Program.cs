using Application.Services;
using Application.ServicesInterfaces;
using BlazorCineTix.Components;
using Core.Interfaces;
using Core.RepositoryInterfaces;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register your custom Services with the DI container
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<IActorService, ActorService>();
builder.Services.AddSingleton<IActorRepository, ActorRepository>();

//builder.Services.AddScoped<CinemaService>();
builder.Services.AddSingleton<IProducerService, ProducerService>();
builder.Services.AddSingleton<IProducerRepository, ProducerRepository>();
builder.Services.AddSingleton<MovieService>();


// Register your custom Services with the DI container
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IActorRepository, ActorRepository>();
//builder.Services.AddScoped<CinemaService>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });



var app = builder.Build();
app.UseRouting();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();