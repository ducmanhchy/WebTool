using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebSampleTool2.Models;

namespace WebSampleTool2
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // 
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Cho phép ứng dụng sử dụng cookie để lưu trữ thông tin cho người dùng đã đăng nhập
            // Và sử dụng cookie để lưu trữ tạm thời thông tin về người dùng đăng nhập bằng nhà cung cấp dịch vụ đăng nhập bên thứ ba
            // Cấu hình cookie đăng nhập
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Cho phép ứng dụng xác thực mẫu bảo mật khi người dùng đăng nhập.
                    // Đây là một tính năng bảo mật được sử dụng khi bạn thay đổi mật khẩu hoặc thêm thông tin đăng nhập bên ngoài vào tài khoản của mình.
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(1),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Cho phép ứng dụng lưu trữ tạm thời thông tin người dùng khi họ đang xác minh yếu tố thứ hai trong quy trình xác thực hai yếu tố.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(1));

            // Cho phép ứng dụng ghi nhớ yếu tố xác minh đăng nhập thứ hai như điện thoại hoặc email.
            // Sau khi bạn chọn tùy chọn này, bước xác minh thứ hai của bạn trong quá trình đăng nhập sẽ được ghi nhớ trên thiết bị mà bạn đã đăng nhập.
            // Điều này tương tự với tùy chọn RememberMe khi bạn đăng nhập.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Bỏ ghi chú các dòng sau để cho phép đăng nhập bằng nhà cung cấp dịch vụ đăng nhập bên thứ ba
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}