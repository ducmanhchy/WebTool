using System;
using System.Collections;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using WebSampleTool2.App_Start.IdentityPolicy;
using WebSampleTool2.Models;

namespace WebSampleTool2
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            string Mail_From = ConfigurationManager.AppSettings["mailAccount"];
            string Mail_FromPass = ConfigurationManager.AppSettings["mailPassword"];
            string Mail_To = message.Destination;
            string Mail_Subject = message.Subject;
            string Body = message.Body;
            return SendMail(Mail_From, Mail_FromPass, Mail_To, Mail_Subject, Body);
        }

        async Task SendMail(string Mail_From, string Mail_FromPass, string Mail_To, string Mail_Subject, string messageBody, string pathFileAttach = null, string server = "smtp.gmail.com", int port = 587, bool enableSsl = true)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(Mail_From);
            msg.To.Add(new MailAddress(Mail_To));
            msg.Subject = Mail_Subject;
            //msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(messageBody, null, MediaTypeNames.Text.Html));

            Attachment data = null;
            if (!string.IsNullOrEmpty(pathFileAttach))
            {
                data = new Attachment(pathFileAttach, MediaTypeNames.Application.Octet);
                // Thêm thông tin thời gian cho tệp.
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(pathFileAttach);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(pathFileAttach);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(pathFileAttach);
                // Thêm tệp đính kèm vào email này.
                msg.Attachments.Add(data);
            }

            SmtpClient smtpClient = new SmtpClient(server, Convert.ToInt32(port));
            NetworkCredential credentials = new NetworkCredential(Mail_From, Mail_FromPass);
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = enableSsl;
            try
            {
                await smtpClient.SendMailAsync(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra trong hàm sendMail(): {0}", ex.ToString());
            }

            // log fileAttach
            if (!string.IsNullOrEmpty(pathFileAttach))
            {
                // Hiển thị các giá trị trong ContentDisposition cho tệp đính kèm.
                ContentDisposition cd = data.ContentDisposition;
                Console.WriteLine("Content disposition");
                Console.WriteLine(cd.ToString());
                Console.WriteLine("File {0}", cd.FileName);
                Console.WriteLine("Size {0}", cd.Size);
                Console.WriteLine("Creation {0}", cd.CreationDate);
                Console.WriteLine("Modification {0}", cd.ModificationDate);
                Console.WriteLine("Read {0}", cd.ReadDate);
                Console.WriteLine("Inline {0}", cd.Inline);
                Console.WriteLine("Parameters: {0}", cd.Parameters.Count);
                foreach (DictionaryEntry d in cd.Parameters)
                {
                    Console.WriteLine("{0} = {1}", d.Key, d.Value);
                }
                data.Dispose();
            }
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Cấu hình trình quản lý người dùng ứng dụng được sử dụng trong ứng dụng này. UserManager được định nghĩa trong ASP.NET Identity và được ứng dụng sử dụng.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {

        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Cấu hình logic xác thực cho tên người dùng
            manager.UserValidator = new CustomUserValidator<ApplicationUser>(manager)
            {
                EndEmail = "gmail.com"
            };

            // Cấu hình logic xác thực cho passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Cấu hình mặc định khóa người dùng
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(1);
            manager.MaxFailedAccessAttemptsBeforeLockout = 2;

            // Đăng ký cung cấp xác thực hai yếu tố. Ứng dụng này sử dụng Điện thoại và Email như một bước nhận mã để xác minh người dùng
            // Bạn có thể viết nhà cung cấp của riêng mình và cắm nó vào đây.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Mã code của bạn là {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Mã bảo mật",
                BodyFormat = "Mã bảo mật của bạn là {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Cấu hình trình quản lý đăng nhập ứng dụng được sử dụng trong ứng dụng này.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
