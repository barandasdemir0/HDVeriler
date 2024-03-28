using HD_Veriler.Models;
using HD_Veriler.Repositories.Abstractions;
using HD_Veriler.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using HD_Veriler.Extension;
using AutoMapper;
using FluentValidation.AspNetCore;
using HD_Veriler.Validators;
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDataLayerExtension(builder.Configuration);



// Add services to the container.
builder.Services.AddControllersWithViews();

//session ayar� saat 1 saat olarak ayarland�
builder.Services.AddSession(option =>
{
	option.IdleTimeout = TimeSpan.FromHours(1);
});

//layoutta session login g�r�n�m� i�in
builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
	options.Cookie.Name = "NetCoreMvc.Auth";
	options.LoginPath = "/Home/Index";
	options.AccessDeniedPath = "/Home/Index";
});









// T�rk�e karakter sorununu d�zeltmek i�in TextEncoderSettings'� yap�land�r�n
builder.Services.Configure<WebEncoderOptions>(options =>
{
	options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
});

//automapper yap�land�rma
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllersWithViews().AddFluentValidation();









var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePagesWithReExecute("/Home/Error404", "?code={0}");

app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
