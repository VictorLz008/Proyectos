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
    public partial class WebFormAsignacionCuatrimestral : System.Web.UI.Page
    {

        BLDocentes bLDocentes = new BLDocentes(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        BLGrupos bLGrupos = new BLGrupos(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        BLAsignaturas bLAsignaturas = new BLAsignaturas(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        BLAsignacionCuatrimestral bLAsignacionCuatrimestral = new BLAsignacionCuatrimestral(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create the List for the response BL
            List<Docentes> docente = null;
            List<Grupos> grupo = null;
            List<Asignaturas> asignatura = null;
            string msj = "";
            if (!IsPostBack)
            { // Loading the page for first time

                // Calling the Functions
                docente = bLDocentes.DRObtenDocentes(ref msj);
                grupo = bLGrupos.DRObtenGrupos(ref msj);
                asignatura = bLAsignaturas.DRObtenAsignaturas(ref msj);


                // Clear the dropdowns before put the info
                DropDownList1.Items.Clear();
                DropDownList2.Items.Clear();
                DropDownList3.Items.Clear();


                // Filling the Dropdowns
                if(grupo != null)
                {
                    foreach (Grupos g in grupo)
                    {
                        DropDownList1.Items.Add(new ListItem(g.nomGrupo + " " + g.cuatrimestre + " " + g.turno, g.idGrupo.ToString()));
                        DropDownList4.Items.Add(new ListItem(g.nomGrupo + " " + g.cuatrimestre + " " + g.turno, g.idGrupo.ToString()));

                    }
                }

                if (docente != null)
                {
                    foreach (Docentes d in docente)
                    {
                        DropDownList2.Items.Add(new ListItem(d.nombre + " " + d.AP+ " " + d.AM, d.idDocente.ToString()));
                        DropDownList5.Items.Add(new ListItem(d.nombre + " " + d.AP + " " + d.AM, d.idDocente.ToString()));

                    }
                }

                if (asignatura!= null)
                {
                    foreach (Asignaturas a in asignatura)
                    {
                        DropDownList3.Items.Add(new ListItem(a.NameAsignatura + " " + a.descripcion, a.IdAsignatura.ToString()));
                        DropDownList6.Items.Add(new ListItem(a.NameAsignatura + " " + a.descripcion, a.IdAsignatura.ToString()));
                    }
                }

                // Load the GridView with DataSet in the loadpage
                System.Data.DataSet dataSet = null;
                dataSet = bLAsignacionCuatrimestral.MostrarAsignacionCuatrimestral(ref msj);
                GridView1.DataSource = dataSet.Tables["asignacion"];
                GridView1.DataBind();


                // Save the DataSet if is diferent of null
                if (dataSet != null)
                {
                    Session["dataSet"] = dataSet;
                }
            }
        }


        // ==== UTILITIES ====

        // RELOAR THE GRID VIEW IN ALL ACTIONS IN THE FORM
        public void ReloadGrid()
        {
            string msj = "";
            System.Data.DataSet dataSet = bLAsignacionCuatrimestral.MostrarAsignacionCuatrimestral(ref msj);
            GridView1.DataSource = dataSet.Tables["asignacion"];
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[2].Text;
            DropDownList4.SelectedValue = GridView1.SelectedRow.Cells[3].Text;
            DropDownList5.SelectedValue = GridView1.SelectedRow.Cells[6].Text;
            DropDownList6.SelectedValue = GridView1.SelectedRow.Cells[9].Text;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow fila = GridView1.Rows[e.RowIndex];
            TextBox1.Text = fila.Cells[2].Text;

            LB.CssClass = "alert alert-info";
            LB.Text = "¿En verdad deseas eliminar el registro?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AsignacionCuatrimestral asig = new AsignacionCuatrimestral()
            {
                grupoID = int.Parse(DropDownList1.SelectedValue),
                docenteID = int.Parse(DropDownList2.SelectedValue),
                asignaturaID = int.Parse(DropDownList3.SelectedValue)
            };

            string msj = "";
            Boolean atrapa = bLAsignacionCuatrimestral.RegistrarAsignacionCuatrimestral(asig, ref msj);

            if (atrapa)
            {
                // Insert is correct
                TextBox0.BackColor = Color.Green;
                TextBox0.Text = msj;
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
            AsignacionCuatrimestral asig = new AsignacionCuatrimestral()
            {
                idAsignacion = int.Parse(TextBox1.Text),
                grupoID = int.Parse(DropDownList1.SelectedValue),
                docenteID = int.Parse(DropDownList2.SelectedValue),
                asignaturaID = int.Parse(DropDownList3.SelectedValue)
            };

            string msj = "";
            Boolean atrapa = bLAsignacionCuatrimestral.ModificarAsignacionCuatrimestral(asig, ref msj);

            if (atrapa)
            {
                // Insert is correct
                TextBox0.BackColor = Color.Green;
                TextBox0.Text = msj;
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
            Boolean resultado = bLAsignacionCuatrimestral.EliminarAsignacionCuatrimestral(int.Parse(TextBox1.Text), ref msj);

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