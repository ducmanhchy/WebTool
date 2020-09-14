using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebSampleTool.DataAccess.Connection;
using WebSampleTool.Models;

namespace WebSampleTool.Controllers
{
    public class BaseController : Controller
    {
        private TBL_QUYEN_CHUCNANGconnection TBL_QUYEN_CHUCNANGconnection = null;
        private TBL_TAIKHOAN_CHUCNANGconnection _TBL_TAIKHOAN_CHUCNANGconnection = null;

        public BaseController()
        {
            if (TBL_QUYEN_CHUCNANGconnection == null)
                TBL_QUYEN_CHUCNANGconnection = new TBL_QUYEN_CHUCNANGconnection();
            if (_TBL_TAIKHOAN_CHUCNANGconnection == null)
                _TBL_TAIKHOAN_CHUCNANGconnection = new TBL_TAIKHOAN_CHUCNANGconnection();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"].ToString().Trim().ToUpper();
            var action = filterContext.RouteData.Values["action"].ToString().Trim().ToUpper();

            var currentAcc = Global.TaiKhoan_Login;
            if (currentAcc != null && Global.TaiKhoan_Login.TaiKhoan_NhomQuyen_ID != 1)
            {
                if (!controller.ToUpper().Equals("THONGBAO"))
                {

                    var check = TBL_QUYEN_CHUCNANGconnection.KiemTraQuyen_TaiKhoanDangNhap(Global.TaiKhoan_Login.TaiKhoan_NhomQuyen_ID, controller.ToUpper(), action.ToUpper(), Global.TaiKhoan_Login.TaiKhoan_ID);
                    if (check == 0)
                    {
                        // filterContext.Result = new RedirectResult("/403");
                        filterContext.HttpContext.Response.StatusCode = 403;
                        //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        //{
                        //    controller = "PageError",
                        //    action = "Page403"
                        //}));
                        return;
                    }
                }
            }
        }

        protected override void Initialize(RequestContext requestContext)
        {
            try
            {
                try
                {
                    // Add thêm thời gian khi vẫn còn hoạt động, Tránh timeout;
                    var checkCookie = false;
                    foreach (var cookey in requestContext.HttpContext.Request.Cookies.AllKeys)
                    {
                        if (cookey == FormsAuthentication.FormsCookieName || cookey.ToLower() == "asp.net_sessionid")
                        {
                            var reqCookie = requestContext.HttpContext.Request.Cookies[cookey];
                            if (reqCookie != null)
                            {
                                HttpCookie respCookie = new HttpCookie(reqCookie.Name, reqCookie.Value);
                                respCookie.Expires = DateTime.Now.AddMinutes(360);
                                requestContext.HttpContext.Response.Cookies.Set(respCookie);
                                checkCookie = true;
                            }
                            break;
                        }
                    }
                    if (!checkCookie)
                    {
                        HttpCookie respCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                        respCookie.Expires = DateTime.Now.AddMinutes(360);
                        requestContext.HttpContext.Response.Cookies.Set(respCookie);
                        checkCookie = true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                if (!requestContext.HttpContext.Request.IsAuthenticated)
                    requestContext.HttpContext.Response.Redirect(GetLoginUrl(requestContext));

                var controller = requestContext.RouteData.Values["controller"].ToString().Trim().ToUpper();

                var currentAcc = Global.TaiKhoan_Login;
                if (currentAcc != null)
                    ViewBag.LIST_CHUCNANG_QUYEN_TAIKHOAN = _TBL_TAIKHOAN_CHUCNANGconnection.DanhSachTaiKhoan_Quyen_ChucNang(Global.TaiKhoan_Login.TaiKhoan_ID, Global.TaiKhoan_Login.TaiKhoan_NhomQuyen_ID);
                else if (controller == "DANGNHAP")
                    requestContext.HttpContext.Response.Redirect(GetLoginUrl(requestContext));

                base.Initialize(requestContext);
            }
            catch (Exception)
            {
                requestContext.HttpContext.Response.Redirect("/dang-nhap");
            }
        }

        private string GetLoginUrl(RequestContext requestContext)
        {
            var redirectUrl = requestContext.HttpContext.Server.UrlEncode(requestContext.HttpContext.Request.Url.PathAndQuery);
            return string.Format("/dang-nhap?backurl={0}", redirectUrl);
        }
    }
}