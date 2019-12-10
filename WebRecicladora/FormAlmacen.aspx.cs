using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormAlmacen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ALMACEN_ID"] != null)
            {
                int almacenId = Convert.ToInt32(Session["ALMACEN_ID"].ToString());

                if (almacenId <= 0)
                    return;

                AlmacenIdHD.Value = almacenId.ToString();
                CargarDatos(almacenId);
            }
        }
    }

    private void CargarDatos(int almacenId)
    {
        Almacen obj = AlmacenBLL.GetAlmacenById(almacenId);

        if (obj == null)
            Response.Redirect("ListaAlmacen.aspx");

        DescripcionTextBox.Text = obj.Descripcion;
        CapacidadTextBox.Text = obj.CapacidadKG.ToString();
        DisponibleTextBox.Text = obj.RestanteKG.ToString();
        LastCapacidadKGHD.Value = obj.CapacidadKG.ToString();

        ProductosList.DataBind();
        ProductosList.SelectedValue = obj.ProductoId.ToString();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        decimal capacidadKG = 0;
        decimal restanteKG = 0;        
        try
        {
            capacidadKG = Convert.ToDecimal(CapacidadTextBox.Text.Trim());
            restanteKG = Convert.ToDecimal(DisponibleTextBox.Text.Trim());
        }
        catch 
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('error', 'El campo CapacidadKG solo acepta números.')", true);
            return;
        }

        Almacen obj = new Almacen()
        {
            Descripcion = DescripcionTextBox.Text.Trim(),
            CapacidadKG = capacidadKG,
            RestanteKG = restanteKG,
            ProductoId = string.IsNullOrEmpty(ProductosList.SelectedValue) ? 0 : Convert.ToInt32(ProductosList.SelectedValue)
        };

        try
        {
            if (string.IsNullOrEmpty(AlmacenIdHD.Value))
            {
                AlmacenBLL.InsertAlmacen(obj);
            }
            else
            {
                decimal lastCapacidadKG = Convert.ToDecimal(LastCapacidadKGHD.Value);
                obj.AlmacenId = Convert.ToInt32(AlmacenIdHD.Value);

                decimal usadosKG = lastCapacidadKG - restanteKG;

                if (capacidadKG <= usadosKG)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('warning', 'No puede registrar una capacidad menor al espacio ya ocupado.')", true);
                    return;
                }

                obj.RestanteKG = obj.CapacidadKG - usadosKG;
                
                AlmacenBLL.UpdateAlmacen(obj);
            }
        }
        catch (Exception q)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('error', 'Error al registrar Almacen.')", true);
        }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Registro Exitoso.')", true);
        ClearAlmacen();
        Response.Redirect("ListaAlmacen.aspx");
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaAlmacen.aspx");
    }

    private void ClearAlmacen()
    {
        DescripcionTextBox.Text = "";
        CapacidadTextBox.Text = "";        
        AlmacenIdHD.Value = string.Empty;
    }    

    protected void ProductosList_DataBound(object sender, EventArgs e)
    {
        ProductosList.Items.Insert(0, new ListItem("No Asignar", "0"));
    }
}