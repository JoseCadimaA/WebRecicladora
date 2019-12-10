using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            if (Session["CLIENTE_ID"] != null)
            {
                int clienteId = Convert.ToInt32(Session["CLIENTE_ID"].ToString());

                if (clienteId <= 0)
                    return;

                ClienteIdHD.Value = clienteId.ToString();
                CargarDatos(clienteId);
            }  
        }
    }
    
    private void CargarDatos(int clienteId)
    {        
        Cliente obj = ClienteBLL.GetClienteById(clienteId);

        if (obj == null)
            Response.Redirect("ListaCliente.aspx");

        CITextBox.Text = obj.CI;
        NombreCompletoTextBox.Text = obj.NombreCompleto;
        EsVendedorCheckBox.Checked = obj.EsVendedor;

    }    

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Cliente obj = new Cliente()
        {
            CI = CITextBox.Text.Trim(),
            NombreCompleto = NombreCompletoTextBox.Text.Trim(),
            EsVendedor = EsVendedorCheckBox.Checked
        };

        try
        {
            if (string.IsNullOrEmpty(ClienteIdHD.Value))
            {
                ClienteBLL.InsertCliente(obj);
            } else
            {
                obj.ClienteId = Convert.ToInt32(ClienteIdHD.Value);
                ClienteBLL.UpdateCliente(obj);
            }
        }
        catch (Exception q)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('error', 'Error al registrar Cliente.')", true);
        }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Registro Exitoso.')", true);
        ClearCliente();
        Response.Redirect("ListaCliente.aspx");
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaCliente.aspx");
    }

    private void ClearCliente()
    {
        CITextBox.Text = "";
        NombreCompletoTextBox.Text = "";
        EsVendedorCheckBox.Checked = false;
        ClienteIdHD.Value = string.Empty;
    }
}