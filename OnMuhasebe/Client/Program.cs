using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Morris.Blazor.Validation;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Client;
using OnMuhasebe.Client.Utils;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddRadzenComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ModalManager>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(ProductDTO).Assembly));
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(UnitDTO).Assembly));
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(CustomerDTO).Assembly));
builder.Services.AddFormValidation(config => config.AddFluentValidation(typeof(CustomerGroupDTO).Assembly));

builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddRadzenComponents();
await builder.Build().RunAsync();
