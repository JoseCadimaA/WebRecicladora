using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            if (Session["CURRENT_USER"] != null)
            {
                int userId = Convert.ToInt32(Session["CURRENT_USER"].ToString());

                Usuario obj = UsuarioBLL.GetUsuarioById(userId);

                if (obj == null)
                {
                    Session["CURRENT_USER"] = null;
                    Response.Redirect("Login.aspx");
                } else
                {
                    NombreUsuarioLabel.InnerText = obj.NombreCompleto;
                }
            } else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["CURRENT_USER"] = null;
        Response.Redirect("Login.aspx");
    }
}
