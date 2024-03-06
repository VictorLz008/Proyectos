using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBL;
using ClassEntidades;

namespace WebHorarios
{
    public partial class WebFormAsignaturas : System.Web.UI.Page
    {
        BLAsignaturas con = new BLAsignaturas(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string msj = "";


                // Load the GridView with DataSet in the loadpage
                System.Data.DataSet dataSet = null;
                dataSet = con.MostrarAsigantura(ref msj);
                GridView1.DataSource = dataSet.Tables["asignaturas"];
                GridView1.DataBind();


                // Save the DataSet if is diferent of null
                if (dataSet != null)
                {
                    Session["dataSet"] = dataSet;
                }
            }
        }

        public void ClearFields()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        public void ReloadGrid()
        {
            string msj = "";
            System.Data.DataSet dataSet = con.MostrarAsigantura(ref msj);
            GridView1.DataSource = dataSet.Tables["asignaturas"];
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Asignaturas asignaturas = new Asignaturas()
            {
                NameAsignatura = TextBox2.Text,
                HorasS = int.Parse(TextBox3.Text),
                cuatrimestre = int.Parse(TextBox4.Text),
                descripcion = TextBox5.Text
            };

            string msj = "";
            Boolean atrapa = con.RegistrarAsigantura(asignaturas, ref msj);

            if (atrapa)
            {
                // Insert is correct
                TextBox1.BackColor = Color.Green;
                TextBox1.Text = msj;
                ClearFields();
            }
            else
            {
                // Something wrong
                TextBox1.BackColor = Color.Red;
                TextBox1.Text = "Error en la insercion " + msj;
            }
            ReloadGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Asignaturas asignaturas = new Asignaturas()
            {
                IdAsignatura = int.Parse(TextBox6.Text),
                NameAsignatura = TextBox7.Text,
                HorasS = int.Parse(TextBox8.Text),
                cuatrimestre = int.Parse(TextBox9.Text),
                descripcion = TextBox10.Text
            };

            string msj = "";
            Boolean atrapa = con.ModificarAsignatura(asignaturas, ref msj);

            if (atrapa)
            {
                // Insert is correct
                TextBox1.BackColor = Color.Green;
                TextBox1.Text = msj;
                ClearFields();
            }
            else
            {
                // Something wrong
                TextBox1.BackColor = Color.Red;
                TextBox1.Text = "Error en la insercion " + msj;
            }
            ReloadGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox6.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox6.BackColor = Color.GreenYellow;
            TextBox7.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[3].Text);
            TextBox10.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[4].Text);
            TextBox8.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[5].Text);
            TextBox9.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[6].Text);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow fila = GridView1.Rows[e.RowIndex];
            TextBox6.Text = fila.Cells[2].Text;
            LB.CssClass = "alert alert-info";
            LB.Text = "¿En verdad deseas eliminar el registro?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string msj = "";
            Boolean resultado = con.EliminarAsignatura(int.Parse(TextBox6.Text), ref msj);
            if (resultado)
            {
                TextBox1.Text = "Eliminación correcta";
                TextBox1.BackColor = Color.GreenYellow;
            }
            else
            {
                TextBox1.Text = "Error en la eliminación " + msj;
                TextBox1.BackColor = Color.Red;
            }

            ReloadGrid();
        }
    }
}