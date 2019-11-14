using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using PROYDOS.Interfaces;

namespace PROYDOS.controller
{
     class CListaAprobadoresImpl: CListaAprobadoresService.CListaAprobadoresServiceBase
    {      

        public override async Task GetAprobadores(GetCAprobadoresRequest request, IServerStreamWriter<GetCAprobadoresResponse> responseStream, ServerCallContext context)
        {
            var clsEnlace = new clsEnlaceDatos();
            var listAprobadores = new List<CAprobadoresOrden>();
            listAprobadores = clsEnlace.GetListaAprobadores(request);

            for (int i = 0; i < listAprobadores.Count; i++)
            {
                CAprobadoresOrden item = listAprobadores[i];
                await responseStream.WriteAsync(new GetCAprobadoresResponse { CAprobador = item });
            }

        // Console.WriteLine("Finished reponse stream");
    }
        
    }
}