using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using PROYDOS.Interfaces;

namespace PROYDOS.controller
{
     class OrdenesCompraImpl: OrdenesCompraService.OrdenesCompraServiceBase
    {      

        public override async Task GetOrdenes(GetOrdenesRequest request, IServerStreamWriter<GetOrdenesResponse> responseStream, ServerCallContext context)
        {
            var clsEnlace = new clsEnlaceDatos();
            var listOrdenes = new List<OrdenesCompra>();
            listOrdenes = clsEnlace.GetListaOrdenes(request);

            for (int i = 0; i < listOrdenes.Count; i++)
            {
                OrdenesCompra item = listOrdenes[i];
                await responseStream.WriteAsync(new GetOrdenesResponse { Ordencompra = item });
            }

        // Console.WriteLine("Finished reponse stream");
    }
        
    }
}