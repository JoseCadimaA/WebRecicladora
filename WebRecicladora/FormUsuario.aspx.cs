using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGuardarUsuario_Click(object sender, EventArgs e)
    {
        string userName = UserNameTextBox.Text.Trim();
        string contrasena = ContrasenaTextBox.Text.Trim();
        string nombreCompleto = NombreCompletoTextBox.Text.Trim();

        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(nombreCompleto))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('error', 'Debe rellenar todos los campos.')", true);
            return;
        }

        Usuario obj = new Usuario()
        {
            UserName = userName,
            contrasena = contrasena,
            NombreCompleto = nombreCompleto,
            EsAdmin = EsAdminCheckBox.Checked
        };

        if (string.IsNullOrEmpty(UsuarioIdHiddenField.Value))
        {
            UsuarioBLL.InsertUsuario(obj);
        } else
        {
            obj.UsuarioId = Convert.ToInt32(UsuarioIdHiddenField.Value);
            UsuarioBLL.UpdateUsuario(obj);
        }
        
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Registro Exitoso.')", true);
        CleanFormulario();
        PanelUsuario.Visible = false;

        GridUsuario.DataBind();
    }

    protected void GridUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int usuarioId = 0;
        try
        {
            usuarioId = Convert.ToInt32(e.CommandArgument);
        }
        catch (Exception ex)
        {

        }
        if (usuarioId <= 0)
            return;

        if (e.CommandName == "Eliminar")
        {
            try
            {
                UsuarioBLL.DeleteUsuario(usuarioId);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('success', 'Eliminación Exitosa.')", true);
                GridUsuario.DataBind();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error al eliminar");
            }
        }
        if (e.CommandName == "Editar")
        {
            Usuario obj = null;
            obj = UsuarioBLL.GetUsuarioById(usuarioId);
            if (obj == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowMensaje('error', 'Error al obtener información de usuario.')", true);
                return;
            }
            CleanFormulario();

            UserNameTextBox.Text = obj.UserName;
            NombreCompletoTextBox.Text = obj.NombreCompleto;
            EsAdminCheckBox.Checked = obj.EsAdmin;
            UsuarioIdHiddenField.Value = obj.UsuarioId.ToString();

            PanelUsuario.Visible = true;
        }
    }

    protected void btnAddUsuario_Click(object sender, EventArgs e)
    {
        CleanFormulario();
        PanelUsuario.Visible = true;
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        CleanFormulario();
        PanelUsuario.Visible = false;
    }

    private void CleanFormulario()
    {
        UserNameTextBox.Text = string.Empty;
        ContrasenaTextBox.Text = string.Empty;
        NombreCompletoTextBox.Text = string.Empty;
        EsAdminCheckBox.Checked = false;
        UsuarioIdHiddenField.Value = string.Empty;
    }
}