using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using website_backend;
using website_backend.DbContexts;
using website_backend.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddDbContext<WebsiteContext>(
    dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:WebsiteDBConnectionString"]));

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif

builder.Services.AddSingleton<PostsDataStore>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
