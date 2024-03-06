using ClassBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassEntidades;
using System.Configuration;
using System.Drawing;

namespace WebHorarios
{
    public partial class WebFormPeriodos : System.Web.UI.Page
    {
        BLPeriodos bLPeriodos = new BLPeriodos(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string msj = "";


                // Load the GridView with DataSet in the loadpage
                System.Data.DataSet dataSet = null;
                dataSet = bLPeriodos.MostrarPeriodos(ref msj);
                GridView1.DataSource = dataSet.Tables["periodos"];
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
            TextBox3.Text = "";
            TextBox4.Text = "";

            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }

        // RELOAR THE GRID VIEW IN ALL ACTIONS IN THE FORM
        public void ReloadGrid()
        {
            string msj = "";
            System.Data.DataSet dataSet = bLPeriodos.MostrarPeriodos(ref msj);
            GridView1.DataSource = dataSet.Tables["periodos"];
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Periodos periodo = new Periodos()
            {
                nombrePeriodo = TextBox1.Text,
                p_inicio = DateTime.Parse(TextBox2.Text),
                p_fin = DateTime.Parse(TextBox3.Text),
                anio = int.Parse(TextBox4.Text)
            };

            string msj = "";
            Boolean atrapa = bLPeriodos.RegistrarPeriodo(periodo, ref msj);

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


        // BUTON - MODIFY
        protected void Button2_Click(object sender, EventArgs e)
        {
            Periodos periodo = new Periodos()
            {
                idPeriodo = TextBox5.Text,
                nombrePeriodo = TextBox6.Text,
                p_inicio = DateTime.Parse(TextBox7.Text),
                p_fin = DateTime.Parse(TextBox8.Text),
                anio = int.Parse(TextBox9.Text)
            };

            string msj = "";
            Boolean atrapa = bLPeriodos.ModificarPeriodo(periodo, ref msj);

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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox5.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[2].Text);
            TextBox6.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[3].Text);
            TextBox7.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[4].Text);
            TextBox8.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[5].Text);
            TextBox9.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[6].Text);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow fila = GridView1.Rows[e.RowIndex];
            TextBox5.Text = fila.Cells[2].Text;

            LB.CssClass = "alert alert-info";
            LB.Text = "¿En verdad deseas eliminar el registro?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string msj = "";
            Boolean resultado = bLPeriodos.EliminarPeriodo(int.Parse(TextBox5.Text), ref msj);

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
    }
}