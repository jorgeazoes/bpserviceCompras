using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using PROYDOS.Interfaces;

namespace PROYDOS.controller
{
     class CContizacionesImpl: CCotizacionesService.CCotizacionesServiceBase
    {      

        public override async Task GetCotizaciones(GetCCotizacionRequest request, IServerStreamWriter<GetCCotizacionResponse> responseStream, ServerCallContext context)
        {
            var clsEnlace = new clsEnlaceDatos();
            var listCotizaciones = new List<CCotizacionOrden>();
            listCotizaciones = clsEnlace.GetCotizaciones(request);

            for (int i = 0; i < listCotizaciones.Count; i++)
            {
                CCotizacionOrden item = listCotizaciones[i];
                await responseStream.WriteAsync(new GetCCotizacionResponse { CCotizacionOrden = item });
            }

        // Console.WriteLine("Finished reponse stream");
    }
        
    }
     

}