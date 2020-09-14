using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WebSampleTool.DataAccess.Entity
{
    public class TBL_QUYEN_CHUCNANG : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public enum TBL_QUYEN_CHUCNANG_Fields
        {
            Quyen_ID,
            ChucNang_ID,
            ChucNang_Ma
        }

        private int _Quyen_ID;
        private int _ChucNang_ID;
        private string _ChucNang_Ma;

        public int Quyen_ID
        {
            get { return _Quyen_ID; }
            set
            {
                if (_Quyen_ID != value)
                {
                    _Quyen_ID = value;
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