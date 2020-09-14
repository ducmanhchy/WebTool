using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebSampleTool.DataAccess.Entity;
using WebSampleTool.Utilily;

namespace WebSampleTool.DataAccess.DataLayer
{
    class TBL_QUYEN_CHUCNANGsql : DataLayerBase
    {
        public TBL_QUYEN_CHUCNANGsql()
        {
        }

        internal List<TBL_QUYEN_CHUCNANG> PopulateObjectsFromReader(IDataReader dataReader)
        {
            return dataReader.MapToList<TBL_QUYEN_CHUCNANG>();
        }

        public List<TBL_QUYEN_CHUCNANG> DanhSachQuyen_ChucNang()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_QUYEN_CHUCNANG_DANHSACH]";
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
                throw new Exception("TBL_QUYEN_CHUCNANG::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public List<TBL_QUYEN_CHUCNANG> DanhSachQuyen_ChucNang_QuyenID(int Quyen_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_QUYEN_CHUCNANG_DANHSACH_QUYENID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@Quyen_ID", Quyen_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_QUYEN_CHUCNANG::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public bool CapNhatQuyen_ChucNang(int Quyen_ID, string ChucNang_IDs)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_QUYEN_CHUCNANG_CAPNHAT]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@Quyen_ID", Quyen_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@ChucNang_IDs", ChucNang_IDs).Direction = ParameterDirection.Input;
                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                MainConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        public int KiemTraQuyen_TaiKhoanDangNhap(int TaiKhoan_NhomQuyen_ID, string ControllerName, string ActionName, int TaiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_KIEMTRA_QUYEN_CHUCNANG_NEW]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_NhomQuyen_ID", TaiKhoan_NhomQuyen_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@Controller", ControllerName).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@Action", ActionName).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@ChucNang_Loai", 1).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                SqlParameter out_check = new SqlParameter("@CheckQuyen", SqlDbType.Int);
                out_check.Direction = ParameterDirection.InputOutput;
                out_check.Value = 0;
                sqlCommand.Parameters.Add(out_check);

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return int.Parse(out_check.Value.ToString());
            }
            catch (Exception ex)
            {
                return 1;
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }
    }
}