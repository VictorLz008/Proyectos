using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ClassDAL;
using ClassEntidades;
using System.Data.SqlClient;

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
            p.Add(new MySqlParameter("am", MySqlDbType.String, 150));

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
            dal.ConsultaMultipleDS(copia, "SELECT * FROM docentes", mySqlConnection, "docentes", ref msj);
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
            p.Add(new MySqlParameter("am", MySqlDbType.String, 150));

            // FILL THE FIELDS
            p[0].Value = docente.idDocente;
            p[1].Value = docente.nombre;
            p[2].Value = docente.AP;
            p[3].Value = docente.AM;

            // UPDATE
            string actualizacion = "UPDATE docentes SET Nombre = @name, A_Paterno = @ap, A_Materno = @am WHERE idDocente = @id;";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(actualizacion, p, mySqlConnection, ref msj);

            return result;
        }
        public List<Docentes> DRObtenDocentes(ref string msj)
        {
            // Open Conection
            MySqlConnection conex = dal.AbrirConexion(ref msj);
            List<Docentes> salida = new List<Docentes>();

            MySqlDataReader atrapa = null;
            atrapa = dal.ConsultaDR("SELECT * FROM docentes", conex, ref msj);

            if (atrapa != null)
            {
                // Query is correct, will be processed the DataRead

                while (atrapa.Read())
                {
                    salida.Add(new Docentes()
                    {
                        idDocente = (int)atrapa[0],
                        nombre = atrapa[1].ToString(),
                        AP = atrapa[2].ToString(),
                        AM = atrapa[3].ToString(),

                    });
                }
                // Close the conection
                conex.Close();
                conex.Dispose();
            }
            else
            { // Only if the query is invalid or the conection failed
                if (atrapa.IsClosed)
                {
                    msj += " La consulta con DR no fue exitosa";
                }
            }

            return salida;
        }

        public Boolean EliminarDocente(int id, ref string msj)
        {

            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            string eliminacion = "DELETE FROM docentes WHERE idDocente = " + id;
            Boolean result = dal.ModificacionBD(eliminacion, mySqlConnection, ref msj);

            return result;
        }
    }
}

