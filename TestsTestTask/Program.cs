using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Filters;
using Services.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Repository.Default.Interfaces;
using Repositories.Repositories;
using Repositories.Repositories.Interfaces;
using Services.Services;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

#region Injection

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IDefaultUsersRepository<Test>, TestRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IUserTestResultRepository, UserTestResultRepository>();

builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddScoped<IAuthorizeService<Test>, AuthorizeService<Test>>();

#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAngularApp",
          policy =>
          {
              policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
          });
});

builder.Services.AddControllersWithViews(options =>
    options.Filters.Add(typeof(NotImplementedExeptionFilterAtribute)));

builder.Services.AddAutoMapper(typeof(AppMappingProfile).Assembly);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
   options.UseSqlServer(connection, b =>
   b.MigrationsAssembly("Repositories")),
   ServiceLifetime.Transient);

#region Identity

builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<ApplicationContext>()
.AddUserStore<UserStore<User,
    IdentityRole,
    ApplicationContext,
    string, IdentityUserClaim<string>,
    IdentityUserRole<string>,
    IdentityUserLogin<string>,
    IdentityUserToken<string>,
    IdentityRoleClaim<string>>>()
.AddRoleStore<RoleStore<IdentityRole,
   ApplicationContext,
   string, IdentityUserRole<string>,
   IdentityRoleClaim<string>>>()
.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 1;

    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
    options.User.RequireUniqueEmail = false;

    options.Lockout.AllowedForNewUsers = true;

    options.SignIn.RequireConfirmedAccount = false;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

#endregion

var app = builder.Build();

app.UseCors("AllowAngularApp");

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
