using System.Collections.Generic;
using System.Linq;
using System.Data;
using PROYDOS.Interfaces;

namespace PROYDOS
{
    public static class clsBuscaDatosPagos
    {

        private const string cNombrePaquete_Web = "pd.pd_interfaz_web_pagos.{0}";


        #region PAGOS

        /// <summary>
        ///  Procedimiento que retorna el cursor con las Solicitudes de Pago pendientes de resolución para el usuario del parámetro.
        /// </summary>
        /// <param name="pcod_empresa">Codigo de empresa referenciada del core para el que se ejecuta el proceso</param>
        /// <param name="pcod_usuario_windows">Codigo de usuario de windows que ejecuta el proceso</param>
        /// <returns></returns>
        public static DataSet CargaSolicitudes(string pcod_empresa, string pcod_usuario_windows)
        {

            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarCursorSalida("pcur_solicitudes_pendientes");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "pd_pg_solicitudes_pendientes"), "PgSolicitudes");
            return vDs;

        }

        /// <summary>
        /// Proyecto [_VNOMBREPROYECTO_]
        /// Procedimiento: SolicitudPagoProcesaresolucion
        /// Fecha: 01/09/2019
        /// Analista: JONL
        /// Descripción: Ejecuta el proceso de resolución de la Solicitud de Pago
        /// HISTORIA
        /// C1: Creacion.
        /// </summary>
        /// <param name="pcod_empresa"></param>
        /// <param name="pcod_usuario_windows"></param>
        /// <param name="pnum_solicitud"></param>
        /// <param name="pnum_autorizacion"></param>
        /// <param name="pnum_autorizacion_det"></param>
        /// <param name="pcod_estado"></param>
        /// <param name="pobs_resolucion"></param>
        /// <param name="pcod_usuario_proceso"></param>
        /// <returns></returns>
        public static string SolicitudPagoProcesaresolucion(string pcod_empresa, string pcod_usuario_windows, string pnum_solicitud,
                                                      string pnum_autorizacion, string pnum_autorizacion_det, string pcod_estado,
                                                      string pobs_resolucion, string pcod_usuario_proceso)
        {

            DataSet vDs = new DataSet();
            string vErrorUsuario;
            string vErrorTecnico;
            string vMensajeExitoso;
            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_solicitud", pnum_solicitud);
            clsConexionOracle.AgregarParametro("pnum_autorizacion", pnum_autorizacion);
            clsConexionOracle.AgregarParametro("pnum_autorizacion_det", pnum_autorizacion_det);
            clsConexionOracle.AgregarParametro("pcod_estado", pcod_estado);
            clsConexionOracle.AgregarParametro("pobs_resolucion", pobs_resolucion);
            clsConexionOracle.AgregarParametro("pcod_usuario_proceso", pcod_usuario_proceso);
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");



            clsConexionOracle.EjecutarNonQuery(string.Format(cNombrePaquete_Web, "pd_pg_pago_procesaresolucion"), false);
            //
            vErrorTecnico = clsConexionOracle.ObtenerValorParametro("perror_tecnico");
            vErrorUsuario = clsConexionOracle.ObtenerValorParametro("perror_usuario");


            if (vErrorTecnico != "000000")
            {
                return vErrorUsuario;
            }
            else
            {

                vMensajeExitoso = "000000";
                return vMensajeExitoso;
            }

        }

        /// <summary>
        /// Proyecto [_VNOMBREPROYECTO_]
        /// Procedimiento: CargaAprobadores
        /// Fecha: 01/09/2019
        /// Analista: JONL
        /// Descripción: Extrae el listado de Aprobadores para una Solicitud de Pago.
        /// HISTORIA
        /// C1: Creacion.
        /// </summary>
        /// <param name="pcod_empresa"></param>
        /// <param name="pcod_usuario_windows">Codigo de usuario que ejecuta el proceso</param>
        /// <param name="pnum_autorizacion"></param>
        /// <returns></returns>
        public static DataSet CargaAprobadores(string pcod_empresa, string pcod_usuario_windows, string pnum_autorizacion)
        {

            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_autorizacion", pnum_autorizacion);
            clsConexionOracle.AgregarCursorSalida("pcur_list_aprob");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "pd_pg_list_aprobadores"), "ListadoAprobadoresPg");
            return vDs;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcod_empresa"></param>
        /// <param name="pcod_usuario_windows"></param>
        /// <param name="pnum_solicitud"></param>
        /// <returns></returns>
        public static clsDatos CargaDetalleSolicitud(string pcod_empresa, string pcod_usuario_windows, string pnum_solicitud)
        {

            DataSet vDsDetalleSolicitud = new DataSet();
            DataSet vDsPersonasNotif = new DataSet();

           
            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_solicitud", pnum_solicitud);
            clsConexionOracle.AgregarParametro("pnum_indicador", 1);          
            clsConexionOracle.AgregarCursorSalida("pcur_datos_detalle");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            vDsDetalleSolicitud = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "pd_pg_detalle_solicitud"), "DetalleSolicitudPg");


            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_solicitud", pnum_solicitud);
            clsConexionOracle.AgregarParametro("pnum_indicador", 2);
            clsConexionOracle.AgregarCursorSalida("pcur_datos_detalle");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            vDsPersonasNotif = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "pd_pg_detalle_solicitud"), "PersonasNotificPg");

            clsDatos clsDetalle = new clsDatos() {
                Cod_empresa = pcod_empresa,
                Cod_usuario_windows = pcod_usuario_windows,
                Cur_Datos_Uno = vDsDetalleSolicitud,
                Cur_Datos_Dos = vDsPersonasNotif,
                ParamStrUno = pnum_solicitud
            };

            return clsDetalle;

        }


        public static DataSet CargaListaFacturas(string pcod_empresa, string pcod_usuario_windows, string pnum_solicitud)
        {

            DataSet vDsFacturaEnca = new DataSet();
          
            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_solicitud", pnum_solicitud);
            clsConexionOracle.AgregarParametro("pnum_factura", "");
            clsConexionOracle.AgregarParametro("pnum_factura_registro", "");
            clsConexionOracle.AgregarParametro("pnum_indicador", 1);
            clsConexionOracle.AgregarCursorSalida("pcur_datos");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            ////Si factura y registro son nulos o vacios se abre el dataset para elegir el detalle del primer registro
            //if (String.IsNullOrEmpty(pnum_factura) && String.IsNullOrEmpty(pnum_factura_registro))
            //{


            //}           

            vDsFacturaEnca = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "pd_pg_listado_facturas"), "FacturaEncaPg");
           
            return vDsFacturaEnca;                     

        }


        public static DataSet CargaFacturaDetalle(string pcod_empresa, string pcod_usuario_windows, string pnum_solicitud, string pnum_factura, string pnum_factura_registro)
        {

            DataSet vDsFacturaDeta = new DataSet();


            //Agrega un parámetros
                        
            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_solicitud", pnum_solicitud);
            clsConexionOracle.AgregarParametro("pnum_factura", pnum_factura);
            clsConexionOracle.AgregarParametro("pnum_factura_registro", pnum_factura_registro);
            clsConexionOracle.AgregarParametro("pnum_indicador", 2);
            clsConexionOracle.AgregarCursorSalida("pcur_datos_detalle");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            vDsFacturaDeta = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "pd_pg_listado_facturas"), "FacturaDetaPg");
            
            return vDsFacturaDeta;

        }

        #endregion PAGOS


    }
}
