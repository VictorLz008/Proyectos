using ClassEntidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;

namespace ClassBL
{
    public class BLGrupos
    {
        DALhorario dal = null;

        public BLGrupos(string conex)
        {
            dal = new DALhorario(conex);
        }

        public List<Grupos> DRObtenGrupos(ref string msj)
        {
            // Open Conection
            MySqlConnection conex = dal.AbrirConexion(ref msj);
            List<Grupos> salida = new List<Grupos>();

            MySqlDataReader atrapa = null;
            atrapa = dal.ConsultaDR("SELECT * FROM grupos", conex, ref msj);

            if (atrapa != null)
            {
                // Query is correct, will be processed the DataRead

                while (atrapa.Read())
                {
                    salida.Add(new Grupos()
                    {
                        idGrupo = (int)atrapa[0],
                        nomGrupo = atrapa[1].ToString(),
                        cuatrimestre = (int)atrapa[2],
                        turno = atrapa[3].ToString()
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
    }
}
