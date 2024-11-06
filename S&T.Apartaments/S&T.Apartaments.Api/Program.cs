using Microsoft.AspNetCore.Http.Extensions;
using S_T.Apartaments.Helpers.DiContainer;
using S_T.Apartaments.Helpers.Extensions;
using S_T.Apartaments.Mappers.MapperConfig;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Configuration.GetSection("AppSettings");

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly)
                .AddSqlDbContext(appSettings)
                .AddAuthentication()
                .AddJwt(appSettings)
                .AddIdentity()
.AddCors()
.AddSwagger();

DiHelper.InjectRepositories(builder.Services);
DiHelper.InjectService(builder.Services);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();