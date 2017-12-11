using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace VillagePortal
{
    public partial class Startup
    {
        private static string audience = ConfigurationManager.AppSettings["ida:Audience"];
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private static string tenantId = ConfigurationManager.AppSettings["ida:TenantId"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];
        private static string authority = aadInstance + tenantId;
        public void ConfigureAuth(IAppBuilder app)
        {

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                    new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                    {
                        TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidAudience = audience,
                        },
                        Tenant = tenantId,
                });
        }
    }
}