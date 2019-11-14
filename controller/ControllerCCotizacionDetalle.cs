using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using PROYDOS.Interfaces;

namespace PROYDOS.controller
{
   
     class CContizacionDetaImpl: CCotizacionDetalleService.CCotizacionDetalleServiceBase
    {      

        public override async Task GetCotizacionDetalle(GetCCotizacionDetaRequest request, IServerStreamWriter<GetCCotizacionDetaResponse> responseStream, ServerCallContext context)
        {
            var clsEnlace = new clsEnlaceDatos();
            var listCotizacionDeta = new List<CCotizacionDeta>();
            listCotizacionDeta = clsEnlace.GetCotizacionDetalle(request);

            for (int i = 0; i < listCotizacionDeta.Count; i++)
            {
                CCotizacionDeta item = listCotizacionDeta[i];
                await responseStream.WriteAsync(new GetCCotizacionDetaResponse { CCotizacionDetaOrden = item });
            }

        // Console.WriteLine("Finished reponse stream");
    }
        
    }

}