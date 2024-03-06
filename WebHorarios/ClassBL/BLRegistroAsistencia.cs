using ClassDAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassEntidades;

namespace ClassBL
{
    public class BLRegistroAsistencia
    {
        DALhorario dal = null;

        public BLRegistroAsistencia(string conex)
        {
            dal = new DALhorario(conex);
        }

        public Boolean RegistrarRegistroAsistencia(Registroasistencia nueva, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("fecha", MySqlDbType.Date));
            p.Add(new MySqlParameter("HoraId", MySqlDbType.Int64));
            p.Add(new MySqlParameter("Tema", MySqlDbType.VarChar, 255));
            p.Add(new MySqlParameter("TotalAl", MySqlDbType.Int64));
            p.Add(new MySqlParameter("observaciones", MySqlDbType.VarChar, 255));

            // FILL THE FIELDS
            p[0].Value = nueva.Fecha;
            p[1].Value = nueva.HorarioId;
            p[2].Value = nueva.Tema;
            p[3].Value = nueva.TotalAlumnos;
            p[4].Value = nueva.Observaciones;

            // INSERT
            string insercion = "INSERT INTO registroasistencia (Fecha, HorarioID, Tema,TotalAlumnos,Observaciones ) " +
                "VALUES (@fecha, @HoraId, @Tema, @TotalAl, @observaciones);";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(insercion, p, mySqlConnection, ref msj);

            return result;
        }

        public DataSet MostrarRegistroAsistencia(ref string msj)
        {
            DataSet copia = new DataSet();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            dal.ConsultaMultipleDS(copia, "SELECT * FROM registroasistencia", mySqlConnection, "registroasistencia", ref msj);
            return copia;
        }

        public Boolean ModificarRegistroAsistencia(Registroasistencia nueva, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("id", MySqlDbType.Int64));
            p.Add(new MySqlParameter("fecha", MySqlDbType.DateTime));
            p.Add(new MySqlParameter("HoraId", MySqlDbType.Int64));
            p.Add(new MySqlParameter("Tema", MySqlDbType.VarChar, 255));
            p.Add(new MySqlParameter("TotalAl", MySqlDbType.Int64));
            p.Add(new MySqlParameter("observaciones", MySqlDbType.VarChar, 255));

            // FILL THE FIELDS
            p[0].Value = nueva.IdRegistro;
            p[1].Value = nueva.Fecha;
            p[2].Value = nueva.HorarioId;
            p[3].Value = nueva.Tema;
            p[4].Value = nueva.TotalAlumnos;
            p[5].Value = nueva.Observaciones;

            // INSERT
            string actualizacion = "UPDATE registroasistencia SET Fecha = @fecha, HorarioID = @HoraId, Tema = @Tema, TotalAlumnos = @TotalAl, Observaciones=@observaciones WHERE idRegistro = @id;";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(actualizacion, p, mySqlConnection, ref msj);

            return result;
        }


        public List<Registroasistencia> DRObtenRegistroAsistencia(ref string msj)
        {
            // Open Conection
            MySqlConnection conex = dal.AbrirConexion(ref msj);
            List<Registroasistencia> salida = new List<Registroasistencia>();

            MySqlDataReader atrapa = null;
            atrapa = dal.ConsultaDR("SELE idRegistro,DATE_FORMAT(Fecha, '%Y-%m-%d') as fecha,HorarioID,Tema,TotalAlumnos FROM registroasistencia", conex, ref msj);


            if (atrapa != null)
            {
                // Query is correct, will be processed the DataRead

                while (atrapa.Read())
                {
                    salida.Add(new Registroasistencia()
                    {
                        IdRegistro = (int)atrapa[0],
                        Fecha = (DateTime)atrapa[1],
                        HorarioId = (int)atrapa[2],
                        Tema = atrapa[3].ToString(),
                        TotalAlumnos = (int)atrapa[4],
                        Observaciones = atrapa[5].ToString(),
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


        public Boolean EliminarRegistroasistencia(int id, ref string msj)
        {

            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            string eliminacion = "DELETE FROM registroasistencia WHERE idRegistro = " + id;
            Boolean result = dal.ModificacionBD(eliminacion, mySqlConnection, ref msj);

            return result;
        }
    }
}
