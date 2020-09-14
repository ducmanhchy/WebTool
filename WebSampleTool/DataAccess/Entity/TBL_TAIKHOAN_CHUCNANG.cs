using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WebSampleTool.DataAccess.Entity
{
    public class TBL_TAIKHOAN_CHUCNANG
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public enum TBL_TAIKHOAN_CHUCNANG_Fields
        {
            TaiKhoan_ID,
            ChucNang_ID,
            ChucNang_Ma
        }

        private int _TaiKhoan_ID;
        private int _ChucNang_ID;
        private string _ChucNang_Ma;

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

        public int ChucNang_ID
        {
            get { return _ChucNang_ID; }
            set
            {
                if (_ChucNang_ID != value)
                {
                    _ChucNang_ID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ChucNang_Ma
        {
            get { return _ChucNang_Ma; }
            set
            {
                if (_ChucNang_Ma != value)
                {
                    _ChucNang_Ma = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}