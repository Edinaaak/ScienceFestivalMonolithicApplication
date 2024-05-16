using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ScienceFestivalMonolithicApplication.Interfaces;
using ScienceFestivalMonolithicApplication.Models;
using ScienceFestivalMonolithicApplication.Persistance;
using ScienceFestivalMonolithicApplication.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<User, AppRole>()
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IShowService, ShowService>();
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddTransient<TokenService>();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});





builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = "http://localhost:5001",
            ValidIssuer = "https://localhost:5001",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OLJh9kNqdwgNuAl0O5ImFVStp1hsEiRp5BumdvKYySjNbK7ADOtEZAYBPntBQrf4"))
        };
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Performer", policy => policy.RequireRole("Performer"));
    options.AddPolicy("Jury", policy => policy.RequireRole("Jury"));
});




var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();



    if (!await roleManager.RoleExistsAsync("Performer"))
    {
        var adminRole = new AppRole("Performer");
        await roleManager.CreateAsync(adminRole);
    }

    if (!await roleManager.RoleExistsAsync("Jury"))
    {
        var userRole = new AppRole("Jury");
        await roleManager.CreateAsync(userRole);
    }

}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
