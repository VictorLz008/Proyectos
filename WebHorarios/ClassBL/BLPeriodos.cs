using ClassDAL;
using ClassEntidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBL
{
    public class BLPeriodos
    {
        DALhorario dal = null;

        public BLPeriodos(string conex)
        {
            dal = new DALhorario(conex);
        }

        public Boolean RegistrarPeriodo(Periodos periodo, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("name", MySqlDbType.String, 150));
            p.Add(new MySqlParameter("start", MySqlDbType.Date, 150));
            p.Add(new MySqlParameter("end", MySqlDbType.Date, 150));
            p.Add(new MySqlParameter("year", MySqlDbType.Int64, 150));

            // FILL THE FIELDS
            p[0].Value = periodo.nombrePeriodo;
            p[1].Value = periodo.p_inicio;
            p[2].Value = periodo.p_fin;
            p[3].Value = periodo.anio;


            // INSERT
            string insercion = "INSERT INTO periodos(NombrePeriodo, P_inicio, P_Fin, Año ) VALUES (@name, @start, @end, @year) ";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(insercion, p, mySqlConnection, ref msj);

            return result;
        }

        public DataSet MostrarPeriodos(ref string msj)
        {
            DataSet copia = new DataSet();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            dal.ConsultaMultipleDS(copia, "SELECT idPeriodo, NombrePeriodo, DATE_FORMAT(P_inicio, '%d-%m-%Y') as 'Periodo Inicio', DATE_FORMAT(P_Fin, '%d-%m-%Y') as 'Periodo Fin', Año FROM periodos", mySqlConnection, "periodos", ref msj);
            return copia;
        }

        public Boolean ModificarPeriodo(Periodos periodo, ref string msj)
        {
            Boolean result = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);

            // CREATE THE FIELDS
            p.Add(new MySqlParameter("id", MySqlDbType.Int64));
            p.Add(new MySqlParameter("name", MySqlDbType.String, 150));
            p.Add(new MySqlParameter("start", MySqlDbType.Date, 150));
            p.Add(new MySqlParameter("end", MySqlDbType.Date, 150));
            p.Add(new MySqlParameter("year", MySqlDbType.Int64, 150));

            // FILL THE FIELDS
            p[0].Value = periodo.idPeriodo;
            p[1].Value = periodo.nombrePeriodo;
            p[2].Value = periodo.p_inicio;
            p[3].Value = periodo.p_fin;
            p[4].Value = periodo.anio;


            // INSERT
            string insercion = "UPDATE periodos SET NombrePeriodo = @name, P_inicio = @start, P_Fin = @end, Año = @year WHERE idPeriodo = @id;";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(insercion, p, mySqlConnection, ref msj);

            return result;
        }


        public Boolean EliminarPeriodo(int id, ref string msj)
        {

            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            string eliminacion = "DELETE FROM periodos WHERE idPeriodo = " + id;
            Boolean result = dal.ModificacionBD(eliminacion, mySqlConnection, ref msj);

            return result;
        }
    }
}
