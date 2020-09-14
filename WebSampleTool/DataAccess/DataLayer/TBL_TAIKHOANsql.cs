using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebSampleTool.DataAccess.Entity;
using WebSampleTool.Utilily;

namespace WebSampleTool.DataAccess.DataLayer
{
    class TBL_TAIKHOANsql : DataLayerBase
    {
        public TBL_TAIKHOANsql()
        {
        }

        internal List<TBL_TAIKHOAN> PopulateObjectsFromReader(IDataReader dataReader)
        {
            return dataReader.MapToList<TBL_TAIKHOAN>();
        }

        public TBL_TAIKHOAN ChiTietTaiKhoan(long TaiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_CHITIET]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var taikhoan = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return taikhoan.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoanXemKhachHang(int KhachHang_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_KHACHHANG_NGUOIXEM_ID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@KhachHang_ID", KhachHang_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_LichChamSoc(int KhachHang_ID, int TaiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_DANHSACH_LICHCHAMSOC_KHACHHANGID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@KhachHang_ID", KhachHang_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_TheoTaiKhoanID(string TaiKhoan_IDs)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_DANHSACH_IDs]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_IDs", TaiKhoan_IDs).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_KPI(string PhongBanId, int TaiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_DANHSACH_KPI]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@PhongBan_ID", PhongBanId).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_KPI_ThietLap_NhanVien(int KPI_ThietLap_NhanVien_ID, int TaiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_DANHSACH_KPI_THIETLAP_NHANVIEN]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@KPI_ThietLap_NhanVien_ID", KPI_ThietLap_NhanVien_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }


        public List<TBL_TAIKHOAN> DanhSachTaiKhoanDangQuanLy(int TaiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_QUANLY_DANHSACH_TAIKHOANID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoanDangQuanLy(int TaiKhoan_ID, int khachHang_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_QUANLY_TAIKHOANID_KHID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@KhachHang_ID", khachHang_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        internal DataTable LayTatCaQuanLy(int taiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_TATCAQUANLY]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", taiKhoan_ID).Direction = ParameterDirection.Input;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                MainConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        internal DataTable LayTatDanhSachTaiKhoanThongBao(string taiKhoan_IDs, string dsNguoiThamGia, int? nguoiHanhDong)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_LAYDANHSACH_GUITHONGBAO]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_IDs", taiKhoan_IDs).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@NguoiThamGia", dsNguoiThamGia).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@NguoiHanhDong", nguoiHanhDong).Direction = ParameterDirection.Input;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                MainConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        internal DataTable LayTatCaQuanLy_TrongCongViec(int taiKhoan_ID, string dsNguoiThamGia, int? nguoiHanhDong = null)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_LAYDANHSACH_TRONGCONGVIEC]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", taiKhoan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@NguoiThamGia", dsNguoiThamGia).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@NguoiHanhDong", nguoiHanhDong).Direction = ParameterDirection.Input;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                MainConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public int ThemMoiTaiKhoan(int TaiKhoan_PhongBan_ID, int TaiKhoan_NhomQuyen_ID, string TaiKhoan_ViTri_ID, string taiKhoan_DangNhap, string taiKhoan_MatKhau, string taiKhoan_HoTen
            , string taiKhoan_Email, string taiKhoan_SoDienThoai, string taiKhoan_AnhDaiDien, int taiKhoan_NguoiTao, int taiKhoan_TrangThai, string taiKhoan_SoMayLe
            , int PhongBan_ID, int PhongBan_ViTri_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_THEMMOI]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_PhongBan_ID", TaiKhoan_PhongBan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_NhomQuyen_ID", TaiKhoan_NhomQuyen_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ViTri_ID", TaiKhoan_ViTri_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_DangNhap", taiKhoan_DangNhap).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_MatKhau", taiKhoan_MatKhau).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_HoTen", taiKhoan_HoTen).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_Email", taiKhoan_Email).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_SoDienThoai", taiKhoan_SoDienThoai).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_AnhDaiDien", taiKhoan_AnhDaiDien).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_NguoiTao", taiKhoan_NguoiTao).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_TrangThai", taiKhoan_TrangThai).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_SoMayLe", taiKhoan_SoMayLe).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@PhongBan_ID", PhongBan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@PhongBan_ViTri_ID", PhongBan_ViTri_ID).Direction = ParameterDirection.Input;
                SqlParameter out_Id = new SqlParameter("@TaiKhoan_ID", SqlDbType.Int);
                out_Id.Direction = ParameterDirection.InputOutput;
                out_Id.Value = 0;
                sqlCommand.Parameters.Add(out_Id);

                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                MainConnection.Close();
                return int.Parse(out_Id.Value.ToString());
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("TBL_TAIKHOAN::THEMMOI::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        internal void CapNhatPhanQuyen(int taiKhoan_ID, int taiKhoan_NguoiCapNhat, int taiKhoan_NhomQuyen_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_PHANQUYEN]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", taiKhoan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_NguoiCapNhat", taiKhoan_NguoiCapNhat).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_NhomQuyen_ID", taiKhoan_NhomQuyen_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                MainConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::XOA::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public void XoaTaiKhoan(int taiKhoan_id, int taiKhoan_NguoiCapNhat)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_XOA]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", taiKhoan_id).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_NguoiCapNhat", taiKhoan_NguoiCapNhat).Direction = ParameterDirection.Input;
                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                MainConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::XOA::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public void KhoiPhucTaiKhoan(int taiKhoan_id, int taiKhoan_NguoiCapNhat)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_KHOIPHUC]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", taiKhoan_id).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_NguoiCapNhat", taiKhoan_NguoiCapNhat).Direction = ParameterDirection.Input;
                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                MainConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::KHOIPHUC::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_Combo()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_COMBO]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_ComboQuanLy(int taiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_COMBOQUANLY]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", taiKhoan_ID).Direction = ParameterDirection.Input;
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public DataTable DanhSachTaiKhoan_QuanLy(int taiKhoan_ID, int currentPage, int pageSize, out int totalRecord)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_DANHSACH_NGUOIQUANLY]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", taiKhoan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@CurrentPage", currentPage).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@PageSize", pageSize).Direction = ParameterDirection.Input;
                SqlParameter out_total = new SqlParameter("@TotalRecord", SqlDbType.Int);
                out_total.Direction = ParameterDirection.InputOutput;
                out_total.Value = 0;
                sqlCommand.Parameters.Add(out_total);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                MainConnection.Close();
                totalRecord = int.Parse(out_total.Value.ToString());
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_KhachHang_Xem_ChuaChon(int KhachHang_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_KHACHHANG_XEM_CHUACHON]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@KhachHang_ID", KhachHang_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public void CapNhatTaiKhoan(int taiKhoan_Id, string taiKhoan_DangNhap, string taiKhoan_MatKhau, string taiKhoan_HoTen, string taiKhoan_Email, string taiKhoan_SoDienThoai
            , string taiKhoan_AnhDaiDien, int taiKhoan_NguoiCapNhat, short taiKhoan_TrangThai, string taiKhoan_ViTri_ID, string taiKhoan_SoMayLe
            , int PhongBan_ID, int PhongBan_ViTri_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_CAPNHAT]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_DangNhap", taiKhoan_DangNhap).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_Id", taiKhoan_Id).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_MatKhau", taiKhoan_MatKhau).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_HoTen", taiKhoan_HoTen).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_Email", taiKhoan_Email).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_SoDienThoai", taiKhoan_SoDienThoai).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_AnhDaiDien", taiKhoan_AnhDaiDien).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@taiKhoan_NguoiCapNhat", taiKhoan_NguoiCapNhat).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_TrangThai", taiKhoan_TrangThai).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ViTri_ID", taiKhoan_ViTri_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_SoMayLe", taiKhoan_SoMayLe).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@PhongBan_ID", PhongBan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@PhongBan_ViTri_ID", PhongBan_ViTri_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::THEMMOI::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public TBL_TAIKHOAN ThongTinDangNhap(string TaiKhoan_DangNhap, string TaiKhoan_MatKhau)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_THONGTIN_DANGNHAP]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_DangNhap", TaiKhoan_DangNhap).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_MatKhau", TaiKhoan_MatKhau).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var taikhoan = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return taikhoan.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public TBL_TAIKHOAN ThongTinDangNhap_ByAdmin(string TaiKhoan_DangNhap)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_THONGTIN_DANGNHAP_BYADMIN]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_DangNhap", TaiKhoan_DangNhap).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var taikhoan = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return taikhoan.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan(string filter, short taiKhoan_TrangThai, int currentPage, int pageSize, out int totalRecord)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_DANHSACH]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TuKhoa", filter).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_TrangThai", taiKhoan_TrangThai).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@CurrentPage", currentPage).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@PageSize", pageSize).Direction = ParameterDirection.Input;
                SqlParameter out_total = new SqlParameter("@TotalRecord", SqlDbType.Int);
                out_total.Direction = ParameterDirection.InputOutput;
                out_total.Value = 0;
                sqlCommand.Parameters.Add(out_total);
                MainConnection.Open();
                var list = new List<TBL_TAIKHOAN>();
                using (IDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    list = PopulateObjectsFromReader(dataReader);
                }
                totalRecord = int.Parse(out_total.Value.ToString());
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::DanhSachTaiKhoan::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_PhanQuyen(string filter, int currentPage, int pageSize, out int totalRecord)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_DSPHANQUYEN]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TuKhoa", filter).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@CurrentPage", currentPage).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@PageSize", pageSize).Direction = ParameterDirection.Input;
                SqlParameter out_total = new SqlParameter("@TotalRecord", SqlDbType.Int);
                out_total.Direction = ParameterDirection.InputOutput;
                out_total.Value = 0;
                sqlCommand.Parameters.Add(out_total);
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                totalRecord = int.Parse(out_total.Value.ToString());
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::DanhSachTaiKhoan::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public bool CapNhatThongTinCaNhan(int TaiKhoan_ID, string TaiKhoan_HoTen, string TaiKhoan_Email, string TaiKhoan_SoDienThoai, string TaiKhoan_AnhDaiDien
            , DateTime? TaiKhoan_NgaySinh, int TaiKhoan_NguoiCapNhat, string Email_TenHienThi, string Email_MatKhau, string Email_MayChu, int? Email_Cong, string Email_ChuKy,
           bool ChangPass, string TaiKhoan_MatKhau)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TAIKHOAN_CAPNHAT_CHITIET]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_HoTen", TaiKhoan_HoTen).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_Email", TaiKhoan_Email).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_SoDienThoai", TaiKhoan_SoDienThoai).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_AnhDaiDien", TaiKhoan_AnhDaiDien).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_NgaySinh", TaiKhoan_NgaySinh).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_NguoiCapNhat", TaiKhoan_NguoiCapNhat).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@Email_TenHienThi", Email_TenHienThi).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@Email_MatKhau", Email_MatKhau).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@Email_MayChu", Email_MayChu).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@Email_Cong", Email_Cong).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@Email_ChuKy", Email_ChuKy).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@ChangPass", ChangPass).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_MatKhau", TaiKhoan_MatKhau).Direction = ParameterDirection.Input;

                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public bool CapNhatTaiKhoan_ViTriPhongBan(int TaiKhoan_ID, int PhongBan_ViTri_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_CAPNHAT_VITRI]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@PhongBan_ViTri_ID", PhongBan_ViTri_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public int KiemTraSoMayLe(int TaiKhoan_ID, string TaiKhoan_SoMayLe)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_KIEMTRA_SOMAYLE]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_SoMayLe", TaiKhoan_SoMayLe).Direction = ParameterDirection.Input;

                SqlParameter out_total = new SqlParameter("@Check_SoMayLe", SqlDbType.Int);
                out_total.Direction = ParameterDirection.InputOutput;
                out_total.Value = 0;
                sqlCommand.Parameters.Add(out_total);
                MainConnection.Open();
                sqlCommand.ExecuteReader();
                return int.Parse(out_total.Value.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::DanhSachTaiKhoan::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public int KiemTraViTri(int PhongBan_ID, int PhongBan_ViTri_ID, int TaiKhoan_ID, out string TaiKhoan_HoTen)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_PHONGBAN_VITRI_CHECKSUDUNG]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@PhongBan_ID", PhongBan_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@Vitri_ID", PhongBan_ViTri_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                SqlParameter out_total = new SqlParameter("@CheckSuDung", SqlDbType.Int);
                out_total.Direction = ParameterDirection.InputOutput;
                out_total.Value = 0;
                sqlCommand.Parameters.Add(out_total);

                SqlParameter out_ten = new SqlParameter("@TaiKhoanSuDung", SqlDbType.NVarChar);
                out_ten.Direction = ParameterDirection.InputOutput;
                out_ten.Size = 250;
                out_ten.Value = "";
                sqlCommand.Parameters.Add(out_ten);

                MainConnection.Open();
                sqlCommand.ExecuteReader();
                TaiKhoan_HoTen = out_ten.Value.ToString();
                return int.Parse(out_total.Value.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::DanhSachTaiKhoan::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

        public List<TBL_TAIKHOAN> DanhSachTaiKhoan_PhongBan(int phongbanId, string filter, int currentPage, int pageSize, out int totalRecord)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_PHONGBAN_TAIKHOAN_DANHSACH]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@PhongBan_ID", phongbanId).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TuKhoa", filter).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@CurrentPage", currentPage).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@PageSize", pageSize).Direction = ParameterDirection.Input;
                SqlParameter out_total = new SqlParameter("@TotalRecord", SqlDbType.Int);
                out_total.Direction = ParameterDirection.InputOutput;
                out_total.Value = 0;
                sqlCommand.Parameters.Add(out_total);
                MainConnection.Open();
                var list = new List<TBL_TAIKHOAN>();
                using (IDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    list = PopulateObjectsFromReader(dataReader);
                }
                totalRecord = int.Parse(out_total.Value.ToString());
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN::DanhSachTaiKhoan::Error occured.", ex);
            }
            finally
            {
                if (MainConnection.State != ConnectionState.Closed)
                {
                    MainConnection.Close();
                }
                sqlCommand.Dispose();
            }
        }

    }
}