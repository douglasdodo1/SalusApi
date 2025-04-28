using Microsoft.EntityFrameworkCore;

if (args.Length > 0 && args[0].Equals("createFolder", StringComparison.OrdinalIgnoreCase)) {
    if (args.Length > 1) {
        ConfigArquives.createFolder(args[1]);
        return;
    }
    else {
        Console.WriteLine("Informe o nome da pasta.");
        return;
    }
}
else if (args.Length > 0 && args[0].Equals("create", StringComparison.OrdinalIgnoreCase)) {
    if (args.Length > 1) {
        ConfigArquives.create(args[1]);
        return;
    }
    else {
        Console.WriteLine("Informe o nome da pasta.");
        return;
    }
}


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Db>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddCustomAuthentication(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var db = scope.ServiceProvider.GetRequiredService<Db>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
