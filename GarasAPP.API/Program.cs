using GarasAPP.Core;
using GarasAPP.Core.Helpers;
using GarasAPP.Core.Interfaces;
using GarasAPP.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GarasAPP.Core.Interfaces.Authentication;
using GarasAPP.EntityFrameworkCore.Repositories.Authentication;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.EntityFrameworkCore.Repositories.Hotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsApi",
        builder => builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomViewRepository, RoomViewRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRateRepository, RateRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IGovernorateRepository, GovernorateRepository>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IlanguageeRepository, languageeRepository>();
builder.Services.AddScoped<INationalityRepository, NationalityRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);
//builder.Services.AddAndMigrateTenantDatabases(builder.Configuration);

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});



builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors("CorsApi");

//app.UseCors(options =>
//            options.WithOrigins("*").
//            AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelsExpandDepth(-1);
    });
}


app.UseHttpsRedirection();
// Must be exist if use exist user to authentication 
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
