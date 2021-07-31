using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PRNAssigment.Areas.Identity.Data;

[assembly: HostingStartup(typeof(PRNAssigment.Areas.Identity.IdentityHostingStartup))]
namespace PRNAssigment.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DBImportManagementContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DBImportManagementContextConnection")));

                
                services.AddIdentity<AccountManager, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<DBImportManagementContext>()
                        .AddDefaultTokenProviders()
                        .AddDefaultUI();
            });
        }
    }
}