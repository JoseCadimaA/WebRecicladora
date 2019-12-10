using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaAlmacen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddNuevo_Click(object sender, EventArgs e)
    {
        Session["ALMACEN_ID"] = null;
        Response.Redirect("FormAlmacen.aspx");
    }

    protected void GridAlmacen_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int almacenId = 0;
        try
        {
            almacenId = Convert.ToInt32(e.CommandArgument);
        }
        catch (Exception ex)
        {

        }
        if (almacenId <= 0)
            return;

        Almacen obj = AlmacenBLL.GetAlmacenById(almacenId);
        if (obj == null)
            return;

        if (e.CommandName == "Eliminar")
        {
            try
            {
                AlmacenBLL.DeleteAlmacen(almacenId);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Eliminación Exitosa.')", true);

                GridAlmacen.DataBind();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error al eliminar");
            }
        }
        if (e.CommandName == "Editar")
        {
            Session["ALMACEN_ID"] = almacenId.ToString();
            Response.Redirect("FormAlmacen.aspx");
        }
    }
}