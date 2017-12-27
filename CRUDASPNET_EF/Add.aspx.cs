using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDASPNET_EF
{
    public partial class Add : System.Web.UI.Page
    {

        private EntityFrameworkTestEntities entities = new EntityFrameworkTestEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Account acc = new Account();
                acc.username = this.TextBoxUsername.Text;
                acc.password = this.TextBoxPassword.Text;
                acc.fullname = this.TextBoxFullName.Text;
                acc.email = this.TextBoxEmail.Text;
                entities.Account.Add(acc);
                entities.SaveChanges();
                Response.Redirect("Default.aspx");
            }
            catch
            {
                this.LabelMessage.Text = "can't add new account";
            }
        }
    }
}