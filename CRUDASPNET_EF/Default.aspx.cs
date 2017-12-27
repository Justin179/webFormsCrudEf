using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDASPNET_EF
{
    public partial class Default : System.Web.UI.Page
    {
        private EntityFrameworkTestEntities entities = new EntityFrameworkTestEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                FillData();
        }

        private void FillData()
        {
            this.GridViewProduct.DataSource = entities.Account.Select(acc=>new
            {
                username = acc.username,
                fullname = acc.fullname,
                email = acc.email
            }).ToList();

            this.GridViewProduct.DataBind();
        }

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton) sender;
            HiddenField hd = (HiddenField) lb.FindControl("HiddenFieldUsername");
            Account acc = entities.Account.Single(ac=>ac.username.Equals(hd.Value));
            entities.Account.Remove(acc);
            entities.SaveChanges();
            FillData();
        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldUsername");
        }
    }
}