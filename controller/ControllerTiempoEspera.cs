using System.Threading.Tasks;
using Grpc.Core;

namespace PROYDOS
{
    class TiempoEsperaImpl: TiempoEsperaService.TiempoEsperaServiceBase
    {
        // Server side handler of the GetTiempoEspera RPC
        public override Task<TiempoEspera> GetTiempoEspera(TiempoEsperaRequest request, ServerCallContext context)
        {
            clsEnlaceDatos tiempoEsperaData = new clsEnlaceDatos();
            return Task.FromResult( tiempoEsperaData.GetTiempoEspera(request) );
        }
    }
}