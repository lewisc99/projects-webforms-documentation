using Owin;
using Microsoft.Owin;
using account.Data;
using account.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using account.configuration;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Threading.Tasks;


[assembly: OwinStartup(typeof(account.Startup))]
namespace account
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login"), // Change "/Default" to your desired default page URL
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager,ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager,user) => user.GenerateUserIdentityAsync(manager,DefaultAuthenticationTypes.ApplicationCookie))
                }
            });

            // Configure JWT Bearer Authentication
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            // Configure OAuth Authorization Server
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true // In production, set this to false
            });
        }

    private void CreateRolesAndUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                // Create Admin role if it doesn't exist
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole { Name = "Admin" };
                    roleManager.Create(role);

                    // Create default Admin user
                    var user = new ApplicationUser { UserName = "admin",Email = "admin@example.com" };
                    string userPassword = "Admin@123";
                    var result = userManager.Create(user,userPassword);
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id,"Admin");
                    }
                }

                if (!roleManager.RoleExists("User"))
                {
                    var role = new IdentityRole { Name = "User" };
                    roleManager.Create(role);

                    // Create default user
                    var user = new ApplicationUser { UserName = "user",Email = "user@example.com" };
                    string userPassword = "User@123";
                    var result = userManager.Create(user,userPassword);
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id,"User");
                    }
                }
            }
        }
    }

    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName,context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant","The user name or password is incorrect.");
                return;
            }

            var oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,OAuthDefaults.AuthenticationType);
            var cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,CookieAuthenticationDefaults.AuthenticationType);

            var properties = CreateProperties(user.UserName);
            var ticket = new AuthenticationTicket(oAuthIdentity,properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            return new AuthenticationProperties(new Dictionary<string,string>
        {
            { "userName", userName }
        });
        }
    }

}