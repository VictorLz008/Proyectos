using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public string dia { get; set; }
        public string hinicio { get; set; }
        public string hfinal { get; set; }
        public string NomAula { get; set; }
        public string Turno { get; set; }
        public string profesor { get; set; }
        public string App { get; set; }
        public string NomAsigantura { get; set; }
    }
}
