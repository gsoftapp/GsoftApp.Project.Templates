using GsoftApp.Framework.Development;
using GsoftApp.Framework.Web.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Add DAF to bootstrap your application (codename GNode). And install the "Development" module.
builder.Services.AddDaf(builder.Configuration, o => o.CustomModules.Add(new DevelopmentModule()));

var app = builder.Build();

app.UseStaticFiles();

//Register a new static file handler to serve framework resources from embedded images and files.
app.UseDaf();

app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();

//Register DAF end-points under the root (/). Use another path if needed instead of root (e.g. "/daf")
app.MapDaf("/");

app.Run();
