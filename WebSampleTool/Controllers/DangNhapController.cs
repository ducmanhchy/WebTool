using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSampleTool.DataAccess.Connection;
using WebSampleTool.DataAccess.Entity;
using WebSampleTool.Models;
using WebSampleTool.Utilily;

namespace WebSampleTool.Controllers
{
    public class DangNhapController : Controller
    {
        private TBL_TAIKHOANconnection _connection = new TBL_TAIKHOANconnection();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoLogin(DangNhapModel m, string RedirectUrl, string subdomain)
        {
            if (ModelState.IsValid)
            {
                var matKhau = ThuVien.MaHoa_MD5(m.TaiKhoan_MatKhau).ToLower();
                string SercurityAll = System.Configuration.ConfigurationManager.AppSettings["SercurityAll"].ToLower();
                TBL_TAIKHOAN TaiKhoan = _connection.ThongTinDangNhap(m.TaiKhoan_DangNhap.Trim(), matKhau, SercurityAll);
                if (TaiKhoan != null)
                {
                    var taikhoan_login = new DangNhapModel
                    {
                        TaiKhoan_ID = TaiKhoan.TaiKhoan_ID,
                        TaiKhoan_PhongBan_ID = TaiKhoan.TaiKhoan_PhongBan_ID,
                        TaiKhoan_NhomQuyen_ID = TaiKhoan.TaiKhoan_NhomQuyen_ID,
                        TaiKhoan_ViTri_ID = TaiKhoan.TaiKhoan_ViTri_ID,
                        TaiKhoan_DangNhap = TaiKhoan.TaiKhoan_DangNhap,
                        TaiKhoan_HoTen = TaiKhoan.TaiKhoan_HoTen,
                        TaiKhoan_Email = TaiKhoan.TaiKhoan_Email,
                        TaiKhoan_SoDienThoai = TaiKhoan.TaiKhoan_SoDienThoai,
                        TaiKhoan_AnhDaiDien = TaiKhoan.TaiKhoan_AnhDaiDien,
                        TaiKhoan_TrangThai = TaiKhoan.TaiKhoan_TrangThai,
                    };

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(taikhoan_login);

                    // create encryption cookie         
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, json, DateTime.Now, DateTime.Now.AddDays(90), true, string.Empty);
                    // add cookie to response stream         
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    if (authTicket.IsPersistent)
                        authCookie.Expires = authTicket.Expiration;
                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                    string backurl = Request.QueryString["backurl"];

                    if (!string.IsNullOrEmpty(RedirectUrl))
                    {
                        RedirectUrl = Uri.UnescapeDataString(RedirectUrl);
                        return Redirect(Server.UrlDecode(RedirectUrl));
                    }
                    else if (string.IsNullOrEmpty(backurl))
                        backurl = "/";
                    return Json(new { Sucess = true, Errors = ModelState.Errors(), Url = backurl }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { Sucess = false, Errors = "Đăng nhập không thành công.", Url = "/dang-nhap" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { Sucess = false, Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DoLogout()
        {
            FormsAuthentication.SignOut();
            //Clear session
            var current = System.Web.HttpContext.Current;
            current.Session.Clear();
            current.Session.Abandon();
            //Clears out Session
            current.Response.Cookies.Clear();
            // clear authentication cookie
            current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            current.Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            HttpCookie cookie = current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                current.Response.Cookies.Add(cookie);
            }
            return Redirect(Server.UrlDecode("/dang-nhap"));
        }
    }
}
