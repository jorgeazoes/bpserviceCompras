using System.Threading.Tasks;
using Grpc.Core;

namespace PROYDOS
{
    class CResolucionOrdenImpl: CResolucionOrdenService.CResolucionOrdenServiceBase
    {
        // Server side handler of the GetTiempoEspera RPC
        public override Task<PutCResolucionOrdenResponse> PutCResolucionOrden(PutCResolucionOrdenRequest request, ServerCallContext context)
        {
            clsEnlaceDatos Data = new clsEnlaceDatos();
            return Task.FromResult( Data.PutCResolucionOrden(request) );
        }
    }
}