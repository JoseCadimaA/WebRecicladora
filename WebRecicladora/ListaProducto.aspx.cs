using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddNuevo_Click(object sender, EventArgs e)
    {
        Session["PRODUCTO_ID"] = null;
        Response.Redirect("FormProducto.aspx");
    }

    protected void GridProducto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int productoId = 0;
        try
        {
            productoId = Convert.ToInt32(e.CommandArgument);
        }
        catch (Exception ex)
        {

        }
        if (productoId <= 0)
            return;

        Producto obj = ProductoBLL.GetProductoById(productoId);
        if (obj == null)
            return;

        if (e.CommandName == "Eliminar")
        {
            try
            {
                ProductoBLL.DeleteProducto(productoId);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Eliminación Exitosa.')", true);

                GridProducto.DataBind();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error al eliminar");
            }
        }
        if (e.CommandName == "Editar")
        {
            Session["PRODUCTO_ID"] = productoId.ToString();
            Response.Redirect("FormProducto.aspx");
        }
    }
}