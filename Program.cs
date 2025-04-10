// Verifica se há argumentos de linha de comando para executar a função "createFolder"
if (args.Length > 0 && args[0].Equals("createFolder", StringComparison.OrdinalIgnoreCase)) {
    if (args.Length > 1) {
        CreateArquives.createFolder(args[1]);
        return; // Encerra a aplicação após a execução da função.
    }
    else {
        Console.WriteLine("Informe o nome da pasta.");
        return;
    }
}
else if (args.Length > 0 && args[0].Equals("create", StringComparison.OrdinalIgnoreCase)) {
    if (args.Length > 1) {
        CreateArquives.create(args[1]);
        return;
    }
    else {
        Console.WriteLine("Informe o nome da pasta.");
        return;
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


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
