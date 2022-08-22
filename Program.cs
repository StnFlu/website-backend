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
#if DEBUG
builder.Services.AddDbContext<WebsiteContext>(
    dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionString:WebsiteDBConnectionString"]));
#else
builder.Services.AddDbContext<WebsiteContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration["ConnectionString:WebsiteDBConnectionString"]));
#endif

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif

builder.Services.AddSingleton<PostsDataStore>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<IWebsiteRepository, WebsiteInfoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("corsapp");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
