using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormCompra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int clienteId = 0;
        if (!string.IsNullOrEmpty(ClienteList.SelectedValue))
        {
            clienteId = Convert.ToInt32(ClienteList.SelectedValue);
        }


        Factura obj = new Factura()
        {
            ClienteId = clienteId,
            UsuarioId = Convert.ToInt32(Session["CURRENT_USER"].ToString()),
            Descripcion = DescripcionTextBox.Text.Trim(), 
            EsVenta  = false
        };

        try
        {
            FacturaIdHD.Value = FacturaBLL.InsertFactura(obj).ToString();       
        }
        catch (Exception q)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('error', 'Error al registrar Factura.')", true);
            return;
        }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Factura registrada, añada productos.')", true);
        PanelBtnGuardar.Visible = false;
        PanelBtnTerminar.Visible = true;
        PanelDetalle.Visible = true;
        
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaCompras.aspx");
    }

    protected void ClienteList_DataBound(object sender, EventArgs e)
    {

    }

    private void ClearFactura()
    {
        ClienteList.SelectedIndex = 0;
        DescripcionTextBox.Text = "";
        SubTotalTextBox.Text = "0";
    }

    protected void btnTerminar_Click(object sender, EventArgs e)
    {
        Session["FACTURA_ID_COM"] = null;
        Response.Redirect("ListaCompras.aspx");
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        FacturaDetalleBLL.DeleteFacturaDetalle(Convert.ToInt32(FacturaIdHD.Value));
        Response.Redirect("ListaCompras.aspx");
    }

    protected void btnGuardarDetalle_Click(object sender, EventArgs e)
    {
        try
        {
            decimal monto = Convert.ToDecimal(PrecioTextBox.Text) * Convert.ToDecimal(PesoKGTextBox.Text);
            FacturaDetalle obj = new FacturaDetalle()
            {
                FacturaId = Convert.ToInt32(FacturaIdHD.Value),
                ProductoId = Convert.ToInt32(ProductosList.SelectedValue),
                Monto = monto, 
                PesoKG = Convert.ToDecimal(PesoKGTextBox.Text)
            };

            int detalle = FacturaDetalleBLL.InsertFacturaDetalle(obj);
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('error', 'Error al registrar Factura. Ingrese datos correctos')", true);
            return;
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Producto añadido.')", true);
        GridProducto.DataBind();
        ShowModalHD.Value = "false";
        ClearDetalle();
    }

    protected void ProductosList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int productoId = Convert.ToInt32(ProductosList.SelectedValue);
        if (productoId<= 0)
        {
            PrecioTextBox.Text = "0";
            return;
        }

        Producto obj = ProductoBLL.GetProductoById(productoId);

        PrecioTextBox.Text = obj.PrecioCompra.ToString();
    }

    protected void btnAddProducto_Click(object sender, EventArgs e)
    {
        ClearDetalle();
        ProductosList.DataBind();
        ShowModalHD.Value = "true";
    }

    protected void btnCancelarDetalle_Click(object sender, EventArgs e)
    {
        ClearDetalle();
        GridProducto.DataBind();
        ShowModalHD.Value = "false";
    }

    private void ClearDetalle()
    {
        ProductosList.SelectedIndex = 0;
        PrecioTextBox.Text = "0";
        PesoKGTextBox.Text = "0";
    }

    protected void ProductosList_DataBound(object sender, EventArgs e)
    {
        ProductosList.Items.Insert(0, new ListItem("Seleccionar producto", "0", false));
    }

    protected void GridProducto_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}