using System;
using System.Collections;
using System.Data;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;


namespace PROYDOS
{
     public static class clsConexionOracle
    {
      // public readonly IConfiguration _configuracion;
       
        private static string _stringConexion;
        private static OracleConnection _conexion;
        private static OracleCommand _comando;
        private static OracleDataAdapter _adaptador;
        private static OracleTransaction _transaccion;

        private static OracleParameter _parametro;
        private static OracleParameter _parametroSalida;
        private static ArrayList _arrParametros = new ArrayList();
        
        /* public clsConexionOracle(IConfiguration configuration)
        {
            _configuracion = configuration;
             _stringConexion = _configuracion.GetValue<string>("ConnectionDB");
            //this._strVariable = "";
        }     */ 
        private static void StringConexion()
        {
            //PromUtilidades.Encriptador.encritparWebConfig();
           /*  if (ConfigurationManager.AppSettings["SonPruebas"].ToString().ToUpper() == "TRUE")
            {
                _stringConexion = ConfigurationManager.ConnectionStrings["DESARROLLO"].ConnectionString;
            }
            else
            { 
                _stringConexion = ConfigurationManager.ConnectionStrings["PRODUCCION"].ConnectionString; 
            }
            _conexion = new OracleConnection(_stringConexion);*/

             _stringConexion = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=" + 
                                "DESARROLLO" + ")(Port=" + "1521" + ")))(CONNECT_DATA=(SERVICE_NAME=" +
                                "XE" + "))); User Id=" + "jonl" + ";Password=" + "123" + "; ";

                 
            _conexion = new OracleConnection(_stringConexion);

        }

        #region AgregarParametros
        public static void AgregarParametro(string pNombre, string pValor)
        {
            _parametro = new OracleParameter(pNombre, pValor);
            _arrParametros.Add(_parametro);
        }

        public static void AgregarParametro(string pNombre, Int32 pValor)
        {
            _parametro = new OracleParameter(pNombre, pValor);
            _arrParametros.Add(_parametro);
        }

        public static void AgregarParametro(string pNombre, Int64 pValor)
        {
            _parametro = new OracleParameter(pNombre, pValor);
            _arrParametros.Add(_parametro);
        }

        public static void AgregarParametro(string pNombre, DateTime pValor)
        {
            _parametro = new OracleParameter(pNombre, OracleDbType.Date);
            _parametro.Value = pValor;
            _arrParametros.Add(_parametro);
        }

        public static void AgregarParametro(string pNombre, Double pValor)
        {
            _parametro = new OracleParameter(pNombre, pValor);
            _arrParametros.Add(_parametro);
        }

        public static void AgregarParametro(string pNombre, byte[] pValor)
        {
            _parametro = new OracleParameter(pNombre, pValor);
            _parametro.OracleDbType = OracleDbType.Clob;
            _arrParametros.Add(_parametro);
        }

        public static void AgregarParametro(string pNombre, DBNull pValor)
        {
            _parametro = new OracleParameter(pNombre, pValor);
            _arrParametros.Add(_parametro);
        }

        public static void AgregarParametroSalidaNumerico(string pNombre)
        {
            _parametroSalida = new OracleParameter(pNombre, OracleDbType.Decimal);
            _parametroSalida.Direction = System.Data.ParameterDirection.Output;
            _arrParametros.Add(_parametroSalida);
        }

        public static void AgregarParametroSalidaVarchar(string pNombre)
        {
            _parametroSalida = new OracleParameter(pNombre, OracleDbType.Varchar2);
            _parametroSalida.Direction = System.Data.ParameterDirection.Output;
            _parametroSalida.Size = 40000;
            _arrParametros.Add(_parametroSalida);
        }

        public static void AgregarCursorSalida(string pNombre)
        {
            _parametroSalida = new OracleParameter(pNombre, OracleDbType.RefCursor, ParameterDirection.Output);
            _arrParametros.Add(_parametroSalida);
        }

        #endregion

        #region Metodos

        #region Ejecutar Non Query
              
        public static void EjecutarNonQuery(string pQuery, bool pLimpiarComando = true)
        { EjecutarNonQuery(pQuery, CommandType.StoredProcedure, false, pLimpiarComando); }

        public static void EjecutarNonQuery(string pQuery, CommandType pTipo, bool pLimpiarComando = true)
        { EjecutarNonQuery(pQuery, pTipo, false, pLimpiarComando); }

        public static void EjecutarNonQuery(string pQuery, bool pUtilizaTransaccion, bool pLimpiarComando = true)
        { EjecutarNonQuery(pQuery, CommandType.StoredProcedure, pUtilizaTransaccion, pLimpiarComando); }

        public static void EjecutarNonQuery(string pQuery, CommandType pTipo, bool pUtilizaTransaccion, bool pLimpiarComando = true)
        {
            string verror = null;
            try
            {
                InicializarComando(pQuery, pTipo, pUtilizaTransaccion);
                
                _comando.ExecuteNonQuery();
            }
            catch (OracleException oex)
            {
                try
                {
                    verror = oex.Errors[0].Message.ToString();
                    throw new Exception(verror);
                }
                catch (Exception exo)
                { throw exo; }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (!pUtilizaTransaccion)
                { CerrarConexion(); }
                if (pLimpiarComando)
                    LimpiarComando();
            }

        }

        public static void LimpiarConexiones()
        {
            _conexion = null;
            _comando = null;
            _adaptador = null;
        }

        public static Int64 ObtenerValorParametro()
        {
            return Convert.ToInt64(_parametroSalida.Value.ToString());
        }

        public static string ObtenerValorParametro(string pNombre)
        {
            string vValor = "";

            foreach (OracleParameter parametro in _arrParametros)
            {
                if (parametro.ParameterName == pNombre)
                {
                    vValor = parametro.Value.ToString();
                    break;
                }
            }
            return vValor;
        }

        public static bool ProbarConexion() 
        {
            bool vResultado = false;
            try 
	        {	        
		        InicializarComando("", CommandType.StoredProcedure, false);
                vResultado = true;
                _transaccion = null;
                CerrarConexion();
	        }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(OracleException))
                {}
                else
                {}
                vResultado = false;                               
            } 
            return vResultado;            
        }

        #endregion

        #region Ejecutar Scalar
        public static object EjecutarEscalar(string pQuery)
        { return EjecutarEscalar(pQuery, CommandType.StoredProcedure, false); }

        public static object EjecutarEscalar(string pQuery, CommandType pTipo)
        { return EjecutarEscalar(pQuery, pTipo, false); }

        public static object EjecutarEscalar(string pQuery, bool pUtilizaTransaccion)
        { return EjecutarEscalar(pQuery, CommandType.StoredProcedure, pUtilizaTransaccion); }

        public static object EjecutarEscalar(string pQuery, CommandType pTipo, bool pUtilizaTransaccion)
        {
            try
            {
                InicializarComando(pQuery, pTipo, pUtilizaTransaccion);

                return _comando.ExecuteScalar();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (!pUtilizaTransaccion)
                { CerrarConexion(); }
                LimpiarComando();
            }
        }
        #endregion

        #region Obtener Consulta

        public static DataSet EjecutarConsulta(string pQuery, string pNombreTabla)
        { return EjecutarConsulta(pQuery, pNombreTabla, CommandType.StoredProcedure, false); }

        public static DataSet EjecutarConsulta(string pQuery, string pNombreTabla, CommandType pTipo)
        { return EjecutarConsulta(pQuery, pNombreTabla, pTipo, false); }

        public static DataSet EjecutarConsulta(string pQuery, string pNombreTabla, bool pUtilizaTransaccion)
        { return EjecutarConsulta(pQuery, pNombreTabla, CommandType.StoredProcedure, pUtilizaTransaccion); }

        public static DataSet EjecutarConsulta(string pQuery, string pNombreTabla, CommandType pTipo, bool pUtilizaTransaccion)
        {
            try
            {
                InicializarComando(pQuery, pTipo, pUtilizaTransaccion);
                _adaptador = new OracleDataAdapter(_comando);
                DataSet lDatos = new DataSet("Datos");

                _adaptador.Fill(lDatos, pNombreTabla);

                return lDatos;
            }
            catch (OracleException OraErr)
            {
                throw OraErr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            finally
            {
                if (!pUtilizaTransaccion)
                { CerrarConexion(); }
                LimpiarComando();
            }
        }

        public static IDataReader EjecutarConsultaReader(string pQuery)
        {
            IDataReader datos;

            try
            {
                InicializarComando(pQuery, CommandType.StoredProcedure, false);

                datos = _comando.ExecuteReader();

                return datos;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                //CerrarConexion();
                LimpiarComando();
            }
        }
        #endregion

        private static void InicializarComando(string pQuery, CommandType pTipo, bool pUtilizaTransaccion)
        {

            if (_conexion == null) { StringConexion(); }
            if (_comando == null)
            {
                _comando = new OracleCommand();
                _comando.Connection = _conexion;
            }

            _comando.CommandText = pQuery;
            _comando.CommandType = pTipo;
            _comando.CommandTimeout = 0;

            AbrirConexion();

            AgregarParametrosAComando();

            if (pUtilizaTransaccion)
            {
                if (_transaccion == null) { _transaccion = _conexion.BeginTransaction(); }
                if (_comando.Transaction == null) { _comando.Transaction = _transaccion; }
            }
        }

        public static void LimpiarComando()
        {
            _comando = null;
            _arrParametros.Clear();
        }

        public static void LimpiarParametos()
        {
            _arrParametros.Clear();
        }

        public static void Commit()
        {
            _transaccion.Commit();
        }

        private static void AbrirConexion()
        { if (_conexion.State == ConnectionState.Closed) { _conexion.Open(); } }

        private static void CerrarConexion()
        { if (_conexion.State == ConnectionState.Open) { _conexion.Close(); } }

        public static void FinalizarTransaccion()
        {
            _transaccion.Commit();
            _transaccion = null;
            CerrarConexion();
        }

        public static void CancelarTransaccion()
        {
            if (_transaccion != null)
            { _transaccion.Rollback(); }
            _transaccion = null;
            CerrarConexion();
        }

        private static void AgregarParametrosAComando()
        {
            foreach (OracleParameter MiParametro in _arrParametros)
            {
                _comando.Parameters.Add(MiParametro);
            }
        }
        

        #endregion
    }
    }