using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using PROYDOS.Interfaces;

namespace PROYDOS.controller
{
     class CListaAdjuntosImpl: CListaAdjuntosService.CListaAdjuntosServiceBase
    {      

        public override async Task GetAdjuntos(GetCAdjuntosRequest request, IServerStreamWriter<GetCAdjuntosResponse> responseStream, ServerCallContext context)
        {
            var clsEnlace = new clsEnlaceDatos();
            var listAdjuntos = new List<CAdjuntosOrden>();
            listAdjuntos = clsEnlace.GetListaAdjuntos(request);

            for (int i = 0; i < listAdjuntos.Count; i++)
            {
                CAdjuntosOrden item = listAdjuntos[i];
                await responseStream.WriteAsync(new GetCAdjuntosResponse { CAdjuntos = item });
            }

        // Console.WriteLine("Finished reponse stream");
    }
        
    }
}