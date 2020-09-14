using System.Web;
using WebSampleTool.DataAccess.Connection;

namespace WebSampleTool.Models
{
    public class Global
    {
        public static DangNhapModel TaiKhoan_Login
        {
            get
            {
                if (!HttpContext.Current.Request.IsAuthenticated)
                    return null;

                var json = HttpContext.Current.User.Identity.Name;
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<DangNhapModel>(json);
                return obj;
            }
        }
    }
}