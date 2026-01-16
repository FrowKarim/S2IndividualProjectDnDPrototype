var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<LogicLayer.Interfaces.ICharacterRepo, DAL.Repos.CharacterRepo>();
builder.Services.AddScoped<LogicLayer.Interfaces.IPersonRepo, DAL.Repos.PersonRepo>();
builder.Services.AddScoped<LogicLayer.Interfaces.ICampaignRepo, DAL.Repos.CampaignRepo>();
builder.Services.AddScoped<LogicLayer.Interfaces.IUserRepo, DAL.Repos.UserRepo>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
