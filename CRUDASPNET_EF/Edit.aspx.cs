using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDASPNET_EF
{
    public partial class Edit : System.Web.UI.Page
    {
        private EntityFrameworkTestEntities entities = new EntityFrameworkTestEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string username = Request.QueryString["username"];
                Account acc = entities.Account.Single(ac => ac.username.Equals(username));
                this.LabelUsername.Text = acc.username;
                this.TextBoxFullName.Text = acc.fullname;
                this.TextBoxEmail.Text = acc.email;
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Account acc = entities.Account.Single(ac => ac.username.Equals(this.LabelUsername.Text));
                
                if (!String.IsNullOrEmpty(this.TextBoxPassword.Text))
                    acc.password = this.TextBoxPassword.Text;

                acc.fullname = this.TextBoxFullName.Text;
                acc.email = this.TextBoxEmail.Text;
                entities.SaveChanges();
                Response.Redirect("Default.aspx");
            }
            catch
            {

                this.LabelMessage.Text = "Can't edit this account";
            }
        }
    }
}