using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarClientes(0);
        }
    }

    private void CargarClientes(int tipo)
    {
        List<Cliente> theList = new List<Cliente>();
        VistaHD.Value = tipo.ToString();

        if (tipo == 1) // ES COMPRADOR
            theList = ClienteBLL.GetListaClientesCompradores();
        else if (tipo == 2) // ES VENDEDOR
            theList = ClienteBLL.GetListaClientesVendedores();
        else //MOSTRAR TODOS
            theList = ClienteBLL.GetListaClientesTodos();


        GridCliente.DataSource = theList;
        GridCliente.DataBind();

    }



    protected void GridCliente_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int clienteId = 0;
        try
        {
            clienteId = Convert.ToInt32(e.CommandArgument);
        }
        catch (Exception ex)
        {

        }
        if (clienteId <= 0)
            return;

        Cliente obj = ClienteBLL.GetClienteById(clienteId);
        if (obj == null)
            return;

        if (e.CommandName == "Eliminar")
        {
            try
            {
                ClienteBLL.DeleteCliente(clienteId);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Eliminación Exitosa.')", true);

                CargarClientes(Convert.ToInt32(VistaHD.Value));
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error al eliminar");
            }
        }
        if (e.CommandName == "Editar")
        {
            Session["CLIENTE_ID"] = clienteId.ToString();
            Response.Redirect("FormCliente.aspx");
        }        
    }

    protected void btnAddNuevo_Click(object sender, EventArgs e)
    {
        Session["CLIENTE_ID"] = null;
        Response.Redirect("FormCliente.aspx");
    }

    protected void btnCompradores_Click(object sender, EventArgs e)
    {
        CargarClientes(1);
    }

    protected void btnVendedores_Click(object sender, EventArgs e)
    {
        CargarClientes(2);
    }

    protected void btnTodos_Click(object sender, EventArgs e)
    {
        CargarClientes(0);
    }
}