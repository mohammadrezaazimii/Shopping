using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping.BLL;
using System.Data;
using Shopping.DAL;
using Shopping.UIL;


namespace Shopping.UIL
{
    public partial class Category : System.Web.UI.Page
    {
        CategoryBLL objBLL = new CategoryBLL();
        CategoryDAL objDAL = new CategoryDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
                Reset();
            }
        }
        private void GetData()
        {
            gridCategory.DataSource = objDAL.GetAllCategories();
            gridCategory.DataBind();

        }
        private void Reset()
        {
            lblCode.Text = "Auto Code";
            txtname.Text = string.Empty;
            rbstatus.SelectedValue = "1";
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
        private void FillBLL()
        {
            objBLL.catcode = lblCode.Text;
            objBLL.catname = txtname.Text;
            objBLL.catstatus = rbstatus.SelectedValue;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            FillBLL();
            if (objDAL.IsCategoryExists(objBLL))
            {
                showMessage("Category already exists!");

            }
            else
            {
                objDAL.SaveCategory(objBLL);
                GetData();
                Reset();
            }
        }
        private void showMessage(string Msg)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('"+Msg+"')", true);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            FillBLL();
            if ((objDAL.IsCategoryExists(objBLL)))
            {
                showMessage("Category already exists!");

            }
            else
            {
                objDAL.UpdateCategory(objBLL);
                GetData();
                Reset();
            }

        }
        private string GetText(string control , int index)
        {
            return ((Label)gridCategory.Rows[index].FindControl(control)).Text;
        }

        protected void gridCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int index = e.NewEditIndex;
            lblCode.Text = GetText("lblcode", index);
            txtname.Text = GetText("lblname", index);
            string status = GetText("lblstatus", index);
            rbstatus.SelectedValue = "1";
            if (status == "False")
            {
                rbstatus.SelectedValue = "0";

            }
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void gridCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            objBLL.catcode = GetText("lblcode", index);
            objDAL.DeleteCategory(objBLL);
            GetData();
            Reset();

        }
    }
}