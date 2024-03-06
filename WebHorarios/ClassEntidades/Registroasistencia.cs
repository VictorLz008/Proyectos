using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Registroasistencia
    {
        public int IdRegistro { get; set; }
        public DateTime Fecha { get; set; }
        public int HorarioId { get; set; }
        public string Tema { get; set; }
        public int TotalAlumnos { get; set; }
        public string Observaciones { get; set; }
    }
}
