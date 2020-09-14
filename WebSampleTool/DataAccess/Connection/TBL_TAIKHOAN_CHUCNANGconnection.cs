using System.Collections.Generic;
using WebSampleTool.DataAccess.DataLayer;
using WebSampleTool.DataAccess.Entity;

namespace WebSampleTool.DataAccess.Connection
{
    public class TBL_TAIKHOAN_CHUCNANGconnection
    {
        #region data Members

        private TBL_TAIKHOAN_CHUCNANGsql _dataObject = null;

        #endregion data Members

        #region Constructor

        public TBL_TAIKHOAN_CHUCNANGconnection()
        {
            _dataObject = new TBL_TAIKHOAN_CHUCNANGsql();
        }

        #endregion Constructor

        public List<TBL_TAIKHOAN_CHUCNANG> DanhSachTaiKhoanChucNang(int TaiKhoan_ID)
        {
            return _dataObject.DanhSachTaiKhoanChucNang(TaiKhoan_ID);
        }

        public bool ThemMoiTaiKhoanChucNang(int TaiKhoan_ID, string ChucNang_IDs)
        {
            return _dataObject.ThemMoiTaiKhoanChucNang(TaiKhoan_ID, ChucNang_IDs);
        }

        public List<TBL_TAIKHOAN_CHUCNANG> DanhSachTaiKhoan_Quyen_ChucNang(int TaiKhoan_ID, int NhomQuyen_ID)
        {
            return _dataObject.DanhSachTaiKhoan_Quyen_ChucNang(TaiKhoan_ID, NhomQuyen_ID);
        }

        public bool XoaTaiKhoanChucNang(int TaiKhoan_ID)
        {
            return _dataObject.XoaTaiKhoanChucNang(TaiKhoan_ID);
        }
    }
}