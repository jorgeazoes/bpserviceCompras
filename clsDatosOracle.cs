using System.Data;


namespace PROYDOS
{
public static class clsDatosOracle
    {
        private const string cNombrePaquete = "PD_MONITOR_WEB.{0}";
        private const string cNombrePaquete_Web = "pd_interfaz_web_aprobacion.{0}";
        private const string cCodUsuario = "MONITOR";

        #region Monitor
        /// <summary>
        /// Buscar parámetro que indica cada cuantos N minitos debe actualizarse la página.
        /// </summary>
        /// <returns></returns>
        public static string BuscaTiempoConsulta()
        {
            string vCantidad = "-1";

            //Limpia parámetros de la sesion
            clsConexionOracle.LimpiarComando();
            //Agrega un parámetro de salida
            clsConexionOracle.AgregarParametroSalidaVarchar("pcan_minutos");

            //Ejecuta el procedimiento almacenado
            clsConexionOracle.EjecutarNonQuery(string.Format(cNombrePaquete, "pr_tiempo_consulta"), false);
            //Buscamos el resultado del parámetro de salida
            vCantidad = clsConexionOracle.ObtenerValorParametro("pcan_minutos");
            //Limpiarmos la sesión para no dejar basura en cache
            clsConexionOracle.LimpiarComando();

            return vCantidad;
        }

        /// <summary>
        /// Buscar parámetro que indica cada cuantos N minitos debe actualizarse la página.
        /// </summary>
        /// <returns></returns>
        public static string InicializaDatosSeguimiento()
        {
            string vError = "";

            //Limpia parámetros de la sesion
            clsConexionOracle.LimpiarComando();

            //Agrega un parámetros
            clsConexionOracle.AgregarParametro("pcod_usuario", cCodUsuario);
            clsConexionOracle.AgregarParametroSalidaVarchar("pmsj_error");

            //Ejecuta el procedimiento almacenado
            clsConexionOracle.EjecutarNonQuery(string.Format(cNombrePaquete, "pr_inicaliza_reporte"), false);

            //Buscamos el resultado del parámetro de salida
            vError = clsConexionOracle.ObtenerValorParametro("pmsj_error");


            //Limpiarmos la sesión para no dejar basura en cache
            clsConexionOracle.LimpiarComando();

            return vError;

        }


        /// <summary>
        /// Busca la configuración de posibles estados del seguimiento
        /// </summary>
        /// <returns></returns>
        public static DataSet CargaEstadosSeguimiento()
        {
            DataSet vDs = new DataSet();

            //Agrega un parámetros
            clsConexionOracle.AgregarCursorSalida("pdatos");
            clsConexionOracle.AgregarParametroSalidaVarchar("pmsj_error");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete, "pr_lista_estados"), "Estados");
            return vDs;

        }

        /// <summary>
        /// Retorna la cantidad de solicitudes de un asistente para un estado en particular
        /// </summary>
        /// <returns></returns>
        public static int CantidadAsistente_x_Estado(string pCodEstado, string pCodAsistente)
        {
            int vCantidad = 0;
            string vmsjError;
            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_usuario", cCodUsuario);
            clsConexionOracle.AgregarParametro("pcod_estado", pCodEstado);
            clsConexionOracle.AgregarParametro("pcod_asistente", pCodAsistente);
            clsConexionOracle.AgregarCursorSalida("pcantidad");
            clsConexionOracle.AgregarParametroSalidaVarchar("pmsj_error");

            //Ejecuta el procedimiento almacenado
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete, "pr_cantidad_estado_asistente"), "Estados");

            //Buscamos el resultado del parámetro de salida
            vCantidad = int.Parse(vDs.Tables[0].Rows[0][0].ToString());
            vmsjError = clsConexionOracle.ObtenerValorParametro("pmsj_error").ToString();

            clsConexionOracle.LimpiarParametos();

            return vCantidad;

        }        

        /// <summary>
        /// Carga el grid de resumen de cantidad por estado
        /// </summary>
        /// <returns></returns>
        public static DataSet CargaEstados()
        {
            DataSet vDs = new DataSet();

            //Agrega un parámetros
            clsConexionOracle.AgregarParametro("pcod_usuario", "MONITOR");
            clsConexionOracle.AgregarCursorSalida("pdatos");
            clsConexionOracle.AgregarParametroSalidaVarchar("pmsj_error");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete, "pr_cantidad_x_estado"), "Estados");
            return vDs;

        }

        #endregion Monitor

        #region Ordenes

        /// <summary>
        /// Busca las Ordenes de Compro pendientes de Aprobación
        /// </summary>
        /// <returns></returns>
        public static DataSet CargaOrdenes(string pcod_empresa, string pcod_usuario_windows)
        {

            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarCursorSalida("pcur_orden_compra");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "orden_compra_obtiene_pendiente"), "Ordenes");
            return vDs;

        }

        /// <summary>
        /// Busca las Ordenes de Compra por Solicitud pendientes de Aprobación
        /// </summary>
        /// <returns></returns>
        public static DataSet CargaOrdenCompraxSolicitud(string pcod_empresa, string pcod_usuario_windows, string num_orden_compra)
        {

            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_orden_compra", num_orden_compra);
            clsConexionOracle.AgregarCursorSalida("pcur_ord_com_soli");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "orden_compra_x_solicitud"), "OrdenesxSolicitud");
            return vDs;

        }

        /// <summary>
        /// Busca el listado de Productos por Solicitud de Ordenes pendientes de Aprobación
        /// </summary>
        /// <returns></returns>
        public static DataSet CargaProductosxSolicitud(string pcod_empresa, string pcod_usuario_windows, string pnum_orden_compra, string pnum_requisicion)
        {

            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_orden_compra", pnum_orden_compra);
            clsConexionOracle.AgregarParametro("pnum_requisicion", pnum_requisicion);
            clsConexionOracle.AgregarCursorSalida("pcur_productos");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "listado_productos_x_solicitud"), "ProductosxSolicitud");
            return vDs;

        }


        /// <summary>
        /// Busca las Ordenes de Compra por Solicitud pendientes de Aprobación
        /// </summary>
        /// <returns></returns>
        public static string OrdenCompraProcesaresolucion(string pcod_empresa, string pcod_usuario_windows, string ptip_resolucion,
                                                           string pnum_orden_compra, string pnum_autorizacion, string pdes_observaciones)
        {

            DataSet vDs = new DataSet();
            string vErrorUsuario;
            string vErrorTecnico;
            string vMensajeExitoso;
            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("ptip_resolucion", ptip_resolucion);
            clsConexionOracle.AgregarParametro("pnum_orden_compra", pnum_orden_compra);
            clsConexionOracle.AgregarParametro("pnum_autorizacion", pnum_autorizacion);
            clsConexionOracle.AgregarParametro("pdes_observaciones", pdes_observaciones);
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");


            clsConexionOracle.EjecutarNonQuery(string.Format(cNombrePaquete_Web, "orden_compra_procesaresolucion"), false);
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
        /// 
        /// </summary>
        /// <param name="pcod_empresa"></param>
        /// <param name="pcod_usuario_windows"></param>
        /// <param name="pnum_orden_compra"></param>
        /// <returns></returns>
        public static DataSet CargaAprobadores(string pcod_empresa, string pcod_usuario_windows, string pnum_orden_compra)
        {

            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_orden_compra", pnum_orden_compra);
            clsConexionOracle.AgregarCursorSalida("pcur_list_aprob");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "orden_compra_list_aprobadores"), "ListadoAprobadores");
            return vDs;

        }


        public static DataSet CargaAdjuntos(string pcod_empresa, string pcod_usuario_windows, string pnum_orden_compra)
        {

            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_orden_compra", pnum_orden_compra);
            clsConexionOracle.AgregarCursorSalida("pcur_list_adjuntos");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "orden_compra_list_adjuntos"), "ListadoAdjuntos");
            return vDs;

        }


        //orden_compra_procesaresolucion
        #endregion Ordenes

        #region Cotizaciones

        /// <summary>
        /// Busca las Cotizaciones según la orden de Compra Seleccionada
        /// </summary>
        /// <returns></returns>
        public static DataSet CargaCotizacionesxOrden(string pcod_empresa, string pcod_usuario_windows, string pnum_comparativo)
        {

            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_comparativo", pnum_comparativo);
            clsConexionOracle.AgregarCursorSalida("pcur_cotizaciones");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "cotizaciones_list_x_orden"), "CotizacionesxOrden");
            return vDs;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcod_empresa"></param>
        /// <param name="pcod_usuario_windows"></param>
        /// <param name="pnum_comparativo"></param>
        /// <returns></returns>
        public static DataSet CargaDetalleCotizacion(string pcod_empresa, string pcod_usuario_windows, string pnum_cotizacion,string pnum_cotizacion_deta)
        {

            DataSet vDs = new DataSet();

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_cotizacion", pnum_cotizacion);
            clsConexionOracle.AgregarParametro("pnum_cotizacion_deta", pnum_cotizacion_deta);
            clsConexionOracle.AgregarCursorSalida("pcur_cotizaciones");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            vDs = clsConexionOracle.EjecutarConsulta(string.Format(cNombrePaquete_Web, "cotizaciones_list_detalle"), "CotizacionesDetalle");
            return vDs;

        }

        #endregion        

        #region Reportes

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcod_empresa"></param>
        /// <param name="pcod_usuario_windows"></param>
        /// <param name="pnum_comparativo"></param>
        /// <returns></returns>
        public static string GeneraComparativoOrden(string pcod_empresa, string pcod_usuario_windows, string pnum_comparativo)
        {

            string vErrorUsuario;
            string vErrorTecnico;          

            string vArchivo;

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_comparativo", pnum_comparativo);
            clsConexionOracle.AgregarParametroSalidaVarchar("pnom_archivo");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            clsConexionOracle.EjecutarNonQuery(string.Format(cNombrePaquete_Web, "rep_comparativo_orden"), false);
            //
            vArchivo = clsConexionOracle.ObtenerValorParametro("pnom_archivo");
            vErrorTecnico = clsConexionOracle.ObtenerValorParametro("perror_tecnico");
            vErrorUsuario = clsConexionOracle.ObtenerValorParametro("perror_usuario");


            if (vErrorTecnico != "000000")
            {
                return vErrorUsuario;
            }
            else
            {
                //vMensajeExitoso = "000000";
                return vArchivo;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcod_empresa"></param>
        /// <param name="pcod_usuario_windows"></param>
        /// <param name="pnum_orden_compra"></param>
        /// <returns></returns>
        public static string GeneraOrdenCompra(string pcod_empresa, string pcod_usuario_windows, string pnum_orden_compra)
        {

            string vErrorUsuario;
            string vErrorTecnico;            

            string vArchivo;

            //Agrega un parámetros

            clsConexionOracle.AgregarParametro("pcod_empresa", pcod_empresa);
            clsConexionOracle.AgregarParametro("pcod_usuario_windows", pcod_usuario_windows);
            clsConexionOracle.AgregarParametro("pnum_orden_compra", pnum_orden_compra);
            clsConexionOracle.AgregarParametroSalidaVarchar("pnom_archivo");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_usuario");
            clsConexionOracle.AgregarParametroSalidaVarchar("perror_tecnico");

            //
            clsConexionOracle.EjecutarNonQuery(string.Format(cNombrePaquete_Web, "rep_orden_compra"), false);
            //
            vArchivo = clsConexionOracle.ObtenerValorParametro("pnom_archivo");
            vErrorTecnico = clsConexionOracle.ObtenerValorParametro("perror_tecnico");
            vErrorUsuario = clsConexionOracle.ObtenerValorParametro("perror_usuario");


            if (vErrorTecnico != "000000")
            {
                return vErrorUsuario;
            }
            else
            {
                //vMensajeExitoso = "000000";
                return vArchivo;
            }

        }

        #endregion Reportes

    }
}