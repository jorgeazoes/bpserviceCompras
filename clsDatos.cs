using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PROYDOS
{
    public class clsDatos
    {
       /* private string _cod_empresa;
        private string _cod_usuario_windows;
        private string _num_solicitud;
        private DataSet _cur_det_solic;
        private DataSet _cur_personas_noti;
        private string _error_tecnico;
        private string _error_usuario;*/

        public string Cod_empresa { get; set; }
        public string Cod_usuario_windows { get; set; }        
        public DataSet Cur_Datos_Uno { get; set; }
        public DataSet Cur_Datos_Dos { get; set; }
        public string ParamStrUno { get; set; }
        public string ParamStrDos { get; set; }
        public string ParamStrTres { get; set; }
        public string ParamStrCuatro { get; set; }
        public string ParamStrCinco { get; set; }
        public string ParamStrSeis { get; set; }
        public string Error_tecnico { get; set; }
        public string Error_usuario { get; set; }
        
    }
}
