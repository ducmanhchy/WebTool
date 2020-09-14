using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace WebSampleTool.DataAccess.DataLayer
{
    abstract class DataLayerBase : IDisposable
    {
        SqlConnection _mainConnection;
        bool _isDisposed;

        public DataLayerBase()
        {
            InitClass();
        }

        private void InitClass()
        {
            // create Connection Object
            _mainConnection = new SqlConnection();

            // Get connection string from Config File and set to the connection
            _mainConnection.ConnectionString = MakeConnectionString() + ";Connection Timeout=30";
            _isDisposed = false;
        }

        #region Properties

        /// <summary>
        /// get the sql connection object
        /// </summary>
        protected SqlConnection MainConnection
        {
            get { return _mainConnection; }

        }
        private string MakeConnectionString()
        {
            var subDomain = HttpContext.Current.Request.RequestContext.RouteData.Values["subdomain"];
            string cnnstr = string.Empty;
            cnnstr = string.Format("Data Source={0};Initial Catalog={1};User Id = {2};Password = {3}",
                                    ConfigurationManager.AppSettings["SERVER"],
                                   ConfigurationManager.AppSettings["PREFIX_DB"] + (subDomain != null ? subDomain.ToString().ToUpper() : ""),
                                    //  ConfigurationManager.AppSettings["DATABASE"],
                                    ConfigurationManager.AppSettings["USERID"],
                                    ConfigurationManager.AppSettings["PASSWORD"]);
            return cnnstr;
        }

        protected bool IsConnection()
        {
            _mainConnection = new SqlConnection();
            try
            {
                // Get connection string from Config File and set to the connection
                _mainConnection.ConnectionString = MakeConnectionString() + ";Connection Timeout=2";
                _mainConnection.Open();
                if (_mainConnection.State != ConnectionState.Closed) _mainConnection.Close();
                return true;
            }
            catch
            {
                if (_mainConnection.State != ConnectionState.Closed) _mainConnection.Close();
                return false;
            }
        }

        #endregion

        #region IDisposeable

        protected virtual void Dispose(bool bIsDisposing)
        {
            // Check to see if Dispose has already been called.
            if (!_isDisposed)
            {
                if (bIsDisposing)
                {
                    // Dispose managed resources.
                    _mainConnection.Dispose();
                    _mainConnection = null;
                }
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}