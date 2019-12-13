using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormVenta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["FACTURA_ID_VEN"] != null)
            {
                int facturaId = Convert.ToInt32(Session["FACTURA_ID_VEN"].ToString());
                if (facturaId > 0)
                {
                    CargarFactura(facturaId);
                    GridProducto.Columns[0].Visible = false;

                    btnAddProducto.Visible = false;
                    PanelBtnGuardar.Visible = false;
                    PanelBtnTerminar.Visible = false;
                    PanelDetalle.Visible = true;
                    DescripcionTextBox.Enabled = false;
                    ClienteList.Enabled = false;
                }
            }
        }

    }

    private void CargarFactura(int facturaId)
    {
        FacturaIdHD.Value = facturaId.ToString();

        ClienteList.DataBind();

        Factura obj = FacturaBLL.GetFacturaById(facturaId);
        DescripcionTextBox.Text = obj.Descripcion;
        SubTotalTextBox.Text = obj.SubTotal.ToString();
        ClienteList.SelectedValue = obj.ClienteId.ToString();        

        GridProducto.DataBind();
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
            EsVenta = true
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
        Response.Redirect("ListaVentas.aspx");
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
        Session["FACTURA_ID_VEN"] = null;
        Response.Redirect("ListaVentas.aspx");
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        FacturaBLL.DeleteFactura(Convert.ToInt32(FacturaIdHD.Value));
        Response.Redirect("ListaVentas.aspx");
    }

    protected void btnGuardarDetalle_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(AlmacenList.SelectedValue) || AlmacenList.SelectedValue == "0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('warning', 'Debe seleccionar una Almacén.')", true);
                return;
            }

            decimal monto = Convert.ToDecimal(PrecioTextBox.Text) * Convert.ToDecimal(PesoKGTextBox.Text);
            FacturaDetalle obj = new FacturaDetalle()
            {
                FacturaId = Convert.ToInt32(FacturaIdHD.Value),
                ProductoId = Convert.ToInt32(ProductosList.SelectedValue),
                Monto = monto,
                PesoKG = Convert.ToDecimal(PesoKGTextBox.Text),
                AlmacenId = Convert.ToInt32(AlmacenList.SelectedValue)
            };

            int detalleId = FacturaDetalleBLL.InsertFacturaDetalle(obj);

            if (detalleId <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('warning', 'La cantidad de KG ingresados no está disponible en el almacén.')", true);
                return;
            }
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
        CargarFactura(Convert.ToInt32(FacturaIdHD.Value));
    }

    protected void ProductosList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int productoId = Convert.ToInt32(ProductosList.SelectedValue);
        if (productoId <= 0)
        {
            PrecioTextBox.Text = "0";
            return;
        }

        Producto obj = ProductoBLL.GetProductoById(productoId);

        PrecioTextBox.Text = obj.PrecioVenta.ToString();
        ProductoIdHD.Value = productoId.ToString();
        AlmacenList.DataBind();
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
        int detalleID = 0;
        try
        {
            detalleID = Convert.ToInt32(e.CommandArgument);
        }
        catch (Exception ex)
        {

        }
        if (detalleID <= 0)
            return;


        if (e.CommandName == "Eliminar")
        {
            try
            {
                FacturaDetalleBLL.DeleteFacturaDetalle(detalleID);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Eliminación Exitosa.')", true);

                GridProducto.DataBind();
                CargarFactura(Convert.ToInt32(FacturaIdHD.Value));
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error al eliminar");
            }
        }
    }
}