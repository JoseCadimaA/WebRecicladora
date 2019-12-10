using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MsgErrorLabel.Text = "";
            if (Session["CURRENT_USER"] != null)
            {
                Response.Redirect("MainPage.aspx");
            }
        }
        
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        string usernName = UserNameTextBox.Text.Trim();
        string contrasena = ContrasenaTextBox.Text.Trim();

        Usuario obj = UsuarioBLL.GetUsuarioByUserName(usernName, contrasena);

        if (obj == null)
        {            
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowErrorLogIn()", true);
            return;
        }


        Session["CURRENT_USER"] = obj.UsuarioId;

        Response.Redirect("MainPage.aspx");
    }
}