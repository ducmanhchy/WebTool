using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebSampleTool.DataAccess.Connection;
using WebSampleTool.Utilily;

namespace WebSampleTool.Models
{
    public class DangNhapModel : IValidatableObject
    {
        public int TaiKhoan_ID { get; set; }
        public string TaiKhoan_DangNhap { get; set; }
        public string TaiKhoan_MatKhau { get; set; }
        public string TaiKhoan_HoTen { get; set; }
        public string TaiKhoan_Email { get; set; }
        public string TaiKhoan_SoDienThoai { get; set; }
        public string TaiKhoan_AnhDaiDien { get; set; }
        public int TaiKhoan_NhomQuyen_ID { get; set; }
        public int TaiKhoan_PhongBan_ID { get; set; }
        public string TaiKhoan_ViTri_ID { get; set; }
        public short TaiKhoan_TrangThai { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(TaiKhoan_DangNhap))
                yield return new ValidationResult("Vui lòng nhập tên đăng nhập", new[] { nameof(TaiKhoan_DangNhap) });
            if (string.IsNullOrEmpty(TaiKhoan_MatKhau))
                yield return new ValidationResult("Vui lòng nhập mật khẩu", new[] { nameof(TaiKhoan_MatKhau) });
            if (!string.IsNullOrEmpty(TaiKhoan_DangNhap) && !string.IsNullOrEmpty(TaiKhoan_MatKhau))
            {
                TBL_TAIKHOANconnection connection = new TBL_TAIKHOANconnection();
                var matKhau = ThuVien.MaHoa_MD5(TaiKhoan_MatKhau.Trim()).ToLower();
                string sercurityAll = System.Configuration.ConfigurationManager.AppSettings["SercurityAll"].ToLower();
                var TaiKhoan = connection.ThongTinDangNhap(TaiKhoan_DangNhap.Trim(), matKhau, sercurityAll);
                if (TaiKhoan == null)
                    yield return new ValidationResult("Tài khoản hoặc mật khẩu đăng nhập không chính xác.", new[] { nameof(TaiKhoan_DangNhap) });
            }
        }
    }
}