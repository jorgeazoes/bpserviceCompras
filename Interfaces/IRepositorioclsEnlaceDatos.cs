using System.Collections.Generic;

namespace PROYDOS.Interfaces
{
    public interface IRepositorioclsEnlaceDatos
    {
          TiempoEspera GetTiempoEspera (TiempoEsperaRequest request);
          List<OrdenesCompra> GetListaOrdenes (GetOrdenesRequest request);
    }
}