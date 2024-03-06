using ClassEntidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;


namespace ClassBL
{
    public class BLAsignacionCuatrimestral
    {

        DALhorario dal = null;

        public BLAsignacionCuatrimestral(string conex)
        {
            dal = new DALhorario(conex);
        }


        public Boolean RegistrarAsignacionCuatrimestral(AsignacionCuatrimestral asig, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("group", MySqlDbType.Int64));
            p.Add(new MySqlParameter("teacher", MySqlDbType.Int64));
            p.Add(new MySqlParameter("subject", MySqlDbType.Int64));

            // FILL THE FIELDS
            p[0].Value = asig.grupoID;
            p[1].Value = asig.docenteID;
            p[2].Value = asig.asignaturaID;

            // INSERT
            string insercion = "INSERT INTO asignacioncuatrimestral(GrupoID, DocenteID, AsignaturaID ) VALUES (@group, @teacher, @subject) ";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(insercion, p, mySqlConnection, ref msj);

            return result;
        }

        public DataSet MostrarAsignacionCuatrimestral(ref string msj)
        {
            DataSet copia = new DataSet();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            dal.ConsultaMultipleDS(copia, "SELECT AC.idAsignacion, AC.GrupoID, G.NomGrupo, G.Turno, AC.DocenteID ,D.Nombre, D.A_Paterno, AC.AsignaturaID, A.NomAsignatura, A.DescripcionAsig  FROM asignacioncuatrimestral AS AC \r\nJOIN grupos AS G ON AC.GrupoID = G.Idgrupo\r\nJOIN docentes AS D ON AC.DocenteID = D.idDocente\r\nJOIN asignaturas AS A ON AC.AsignaturaID = A.idasignatura ", mySqlConnection, "asignacion", ref msj);
            return copia;
        }

        public Boolean ModificarAsignacionCuatrimestral(AsignacionCuatrimestral asig, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("id", MySqlDbType.Int64));
            p.Add(new MySqlParameter("group", MySqlDbType.Int64));
            p.Add(new MySqlParameter("teacher", MySqlDbType.Int64));
            p.Add(new MySqlParameter("subject", MySqlDbType.Int64));

            // FILL THE FIELDS
            p[0].Value = asig.idAsignacion;
            p[1].Value = asig.grupoID;
            p[2].Value = asig.docenteID;
            p[3].Value = asig.asignaturaID;

            // INSERT
            string insercion = "UPDATE asignacioncuatrimestral SET GrupoID = @group, DocenteID = @teacher, AsignaturaID = @subject ";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(insercion, p, mySqlConnection, ref msj);

            return result;
        }


        public Boolean EliminarAsignacionCuatrimestral(int id, ref string msj)
        {

            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            string eliminacion = "DELETE FROM asignacioncuatrimestral WHERE idAsignacion = " + id;
            Boolean result = dal.ModificacionBD(eliminacion, mySqlConnection, ref msj);

            return result;
        }
    }
}
