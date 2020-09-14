using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WebSampleTool.DataAccess.Entity
{
    public class TBL_TAIKHOAN : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region InnerClass

        public enum TBL_TAIKHOAN_Fields
        {
            TaiKhoan_ID,
            TaiKhoan_PhongBan_ID,
            TaiKhoan_NhomQuyen_ID,
            TaiKhoan_ViTri_ID,
            TaiKhoan_DangNhap,
            TaiKhoan_MatKhau,
            TaiKhoan_HoTen,
            TaiKhoan_Email,
            TaiKhoan_SoDienThoai,
            TaiKhoan_AnhDaiDien,
            TaiKhoan_NgayTao,
            TaiKhoan_NguoiTao,
            TaiKhoan_NgayCapNhat,
            TaiKhoan_NguoiCapNhat,
            TaiKhoan_TrangThai,
            TaiKhoan_NgaySinh,
            Email_TenHienThi,
            Email_MatKhau,
            Email_MayChu,
            Email_Cong,
            Email_ChuKy,
            ViTri_Ten,
            NhomQuyen_Ten,
            TaiKhoan_SoMayLe,
            PhongBan_ID,
            PhongBan_Ten,
            PhongBan_ViTri_ID,
            PhongBan_ViTri_Ten,
        }

        #endregion InnerClass

        #region Data Members

        private int _TaiKhoan_ID;
        private int _TaiKhoan_PhongBan_ID;
        private int _TaiKhoan_NhomQuyen_ID;
        private string _TaiKhoan_ViTri_ID;
        private string _TaiKhoan_DangNhap;
        private string _TaiKhoan_MatKhau;
        private string _TaiKhoan_HoTen;
        private string _TaiKhoan_Email;
        private string _TaiKhoan_SoDienThoai;
        private string _TaiKhoan_AnhDaiDien;
        private DateTime _TaiKhoan_NgayTao;
        private int _TaiKhoan_NguoiTao;
        private DateTime _TaiKhoan_NgayCapNhat;
        private int _TaiKhoan_NguoiCapNhat;
        private short _TaiKhoan_TrangThai;
        private string _TaiKhoan_SoMayLe;

        private DateTime? _TaiKhoan_NgaySinh;
        private string _Email_TenHienThi;
        private string _Email_MatKhau;
        private string _Email_MayChu;
        private int? _Email_Cong;
        private string _Email_ChuKy;
        private string _ViTri_Ten;
        private string _NhomQuyen_Ten;
        #endregion Data Members

        #region Properties

        public int TaiKhoan_ID
        {
            get { return _TaiKhoan_ID; }
            set
            {
                if (_TaiKhoan_ID != value)
                {
                    _TaiKhoan_ID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int TaiKhoan_PhongBan_ID
        {
            get { return _TaiKhoan_PhongBan_ID; }
            set
            {
                if (_TaiKhoan_PhongBan_ID != value)
                {
                    _TaiKhoan_PhongBan_ID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int TaiKhoan_NhomQuyen_ID
        {
            get { return _TaiKhoan_NhomQuyen_ID; }
            set
            {
                if (_TaiKhoan_NhomQuyen_ID != value)
                {
                    _TaiKhoan_NhomQuyen_ID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TaiKhoan_ViTri_ID
        {
            get { return _TaiKhoan_ViTri_ID; }
            set
            {
                if (_TaiKhoan_ViTri_ID != value)
                {
                    _TaiKhoan_ViTri_ID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TaiKhoan_DangNhap
        {
            get { return _TaiKhoan_DangNhap; }
            set
            {
                if (_TaiKhoan_DangNhap != value)
                {
                    _TaiKhoan_DangNhap = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TaiKhoan_MatKhau
        {
            get { return _TaiKhoan_MatKhau; }
            set
            {
                if (_TaiKhoan_MatKhau != value)
                {
                    _TaiKhoan_MatKhau = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TaiKhoan_HoTen
        {
            get { return _TaiKhoan_HoTen; }
            set
            {
                if (_TaiKhoan_HoTen != value)
                {
                    _TaiKhoan_HoTen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TaiKhoan_Email
        {
            get { return _TaiKhoan_Email; }
            set
            {
                if (_TaiKhoan_Email != value)
                {
                    _TaiKhoan_Email = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TaiKhoan_SoDienThoai
        {
            get { return _TaiKhoan_SoDienThoai; }
            set
            {
                if (_TaiKhoan_SoDienThoai != value)
                {
                    _TaiKhoan_SoDienThoai = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TaiKhoan_AnhDaiDien
        {
            get { return _TaiKhoan_AnhDaiDien; }
            set
            {
                if (_TaiKhoan_AnhDaiDien != value)
                {
                    _TaiKhoan_AnhDaiDien = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime TaiKhoan_NgayTao
        {
            get { return _TaiKhoan_NgayTao; }
            set
            {
                if (_TaiKhoan_NgayTao != value)
                {
                    _TaiKhoan_NgayTao = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int TaiKhoan_NguoiTao
        {
            get { return _TaiKhoan_NguoiTao; }
            set
            {
                if (_TaiKhoan_NguoiTao != value)
                {
                    _TaiKhoan_NguoiTao = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime TaiKhoan_NgayCapNhat
        {
            get { return _TaiKhoan_NgayCapNhat; }
            set
            {
                if (_TaiKhoan_NgayCapNhat != value)
                {
                    _TaiKhoan_NgayCapNhat = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int TaiKhoan_NguoiCapNhat
        {
            get { return _TaiKhoan_NguoiCapNhat; }
            set
            {
                if (_TaiKhoan_NguoiCapNhat != value)
                {
                    _TaiKhoan_NguoiCapNhat = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public short TaiKhoan_TrangThai
        {
            get { return _TaiKhoan_TrangThai; }
            set
            {
                if (_TaiKhoan_TrangThai != value)
                {
                    _TaiKhoan_TrangThai = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime? TaiKhoan_NgaySinh
        {
            get { return _TaiKhoan_NgaySinh; }
            set
            {
                if (_TaiKhoan_NgaySinh != value)
                {
                    _TaiKhoan_NgaySinh = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Email_TenHienThi
        {
            get { return _Email_TenHienThi; }
            set
            {
                if (_Email_TenHienThi != value)
                {
                    _Email_TenHienThi = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Email_MatKhau
        {
            get { return _Email_MatKhau; }
            set
            {
                if (_Email_MatKhau != value)
                {
                    _Email_MatKhau = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Email_MayChu
        {
            get { return _Email_MayChu; }
            set
            {
                if (_Email_MayChu != value)
                {
                    _Email_MayChu = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int? Email_Cong
        {
            get { return _Email_Cong; }
            set
            {
                if (_Email_Cong != value)
                {
                    _Email_Cong = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Email_ChuKy
        {
            get { return _Email_ChuKy; }
            set
            {
                if (_Email_ChuKy != value)
                {
                    _Email_ChuKy = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ViTri_Ten
        {
            get { return _ViTri_Ten; }
            set
            {
                if (_ViTri_Ten != value)
                {
                    _ViTri_Ten = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string NhomQuyen_Ten
        {
            get { return _NhomQuyen_Ten; }
            set
            {
                if (_NhomQuyen_Ten != value)
                {
                    _NhomQuyen_Ten = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TaiKhoan_SoMayLe
        {
            get { return _TaiKhoan_SoMayLe; }
            set
            {
                if (_TaiKhoan_SoMayLe != value)
                {
                    _TaiKhoan_SoMayLe = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int PhongBan_ID { get; set; }
        public string PhongBan_Ten { get; set; }
        public int PhongBan_ViTri_ID { get; set; }
        public string PhongBan_ViTri_Ten { get; set; }

        #endregion Properties
    }
}