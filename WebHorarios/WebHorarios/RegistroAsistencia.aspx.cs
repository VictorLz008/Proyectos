using ClassBL;
using ClassEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebHorarios
{
    public partial class RegistroAsistencia : System.Web.UI.Page
    {
        BLRegistroAsistencia con = new BLRegistroAsistencia(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string msj = "";


                // Load the GridView with DataSet in the loadpage
                System.Data.DataSet dataSet = null;
                dataSet = con.MostrarRegistroAsistencia(ref msj);
                GridView1.DataSource = dataSet.Tables["RegistroAsistencia"];
                GridView1.DataBind();


                // Save the DataSet if is diferent of null
                if (dataSet != null)
                {
                    Session["dataSet"] = dataSet;
                }
            }

            BLHora bLhora = null;
            List<Horario> hora = null;
            string msjs = "";
            if (!IsPostBack)
            {
                bLhora = new BLHora(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                hora = bLhora.DRObhora(ref msjs);

                DropDownList1.Items.Clear();
                DropDownList2.Items.Clear();

                if (hora != null)
                {
                    foreach (Horario c in hora)
                    {
                        DropDownList1.Items.Add(new ListItem(c.dia + " " + c.hfinal + " - " + c.hinicio + " Salon " + c.NomAula + " Materia "
                            + c.NomAsigantura + " Turno: " + c.Turno + " Profesor: " + c.profesor + " " + c.App, c.IdHorario.ToString()));
                        DropDownList2.Items.Add(new ListItem(c.dia + " " + c.hfinal + " - " + c.hinicio + " Salon " + c.NomAula + " Materia "
                            + c.NomAsigantura + " Turno: " + c.Turno + " Profesor: " + c.profesor + " " + c.App, c.IdHorario.ToString()));

                    }
                }
            }
        }

        public void ClearFields()
        {
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }

        public void ReloadGrid()
        {
            string msj = "";
            System.Data.DataSet dataSet = con.MostrarRegistroAsistencia(ref msj);
            GridView1.DataSource = dataSet.Tables["RegistroAsistencia"];
            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Registroasistencia rasistencia = new Registroasistencia()
            {
                Fecha = DateTime.Parse(TextBox1.Text).Date,
                HorarioId = int.Parse(DropDownList1.SelectedValue),
                Tema = TextBox3.Text,
                TotalAlumnos = int.Parse(TextBox8.Text),
                Observaciones = TextBox9.Text,
            };

            string msj = "";
            Boolean atrapa = con.RegistrarRegistroAsistencia(rasistencia, ref msj);

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Registroasistencia easistencia = new Registroasistencia()
            {
                IdRegistro = int.Parse(TextBox4.Text),
                Fecha = DateTime.Parse(TextBox2.Text).Date,
                HorarioId = int.Parse(DropDownList2.SelectedValue),
                Tema = TextBox5.Text,
                TotalAlumnos = int.Parse(TextBox6.Text),
                Observaciones = TextBox7.Text,
            };

            string msj = "";
            Boolean atrapa = con.ModificarRegistroAsistencia(easistencia, ref msj);

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

        protected void Button3_Click(object sender, EventArgs e)
        {
            string msj = "";
            Boolean resultado = con.EliminarRegistroasistencia(int.Parse(TextBox4.Text), ref msj);
            if (resultado)
            {
                TextBox0.Text = "Eliminación correcta";
                TextBox0.BackColor = Color.GreenYellow;
            }
            else
            {
                TextBox0.Text = "Error en la eliminación " + msj;
                TextBox0.BackColor = Color.Red;
            }

            ReloadGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox4.Text = GridView1.SelectedRow.Cells[2].Text;
            DropDownList2.SelectedValue = GridView1.SelectedRow.Cells[4].Text;
            TextBox4.BackColor = Color.GreenYellow;
            TextBox2.Text = GridView1.SelectedRow.Cells[3].Text;
            TextBox5.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[5].Text);
            TextBox6.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[6].Text);
            TextBox7.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[7].Text);

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow fila = GridView1.Rows[e.RowIndex];
            TextBox4.Text = fila.Cells[2].Text;
            LB.CssClass = "alert alert-info";
            LB.Text = "¿En verdad deseas eliminar el registro?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}