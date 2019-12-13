using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaVentas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["FACTURA_ID_VEN"] = null;
    }

    protected void btnAddNuevo_Click(object sender, EventArgs e)
    {
        Session["FACTURA_ID_VEN"] = null;
        Response.Redirect("FormVenta.aspx");
    }

    protected void GridVenta_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int facturaId = 0;
        try
        {
            facturaId = Convert.ToInt32(e.CommandArgument);
        }
        catch (Exception ex)
        {

        }
        if (facturaId <= 0)
            return;

        if (e.CommandName == "Eliminar")
        {
            try
            {
                FacturaBLL.DeleteFactura(facturaId);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Eliminación Exitosa.')", true);

                GridVenta.DataBind();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error al eliminar");
            }
        }
        if (e.CommandName == "Ver")
        {
            Session["FACTURA_ID_VEN"] = facturaId.ToString();
            Response.Redirect("FormVenta.aspx");
        }
    }
}