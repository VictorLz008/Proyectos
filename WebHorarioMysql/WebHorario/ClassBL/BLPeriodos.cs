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

        public Boolean RegistrarDocente(Periodos periodo, ref string msj)
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
            string insercion = "INSERT INTO docentes(Nombre, A_Paterno, A_Materno ) VALUES (@name, @ap, @am) ";

            // CALL THE MODIFY METHOD 
            result = dal.ModificacionSeguraBD(insercion, p, mySqlConnection, ref msj);

            return result;
        }

        public DataSet MostrarEspecialidades(ref string msj)
        {
            DataSet copia = new DataSet();
            MySqlConnection mySqlConnection = dal.AbrirConexion(ref msj);
            dal.ConsultaMultipleDS(copia, "SELECT * FROM periodos", mySqlConnection, "especialidad", ref msj);
            return copia;
        }
    }
}
