using System;
using System.Collections.Generic;
using System.Text;

namespace xml_vs_sqlite
{
    public class Resultados
    {
        private Dictionary<int, TimeSpan> _tiemposGuardadoXML;
        private Dictionary<int, TimeSpan> _tiemposGuardadoSQL;
        private Dictionary<int, TimeSpan> _tiemposRecuperacionXML;
        private Dictionary<int, TimeSpan> _tiemposRecuperacionSQL;
        private Dictionary<int, long> _tamañosArchivosXML;
        private Dictionary<int, long> _tamañosArchivosSQL;

        public Resultados() {
            _tiemposGuardadoXML = new Dictionary<int, TimeSpan>();
            _tiemposGuardadoSQL = new Dictionary<int, TimeSpan>();
            _tiemposRecuperacionXML = new Dictionary<int, TimeSpan>();
            _tiemposRecuperacionSQL = new Dictionary<int, TimeSpan>();
            _tamañosArchivosXML = new Dictionary<int, long>();
            _tamañosArchivosSQL = new Dictionary<int, long>();
        }


        public Dictionary<int, TimeSpan> TiemposGuardadoXML{
            get{
                return  _tiemposGuardadoXML;
            }
        }
        public Dictionary<int, TimeSpan> TiemposRecuperacionXML{
            get{
                return  _tiemposRecuperacionXML;
            }
        }


        public Dictionary<int, TimeSpan> TiemposGuardadoSQL
        {
            get
            {
                return _tiemposGuardadoSQL;
            }
        }
        public Dictionary<int, TimeSpan> TiemposRecuperacionSQL
        {
            get
            {
                return _tiemposRecuperacionSQL;
            }
        }

        public Dictionary<int, long> TamañosArchivosXML {
            get {
                return _tamañosArchivosXML;
            }
        }
        public Dictionary<int, long> TamañosArchivosSQL
        {
            get
            {
                return _tamañosArchivosSQL;
            }
        }
    }
    
}
