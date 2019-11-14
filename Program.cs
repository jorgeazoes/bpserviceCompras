using System;
using System.Collections.Generic;
using Grpc.Core;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PROYDOS.controller;
using PROYDOS.Interfaces;

namespace PROYDOS
{
    public class Program
    {
        public readonly IConfiguration _configuracion;
        //public static int Port;

        const int Port = 4500;
        public Program(IConfiguration configuration)
        {
            _configuracion = configuration;
             //Port = _configuracion.GetValue<int>("Puerto");// 4000;
            //this._strVariable = "";
        }        
        
//        public IConfiguration Configuration { get; }


        private string _strVariable;
        public string VariableConnection()
        {            
              this._strVariable = string.IsNullOrEmpty(_configuracion.GetConnectionString("DefaultConnection")) ?  "" : _configuracion.GetConnectionString("DefaultConnection");
               return  _strVariable;          
            
        }
        public static void Main(string[] args)
        {
            try
            {
                Server server = new Server
                {
                    Services = { TiempoEsperaService.BindService(new TiempoEsperaImpl()),
                                 OrdenesCompraService.BindService(new OrdenesCompraImpl()),
                                 CListaAprobadoresService.BindService(new CListaAprobadoresImpl()),
                                 CResolucionOrdenService.BindService(new CResolucionOrdenImpl()),
                                 CListaAdjuntosService.BindService(new CListaAdjuntosImpl()),
                                 CCotizacionesService.BindService(new CContizacionesImpl()),
                                 CCotizacionDetalleService.BindService(new CContizacionDetaImpl())
                                 },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }

                };

                server.Start();

                Console.WriteLine();
                // CreateWebHostBuilder(args).Build().Run();
             
                var clsEnlace = new clsEnlaceDatos();
                
                
               // var listOrdenes = new List<OrdenesCompra>();
               // var listAprob= new List<CAprobadoresOrden>();
                //var request = new GetCAprobadoresRequest();
                var request = new PutCResolucionOrdenRequest(){
                PcodEmpresa = "1",
                PcodUsuarioWindows = "PVEGA",
                CResolucion = new CResolucionOrden {
                    NumOrdenCompra = "750",
                    TipResolucion = "A",
                    NumAutorizacion = "5",
                    DesObservaciones = "Observaciones"                 
                  }
                };

              /*var listareq = new GetCCotizacionRequest(){
                PcodEmpresa = "1",
                PcodUsuarioWindows = "PVEGA",                
                PnumComparativo = "344"                
                };*/

                 var listareq = new GetCCotizacionDetaRequest(){
                PcodEmpresa = "1",
                PcodUsuarioWindows = "PVEGA",                
                PnumCotizacion = "359",
                PnumCotizacionDeta = ""
                };
                   
               // var response = clsEnlace.PutCResolucionOrden(request);
                //Console.WriteLine(response.ToString());

                // Console.WriteLine("Mensaje_Respuesta: " + response.CResolucion.MensajeRepuesta.ToString());
                 
                 var listPrueba = clsEnlace.GetCotizacionDetalle(listareq);

                for (int i = 0; i < listPrueba.Count; i++)
                {
                    CCotizacionDeta item = listPrueba[i];
                    //await responseStream.WriteAsync(new GetOrdenesResponse { Ordencompra = item });
                    Console.WriteLine("Cotizacion: " + item.NumCantidad);

                }      


                //listAprob = clsEnlace.GetListaAprobadores(request);

                

             /*   for (int i = 0; i < listAprob.Count; i++)
                {
                    CAprobadoresOrden item = listAprob[i];
                    //await responseStream.WriteAsync(new GetOrdenesResponse { Ordencompra = item });
                    Console.WriteLine("NumOrdenCompra: " + item.NomUsuario);

                }*/ 
                
                Console.WriteLine("Accounts server listening on port " + Port);
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();
                server.ShutdownAsync().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string strVariable;
            strVariable = _configuracion.GetConnectionString("DefaultConnection");
            Console.WriteLine(strVariable);

        }



        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            /* app.Run(async (context) =>
             {
                 await context.Response.WriteAsync("Hello World!");

             });*/
        }

    }



    /* public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }*/
}
