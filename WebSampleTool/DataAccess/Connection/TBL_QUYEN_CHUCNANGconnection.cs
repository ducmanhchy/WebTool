using System.Collections.Generic;
using System.Linq;
using WebSampleTool.DataAccess.DataLayer;
using WebSampleTool.DataAccess.Entity;

namespace WebSampleTool.DataAccess.Connection
{
    public class TBL_QUYEN_CHUCNANGconnection
    {
        private TBL_QUYEN_CHUCNANGsql _dataObject = null;
        public TBL_QUYEN_CHUCNANGconnection()
        {
            _dataObject = new TBL_QUYEN_CHUCNANGsql();
        }

        public bool CapNhatQuyen_ChucNang(int Quyen_ID, string ChucNang_IDs)
        {
            return _dataObject.CapNhatQuyen_ChucNang(Quyen_ID, ChucNang_IDs);
        }

        public List<TBL_QUYEN_CHUCNANG> DanhSachQuyen_ChucNang(int quyenId)
        {
            if (quyenId > 0)
                return _dataObject.DanhSachQuyen_ChucNang().Where(x => x.Quyen_ID == quyenId).ToList();
            else
                return _dataObject.DanhSachQuyen_ChucNang();
        }

        public List<TBL_QUYEN_CHUCNANG> DanhSachQuyen_ChucNang_QuyenID(int Quyen_ID)
        {
            return _dataObject.DanhSachQuyen_ChucNang_QuyenID(Quyen_ID);
        }

        public int KiemTraQuyen_TaiKhoanDangNhap(int TaiKhoan_NhomQuyen_ID, string ControllerName, string ActionName, int TaiKhoan_ID)
        {
            return _dataObject.KiemTraQuyen_TaiKhoanDangNhap(TaiKhoan_NhomQuyen_ID, ControllerName, ActionName, TaiKhoan_ID);
        }
    }
}