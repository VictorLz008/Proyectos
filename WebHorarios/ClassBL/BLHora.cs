using ClassDAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassEntidades;

namespace ClassBL
{
    public class BLHora
    {
        private DALhorario dal = null;

        public BLHora(string conex)
        {
            dal = new DALhorario(conex);
        }

        public List<Horario> DRObhora(ref string msj)
        {
            List<Horario> Lsalida = new List<Horario>();
            MySqlConnection con = dal.AbrirConexion(ref msj);
            string consulta = "SELECT idHorario, NomDia, HrInicio, HrFinal, NombAula, Turno, Nombre as Profesor, A_Paterno, NomAsignatura FROM horario as h " +
                              "inner join aulas as a on h.AulaId = a.idAula " +
                              "inner join diasemana as d on h.DiaId = d.iddia " +
                              "inner join asignacioncuatrimestral as asig on h.AsignacionID = asig.idAsignacion " +
                              "inner join grupos as g on asig.GrupoID = g.Idgrupo " +
                              "inner join docentes as do on asig.DocenteID = do.idDocente " +
                              "inner join asignaturas as asignatura on asig.AsignaturaID = asignatura.idasignatura";
            MySqlDataReader atrapa = dal.ConsultaDR(consulta, con, ref msj);

            if (atrapa != null)
            {
                // La consulta es correcta, procesaremos los resultados del DataReader

                while (atrapa.Read())
                {
                    Lsalida.Add(new Horario()
                    {
                        IdHorario = (int)atrapa[0],
                        dia = atrapa[1].ToString(),
                        hinicio = atrapa[2].ToString(),
                        hfinal = atrapa[3].ToString(),
                        NomAula = atrapa[4].ToString(),
                        Turno = atrapa[5].ToString(),
                        profesor = atrapa[6].ToString(),
                        App = atrapa[7].ToString(),
                        NomAsigantura = atrapa[8].ToString(),
                    });
                }

                // Cerrar la conexión
                con.Close();
                con.Dispose();
            }
            else
            {
                if (atrapa.IsClosed)
                {
                    msj += " La consulta con DataReader no fue exitosa";
                }
            }

            return Lsalida;
        }
    }
}
