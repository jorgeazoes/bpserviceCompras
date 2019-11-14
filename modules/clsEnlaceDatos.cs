

using System.Collections.Generic;
using System.Linq;
using System.Data;
using PROYDOS.Interfaces;

namespace PROYDOS
{
public class clsEnlaceDatos //: IRepositorioclsEnlaceDatos 
    {
        public TiempoEspera GetTiempoEspera (TiempoEsperaRequest request)
        {
            TiempoEspera tiempoMunitos = new TiempoEspera();

            try{

            string vtiempo = clsDatosOracle.BuscaTiempoConsulta(); 
            tiempoMunitos.Minutos = vtiempo;
                        
            }catch {


            }
                                
    return tiempoMunitos;        
           
        }

         public List<OrdenesCompra> GetListaOrdenes (GetOrdenesRequest request)
        {            
            List<OrdenesCompra> listOrdenes = new List<OrdenesCompra>();

            DataSet ds = new DataSet();
            
            try{

                ds = clsDatosOracle.CargaOrdenes(request.PcodEmpresa,request.PcodUsuarioWindows);             
                
                listOrdenes = (from DataRow dr in ds.Tables[0].Rows  
                select new OrdenesCompra()  
                {  
                    CodEmpresa = dr["cod_empresa"].ToString(),  
                    NumOrdenCompra = dr["num_orden_compra"].ToString(),  
                    TitOrdenCompra = dr["tit_orden_compra"].ToString(),  
                    FecOrden = dr["fec_orden"].ToString(),
                    NumAutorizacion = dr["num_autorizacion"].ToString(),
                    NumComparativo = dr["num_comparativo"].ToString()                   
                }).ToList();  

            }catch {


            }
                                
            return listOrdenes;        
           
        }

         public List<CAprobadoresOrden> GetListaAprobadores (GetCAprobadoresRequest request)
        {            
            List<CAprobadoresOrden> listAprobadores = new  List<CAprobadoresOrden>();

            DataSet ds = new DataSet();
            
            try{

                ds = clsDatosOracle.CargaAprobadores(request.PcodEmpresa,request.PcodUsuarioWindows, request.NumOrdenCompra );             
                
                listAprobadores = (from DataRow dr in ds.Tables[0].Rows  
                select new CAprobadoresOrden()  
                {  
                    CodEmpresa = dr["cod_empresa"].ToString(),  
                    NumOrdenCompra = dr["num_orden_compra"].ToString(),  
                    CodUsuario = dr["cod_usuario"].ToString(), 
                    NomUsuario =  dr["nom_usuario"].ToString(), 

                    FecResolucion = dr["fec_resolucion"].ToString(),
                    NomEstado = dr["nom_estado"].ToString(),
                    ObsUsuario = dr["obs_usuario"].ToString()  

                }).ToList();  

            }catch {


            }
                                
            return listAprobadores;        
           
        }

        public List<CAdjuntosOrden> GetListaAdjuntos (GetCAdjuntosRequest request)
        {            
            List<CAdjuntosOrden> listAdjuntos = new  List<CAdjuntosOrden>();

            DataSet ds = new DataSet();
            
            try{

                ds = clsDatosOracle.CargaAdjuntos(request.PcodEmpresa,request.PcodUsuarioWindows, request.NumOrdenCompra );             
                
                listAdjuntos = (from DataRow dr in ds.Tables[0].Rows  
                select new CAdjuntosOrden()  
                {  
                    CodEmpresa = dr["cod_empresa"].ToString(),  
                    NumOrdenCompra = dr["num_orden_compra"].ToString(),  
                    NumArchivo = dr["num_archivo"].ToString(), 
                    CodDocumento =  dr["cod_documento"].ToString(), 
                    TipoDocumento =  dr["tipo_documento"].ToString(),                  
                    NomArchivo = dr["nom_archivo"].ToString(),
                    RutArchivo= dr["rut_archivo"].ToString(),  
                    UsrAdiciona = dr["usr_adiciona"].ToString(),
                    FecAdiciona = dr["fec_adiciona"].ToString()  
                }).ToList();  

            }catch {


            }
                                
            return listAdjuntos;        
           
        }

        public List<CCotizacionOrden> GetCotizaciones (GetCCotizacionRequest request)
        {            
            List<CCotizacionOrden> listCotizaciones = new  List<CCotizacionOrden>();

            DataSet ds = new DataSet();
            
            try{

                ds = clsDatosOracle.CargaCotizacionesxOrden(request.PcodEmpresa,request.PcodUsuarioWindows, request.PnumComparativo );             
                
                listCotizaciones = (from DataRow dr in ds.Tables[0].Rows  
                select new CCotizacionOrden()  
                {  
                    CodEmpresa = dr["cod_empresa"].ToString(),  
                    NumCotizacion = dr["num_cotizacion"].ToString(),  
                    FecCotizacion= dr["fec_cotizacion"].ToString(), 
                    CodUsuario= dr["cod_usuario"].ToString(), 
                    Asistente =  dr["asistente"].ToString(),
                    FecVencimiento =  dr["fec_vencimiento"].ToString(),                  
                    CodEstado = dr["cod_estado"].ToString(),
                    NomEstado = dr["nom_estado"].ToString()
                }).ToList();  

            }catch {


            }
                                
            return listCotizaciones;        
           
        }

        public List<CCotizacionDeta> GetCotizacionDetalle (GetCCotizacionDetaRequest request)
        {            
            List<CCotizacionDeta> listCotizacionDetalle = new  List<CCotizacionDeta>();

            DataSet ds = new DataSet();
            
            try{

                ds = clsDatosOracle.CargaDetalleCotizacion(request.PcodEmpresa,request.PcodUsuarioWindows, 
                                                           request.PnumCotizacion, request.PnumCotizacionDeta );             
                
                listCotizacionDetalle = (from DataRow dr in ds.Tables[0].Rows  
                select new CCotizacionDeta()  
                {  
                    CodEmpresa = dr["cod_empresa"].ToString(),  
                    NumCotizacion = dr["num_cotizacion"].ToString(),  
                    NumCotizacionDetalle = dr["num_cotizacion_detalle"].ToString(), 
                    NumCantidad = dr["num_cantidad"].ToString(), 
                    NumProducto =  dr["num_producto"].ToString(),                     
                    NomProducto =  dr["nom_producto"].ToString(),                  
                    Embalaje = dr["Embalaje"].ToString(),
                    ObsUsuario = dr["obs_usuario"].ToString(),
                }).ToList();  

            }catch {


            }
                                
            return listCotizacionDetalle;        
           
        }

        public PutCResolucionOrdenResponse PutCResolucionOrden (PutCResolucionOrdenRequest request)
        {            
            PutCResolucionOrdenResponse response = new PutCResolucionOrdenResponse();

            string strRespuesta;
            
            try{

                strRespuesta = clsDatosOracle.OrdenCompraProcesaresolucion(request.PcodEmpresa, request.PcodUsuarioWindows, request.CResolucion.TipResolucion,
                request.CResolucion.NumOrdenCompra, request.CResolucion.NumAutorizacion, request.CResolucion.DesObservaciones );

             response = new PutCResolucionOrdenResponse
            {                             
                CResolucion = new CResolucionOrden{                
                    CodEmpresa = request.PcodEmpresa,  
                    NumOrdenCompra = request.CResolucion.NumOrdenCompra,  
                    TipResolucion = request.CResolucion.TipResolucion,
                    NumAutorizacion = request.CResolucion.NumAutorizacion,
                    DesObservaciones = request.CResolucion.DesObservaciones,
                    MensajeRepuesta = strRespuesta.ToString()
                },
                PerrorTecnico = "1",
                PerrorUsuario = "PVEGA" 
             };

            }catch {


            }
                                
            return response;        
           
        }

    }

}