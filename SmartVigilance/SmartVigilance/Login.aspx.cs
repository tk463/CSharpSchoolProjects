using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartVigilance
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WCFLib.Init();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            int IDUtilisateur = WCFLib.Login(TextBoxLogin.Text, TextBoxPassword.Text);

            if (IDUtilisateur >= 0)
            {
                Label1.Text = "Login successfull";

                Session["IDUtilisateur"] = IDUtilisateur;
                Response.Redirect("/Main.aspx");
            }
            else
            {
                Label1.Text = "Login failed";
            }
        }
    }
}