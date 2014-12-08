using System;

namespace PersoLib
{
    public class BasePage : System.Web.UI.Page
    {
        private int? User
        {
            get
            {
                if (Session["ID_Usuario"] != null)
                {
                    return (int)Session["ID_Usuario"];
                }
                else
                    return null;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (User == null)
            {
                Response.Redirect("PaginaInicial.aspx");
            }
            base.OnLoad(e);
        }
    }
}