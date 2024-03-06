using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Asignaturas
    {
        public int IdAsignatura { get; set; }
        public string NameAsignatura { get; set; }
        public string descripcion { get; set; }
        public int HorasS { get; set; }
        public int cuatrimestre { get; set; }
    }
}
