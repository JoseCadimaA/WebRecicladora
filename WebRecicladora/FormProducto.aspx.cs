using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PRODUCTO_ID"] != null)
            {
                int productoID = Convert.ToInt32(Session["PRODUCTO_ID"].ToString());

                if (productoID <= 0)
                    return;

                ProductoIdHD.Value = productoID.ToString();
                CargarDatos(productoID);
            }
        }
    }

    private void CargarDatos(int productoID)
    {
        Producto obj = ProductoBLL.GetProductoById(productoID);

        if (obj == null)
            Response.Redirect("ListaProducto.aspx");

        DescripcionTextBox.Text = obj.Descripcion;
        PrecioCompraTextBox.Text = obj.PrecioCompra.ToString();
        PrecioVentaTextBox.Text = obj.PrecioVenta.ToString();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        decimal precioCompra = 0;
        decimal precioVenta = 0;
        try
        {
            precioCompra = Convert.ToDecimal(PrecioCompraTextBox.Text.Trim());
            precioVenta = Convert.ToDecimal(PrecioVentaTextBox.Text.Trim());
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('error', 'Los campos precio Compra y Venta solo acepta números.')", true);
            return;
        }

        Producto obj = new Producto()
        {
            Descripcion = DescripcionTextBox.Text.Trim(),
            PrecioCompra  = precioCompra, 
            PrecioVenta = precioVenta            
        };

        try
        {
            if (string.IsNullOrEmpty(ProductoIdHD.Value))
            {
                ProductoBLL.InsertProducto(obj);
            }
            else
            {
                obj.ProductoId = Convert.ToInt32(ProductoIdHD.Value);
                ProductoBLL.UpdateProducto(obj);
            }
        }
        catch (Exception q)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('error', 'Error al registrar Producto.')", true);
        }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Registro Exitoso.')", true);
        ClearProducto();
        Response.Redirect("ListaProducto.aspx");
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaProducto.aspx");
    }

    private void ClearProducto()
    {
        DescripcionTextBox.Text = "";
        PrecioCompraTextBox.Text = "";
        PrecioVentaTextBox.Text = "";
        ProductoIdHD.Value = string.Empty;
    }
}