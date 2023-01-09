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
            builder.Services.AddSingleton<ICRUD, ProductRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

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