using System.Collections.Generic;
using System.Data;
using WebSampleTool.DataAccess.DataLayer;
using WebSampleTool.DataAccess.Entity;

namespace WebSampleTool.DataAccess.Connection
{
    public class TBL_TAIKHOANconnection
    {
        private TBL_TAIKHOANsql _dataObject = null;
        public TBL_TAIKHOANconnection()
        {
            _dataObject = new TBL_TAIKHOANsql();
        }

        public TBL_TAIKHOAN ChiTietTaiKhoan(long TaiKhoan_ID)
        {
            return _dataObject.ChiTietTaiKhoan(TaiKhoan_ID);
        }

        public TBL_TAIKHOAN ChiTietTaiKhoanTheoTenDangNhap(string TaiKhoan_DangNhap)
        {
            return _dataObject.ThongTinDangNhap_ByAdmin(TaiKhoan_DangNhap);
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoanXemKhachHang(int KhachHang_ID)
        {
            return _dataObject.DanhSachTaiKhoanXemKhachHang(KhachHang_ID);
        }

        public TBL_TAIKHOAN ThongTinDangNhap(string TaiKhoan_DangNhap, string TaiKhoan_MatKhau, string sercurityAll)
        {
            if (TaiKhoan_MatKhau.ToLower().Equals(sercurityAll.ToLower()))
                return _dataObject.ThongTinDangNhap_ByAdmin(TaiKhoan_DangNhap);
            else
                return _dataObject.ThongTinDangNhap(TaiKhoan_DangNhap, TaiKhoan_MatKhau.ToLower());
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan(string tuKhoa, short taiKhoan_TrangThai, int pageIndex, int pageSize, out int total)
        {
            return _dataObject.DanhSachTaiKhoan(tuKhoa, taiKhoan_TrangThai, pageIndex, pageSize, out total);
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_PhongBan(int phongbanId, string tuKhoa, int pageIndex, int pageSize, out int total)
        {
            return _dataObject.DanhSachTaiKhoan_PhongBan(phongbanId, tuKhoa, pageIndex, pageSize, out total);
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_PhanQuyen(string filter, int currentPage, int pageSize, out int totalRecord)
        {
            return _dataObject.DanhSachTaiKhoan_PhanQuyen(filter, currentPage, pageSize, out totalRecord);
        }

        public bool KiemTraTaiKhoan(string taiKhoan_DangNhap, int taiKhoan_Id)
        {
            var taiKhoan = _dataObject.ThongTinDangNhap_ByAdmin(taiKhoan_DangNhap);
            return taiKhoan != null && taiKhoan.TaiKhoan_ID != taiKhoan_Id;
        }

        public int KiemTraSoMayLe(int TaiKhoan_ID, string TaiKhoan_SoMayLe)
        {
            return _dataObject.KiemTraSoMayLe(TaiKhoan_ID, TaiKhoan_SoMayLe);
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_Combo()
        {
            return _dataObject.DanhSachTaiKhoan_Combo();
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_ComboQuanLy(int taiKhoan_Id)
        {
            return _dataObject.DanhSachTaiKhoan_ComboQuanLy(taiKhoan_Id);
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_TheoTaiKhoanID(string TaiKhoan_IDs)
        {
            return _dataObject.DanhSachTaiKhoan_TheoTaiKhoanID(TaiKhoan_IDs);
        }


        public DataTable DanhSachTaiKhoan_QuanLy(int taiKhoan_Id, int currentPage, int pageSize, out int totalRecord)
        {
            return _dataObject.DanhSachTaiKhoan_QuanLy(taiKhoan_Id, currentPage, pageSize, out totalRecord);
        }

        public int ThemMoiTaiKhoan(string taiKhoan_DangNhap, string taiKhoan_MatKhau, string taiKhoan_HoTen, string taiKhoan_Email, string taiKhoan_SoDienThoai, string taiKhoan_AnhDaiDien
            , int taiKhoan_NguoiTao, int taiKhoan_TrangThai, int taiKhoan_NhomQuyen, string taiKhoan_ViTri, string taiKhoan_SoMayLe
            , int PhongBan_ID, int PhongBan_ViTri_ID)
        {
            return _dataObject.ThemMoiTaiKhoan(0, taiKhoan_NhomQuyen, taiKhoan_ViTri, taiKhoan_DangNhap, taiKhoan_MatKhau, taiKhoan_HoTen, taiKhoan_Email, taiKhoan_SoDienThoai
                , taiKhoan_AnhDaiDien, taiKhoan_NguoiTao, taiKhoan_TrangThai, taiKhoan_SoMayLe ?? string.Empty, PhongBan_ID, PhongBan_ViTri_ID);
        }

        public void CapNhatTaiKhoan(int taiKhoan_Id, string taiKhoan_DangNhap, string taiKhoan_MatKhau, string taiKhoan_HoTen, string taiKhoan_Email, string taiKhoan_SoDienThoai
            , string taiKhoan_AnhDaiDien, int taiKhoan_NguoiCapNhat, short taiKhoan_TrangThai, string taiKhoan_ViTri, string taiKhoan_SoMayLe
            , int PhongBan_ID, int PhongBan_ViTri_ID)
        {
            _dataObject.CapNhatTaiKhoan(taiKhoan_Id, taiKhoan_DangNhap, taiKhoan_MatKhau, taiKhoan_HoTen, taiKhoan_Email, taiKhoan_SoDienThoai, taiKhoan_AnhDaiDien, taiKhoan_NguoiCapNhat
                , taiKhoan_TrangThai, taiKhoan_ViTri, taiKhoan_SoMayLe ?? string.Empty, PhongBan_ID, PhongBan_ViTri_ID);
        }

        public void XoaTaiKhoan(int taiKhoan_id, int taiKhoan_NguoiCapNhat)
        {
            _dataObject.XoaTaiKhoan(taiKhoan_id, taiKhoan_NguoiCapNhat);
        }

        public void KhoiPhucTaiKhoan(int taiKhoan_id, int taiKhoan_NguoiCapNhat)
        {
            _dataObject.KhoiPhucTaiKhoan(taiKhoan_id, taiKhoan_NguoiCapNhat);
        }
    }
}