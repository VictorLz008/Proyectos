using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassEntidades;
using ClassBL;
using System.Configuration;
using System.Drawing;

namespace WebHorario
{
    public partial class WebFormDocentes : System.Web.UI.Page
    {
        BLDocentes bLDocentes = new BLDocentes(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string msj = "";


                // Load the GridView with DataSet in the loadpage
                System.Data.DataSet dataSet = null;
                dataSet = bLDocentes.MostrarDocentes(ref msj);
                GridView1.DataSource = dataSet.Tables["especialidad"];
                GridView1.DataBind();


                // Save the DataSet if is diferent of null
                if (dataSet != null)
                {
                    Session["dataSet"] = dataSet;
                }
            }
        }

        // ==== UTILITIES ====

        // CLEAR THE FIELDS AFTER AN ACTION
        public void ClearFields()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        // RELOAR THE GRID VIEW IN ALL ACTIONS IN THE FORM
        public void ReloadGrid()
        {
            string msj = "";
            System.Data.DataSet dataSet = bLDocentes.MostrarDocentes(ref msj);
            GridView1.DataSource = dataSet.Tables["especialidad"];
            GridView1.DataBind();
        }

        // BUTTON - REGISTER A NEW TEACHER
        protected void Button1_Click(object sender, EventArgs e)
        {
            Docentes docente = new Docentes()
            {
                nombre = TextBox1.Text,
                AP = TextBox2.Text,
                AM = TextBox3.Text
            };

            string msj = "";
            Boolean atrapa = bLDocentes.RegistrarDocente(docente, ref msj);

            if (atrapa)
            {
                // Insert is correct
                TextBox0.BackColor = Color.Green;
                TextBox0.Text = msj;
                ClearFields();
            }
            else
            {
                // Something wrong
                TextBox0.BackColor = Color.Red;
                TextBox0.Text = "Error en la insercion " + msj;
            }
            ReloadGrid();
        }

        // BUTTON - MODIFY A TEACHER
        protected void Button2_Click(object sender, EventArgs e)
        {
            Docentes docente = new Docentes()
            {
                idDocente = int.Parse(TextBox4.Text),
                nombre = TextBox5.Text,
                AP = TextBox6.Text,
                AM = TextBox7.Text
            };

            string msj = "";
            Boolean atrapa = bLDocentes.ModificarDocente(docente, ref msj);

            if (atrapa)
            {
                // Insert is correct
                TextBox0.BackColor = Color.Green;
                TextBox0.Text = msj;
                ClearFields();
            }
            else
            {
                // Something wrong
                TextBox0.BackColor = Color.Red;
                TextBox0.Text = "Error en la insercion " + msj;
            }
            ReloadGrid();
        }


        // EVENT SELECTED IN GRIDVIEW TO SELECT A ROW
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox4.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox4.BackColor = Color.GreenYellow;
            TextBox5.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[3].Text);
            TextBox6.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[4].Text);
            TextBox6.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[5].Text);
        }
        // EVENT FOR BUTTON DELETE
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TextBox0.Text = "hola";
        }
    }
}