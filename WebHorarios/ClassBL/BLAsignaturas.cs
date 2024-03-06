
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;
using ClassEntidades;


namespace ClassBL
{
    public class BLAsignaturas
    {
        DALhorario dal = null;

        public BLAsignaturas(string conex)
        {
            dal = new DALhorario(conex);
        }

        public List<Asignaturas> DRObtenAsignaturas(ref string msj)
        {
            // Open Conection
            MySqlConnection conex = dal.AbrirConexion(ref msj);
            List<Asignaturas> salida = new List<Asignaturas>();

            MySqlDataReader atrapa = null;
            atrapa = dal.ConsultaDR("SELECT * FROM asignaturas", conex, ref msj);

            if (atrapa != null)
            {
                // Query is correct, will be processed the DataRead

                while (atrapa.Read())
                {
                    salida.Add(new Asignaturas()
                    {
                        IdAsignatura = (int)atrapa[0],
                        NameAsignatura = atrapa[1].ToString(),
                        descripcion = atrapa[2].ToString(),
                        HorasS = (int)atrapa[3],
                        cuatrimestre = (int)atrapa[4]
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

        public Boolean RegistrarAsigantura(Asignaturas nueva, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("nombre", MySqlDbType.String, 250));
            p.Add(new MySqlParameter("desc", MySqlDbType.String, 250));
            p.Add(new MySqlParameter("horas", MySqlDbType.Int64));
            p.Add(new MySqlParameter("cuatrimestre", MySqlDbType.Int64));

            // FILL THE FIELDS
            p[0].Value = nueva.NameAsignatura;
            p[1].Value = nueva.descripcion;
            p[2].Value = nueva.HorasS;
            p[3].Value = nueva.cuatrimestre;

            // INSERT
            string insercion = "INSERT INTO asignaturas(NomAsignatura, DescripcionAsig, HrsxSemana,Cuatrimestre ) VALUES (@nombre, @desc, @horas,@cuatrimestre) ";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(insercion, p, mySqlConnection, ref msj);

            return result;
        }

        public DataSet MostrarAsigantura(ref string msj)
        {
            DataSet copia = new DataSet();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            dal.ConsultaMultipleDS(copia, "SELECT * FROM asignaturas", mySqlConnection, "asignaturas", ref msj);
            return copia;
        }

        public Boolean ModificarAsignatura(Asignaturas nueva, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("id", MySqlDbType.Int64));
            p.Add(new MySqlParameter("nombre", MySqlDbType.String, 150));
            p.Add(new MySqlParameter("desc", MySqlDbType.String, 150));
            p.Add(new MySqlParameter("horas", MySqlDbType.Int64));
            p.Add(new MySqlParameter("cuatrimestre", MySqlDbType.Int64));

            // FILL THE FIELDS
            p[0].Value = nueva.IdAsignatura;
            p[1].Value = nueva.NameAsignatura;
            p[2].Value = nueva.descripcion;
            p[3].Value = nueva.HorasS;
            p[4].Value = nueva.cuatrimestre;

            // INSERT
            string actualizacion = "UPDATE asignaturas SET NomAsignatura = @nombre, DescripcionAsig = @desc, HrsxSemana = @horas, Cuatrimestre = @cuatrimestre WHERE idasignatura = @id;";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(actualizacion, p, mySqlConnection, ref msj);

            return result;
        }


        public List<Asignaturas> DRObtenAsiganaturas(ref string msj)
        {
            // Open Conection
            MySqlConnection conex = dal.AbrirConexion(ref msj);
            List<Asignaturas> salida = new List<Asignaturas>();

            MySqlDataReader atrapa = null;
            atrapa = dal.ConsultaDR("SELECT * FROM asignaturas", conex, ref msj);

            if (atrapa != null)
            {
                // Query is correct, will be processed the DataRead

                while (atrapa.Read())
                {
                    salida.Add(new Asignaturas()
                    {
                        IdAsignatura = (int)atrapa[0],
                        NameAsignatura = atrapa[1].ToString(),
                        descripcion = atrapa[2].ToString(),
                        HorasS = (int)atrapa[3],
                        cuatrimestre = (int)atrapa[4]
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


        public Boolean EliminarAsignatura(int id, ref string msj)
        {

            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            string eliminacion = "DELETE FROM asignaturas WHERE idasignatura = " + id;
            Boolean result = dal.ModificacionBD(eliminacion, mySqlConnection, ref msj);

            return result;
        }
    }
}
