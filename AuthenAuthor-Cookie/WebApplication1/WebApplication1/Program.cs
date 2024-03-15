using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Authen
builder.Services.AddAuthentication()
    .AddCookie(option =>
{
    /**
     * Cookies (Storage) vs Web Storage
     * ============================================================================================================
     *                  LOCAL/SESSION STORAGE                          ||	        COOKIES (STORAGE)
     *  JavaScript	| Accessible through JavaScript on the same domain ||	Cookies, when used with the HttpOnly cookie flag, are not accessible through JavaScript
     *  XSS attacks	| Vulnerable to XSS attacks                        ||	Immune to XSS (with HttpOnly flag)
     *  CSRF attacks| Immune to CSRF attacks                           ||	Vulnerable to CSRF attacks
     *  Mitigation	| Do not store private or sensitive                ||	Make use of CSRF tokens or other prevention methods
     *              |    \or authentication-related data here          ||
     * ============================================================================================================
     */
    option.Cookie.HttpOnly = true; // Set flag for can not able read by JavaScript
    option.Cookie.SameSite = SameSiteMode.Strict; // flags are more secure.

    option.Cookie.Name = "CookieNameHere";
    option.Cookie.Domain = "localhost";

    option.LoginPath = "/api/account/unauthorized";
    option.LogoutPath = "/api/account/signout";
    option.AccessDeniedPath = "/api/account/forbidden";
    //option.EventsType = typeof(CustomCookieAuthenticationEvents);
});

//builder.Services.AddScoped<CustomCookieAuthenticationEvents>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
