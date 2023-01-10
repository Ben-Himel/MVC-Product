using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Module4.Models;
using Module4.Services;


namespace Module4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddSingleton<ICRUD, ProductRepository>();
            builder.Services.AddScoped<ICRUD, CRUD>();
            builder.Services.AddScoped<IFileUpload, FileUpload>();
            
            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer("Server=localhost;Database=CCAD9Prod;Trusted_Connection=true;TrustServerCertificate=True; MultipleActiveResultSets=True"));
            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer());
            builder.Services.AddIdentity<User, IdentityRole>(Options =>
            {
                Options.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<UserContext>();

            builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer("Server=localhost;Database=CCAD9ProdUsers;TrustServerCertificate=True; Trusted_Connection=true;MultipleActiveResultSets=True"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            else
            {

            }

            using (var scope = app.Services.CreateScope())
            {
                var dbcontext = scope.ServiceProvider.GetRequiredService<ProductContext>();
                dbcontext.Database.EnsureCreated();  //create the db
                var userdbcontext = scope.ServiceProvider.GetRequiredService<UserContext>();
                userdbcontext.Database.EnsureCreated();
            }


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
               

            //route 1 ... convention based (more Specific)            
            app.MapControllerRoute(
                name: "first",
                pattern: "{action}/{parm?}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { parm = "[0-9]+" }
            );


            // route 2 generalized
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Other}/{action=Index}/{id?}");

            app.Run();
        }
    }
}