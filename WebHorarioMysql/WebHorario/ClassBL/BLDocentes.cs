using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ClassDAL;
using ClassEntidades;

namespace ClassBL
{
    public class BLDocentes
    {
        DALhorario dal = null;

        public BLDocentes(string conex)
        {
            dal = new DALhorario(conex);
        }

        public Boolean RegistrarDocente(Docentes docente, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("name", MySqlDbType.String, 150));
            p.Add(new MySqlParameter("ap", MySqlDbType.String, 150));
            p.Add(new MySqlParameter("am", MySqlDbType.Int64, 150));

            // FILL THE FIELDS
            p[0].Value = docente.nombre;
            p[1].Value = docente.AP;
            p[2].Value = docente.AM;

            // INSERT
            string insercion = "INSERT INTO docentes(Nombre, A_Paterno, A_Materno ) VALUES (@name, @ap, @am) ";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(insercion, p, mySqlConnection, ref msj);

            return result;
        }

        public DataSet MostrarDocentes(ref string msj)
        {
            DataSet copia = new DataSet();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            dal.ConsultaMultipleDS(copia, "SELECT * FROM docentes", mySqlConnection, "especialidad", ref msj);
            return copia;
        }

        public Boolean ModificarDocente(Docentes docente, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("id", MySqlDbType.Int64));
            p.Add(new MySqlParameter("name", MySqlDbType.String, 150));
            p.Add(new MySqlParameter("ap", MySqlDbType.String, 150));
            p.Add(new MySqlParameter("am", MySqlDbType.Int64, 150));

            // FILL THE FIELDS
            p[0].Value = docente.idDocente;
            p[0].Value = docente.nombre;
            p[1].Value = docente.AP;
            p[2].Value = docente.AM;

            // INSERT
            string actualizacion = "UPDATE docentes SET Nombre = @name, A_Paterno = @ap, A_Materno = @am WHERE idDocente = @id;";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(actualizacion, p, mySqlConnection, ref msj);

            return result;
        }



        public Boolean EliminarEspecialidad(int id, ref string msj)
        {

            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            string eliminacion = "DELETE FROM docentes WHERE idDocente = " + id;
            Boolean result = dal.ModificacionBD(eliminacion, mySqlConnection, ref msj);

            return result;
        }
    }
}
