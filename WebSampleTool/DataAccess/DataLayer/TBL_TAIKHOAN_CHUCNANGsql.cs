using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebSampleTool.DataAccess.Entity;

namespace WebSampleTool.DataAccess.DataLayer
{
    class TBL_TAIKHOAN_CHUCNANGsql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public TBL_TAIKHOAN_CHUCNANGsql()
        {
            // Nothing for now.
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void Dispose(bool bIsDisposing)
        {
            base.Dispose(bIsDisposing);
        }

        #endregion Constructor

        #region Public Methods

        public List<TBL_TAIKHOAN_CHUCNANG> DanhSachTaiKhoanChucNang(int TaiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_CHUCNANG_DANHSACH]";
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
                throw new Exception("TBL_TAIKHOAN_CHUCNANG::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }


        public bool ThemMoiTaiKhoanChucNang(int TaiKhoan_ID, string ChucNang_IDs)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_CHUCNANG_THEMMOI]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
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

        public bool XoaTaiKhoanChucNang(int TaiKhoan_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_CHUCNANG_XOA]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
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


        public List<TBL_TAIKHOAN_CHUCNANG> DanhSachTaiKhoan_Quyen_ChucNang(int TaiKhoan_ID, int NhomQuyen_ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[SP_TBL_TAIKHOAN_QUYEN_CHUCNANG]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_NhomQuyen_ID", NhomQuyen_ID).Direction = ParameterDirection.Input;
                sqlCommand.Parameters.AddWithValue("@TaiKhoan_ID", TaiKhoan_ID).Direction = ParameterDirection.Input;
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                var list = PopulateObjectsFromReader(dataReader);
                MainConnection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("TBL_TAIKHOAN_CHUCNANG::SelectAll::Error occured.", ex);
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }


        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(TBL_TAIKHOAN_CHUCNANG businessObject, IDataReader dataReader)
        {
            if (dataReader.GetSchemaTable().Rows.OfType<DataRow>().Any(row => row["ColumnName"].ToString() == "TaiKhoan_ID"))
            {
                int ordinal = dataReader.GetOrdinal(TBL_TAIKHOAN_CHUCNANG.TBL_TAIKHOAN_CHUCNANG_Fields.TaiKhoan_ID.ToString());
                if (!dataReader.IsDBNull(ordinal))
                    businessObject.TaiKhoan_ID = dataReader.GetInt32(ordinal);
            }

            if (dataReader.GetSchemaTable().Rows.OfType<DataRow>().Any(row => row["ColumnName"].ToString() == "ChucNang_ID"))
            {
                int ordinal = dataReader.GetOrdinal(TBL_TAIKHOAN_CHUCNANG.TBL_TAIKHOAN_CHUCNANG_Fields.ChucNang_ID.ToString());
                if (!dataReader.IsDBNull(ordinal))
                    businessObject.ChucNang_ID = dataReader.GetInt32(ordinal);
            }

            if (dataReader.GetSchemaTable().Rows.OfType<DataRow>().Any(row => row["ColumnName"].ToString() == "ChucNang_Ma"))
            {
                int ordinal = dataReader.GetOrdinal(TBL_TAIKHOAN_CHUCNANG.TBL_TAIKHOAN_CHUCNANG_Fields.ChucNang_Ma.ToString());
                if (!dataReader.IsDBNull(ordinal))
                    businessObject.ChucNang_Ma = dataReader.GetString(ordinal);
            }
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of TBCF_EMPLOYEES</returns>
        internal List<TBL_TAIKHOAN_CHUCNANG> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<TBL_TAIKHOAN_CHUCNANG> list = new List<TBL_TAIKHOAN_CHUCNANG>();
            while (dataReader.Read())
            {
                TBL_TAIKHOAN_CHUCNANG businessObject = new TBL_TAIKHOAN_CHUCNANG();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion Private Methods
    }
}