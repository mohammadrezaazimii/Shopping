using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Shopping.BLL;
using Shopping.DAL;
using System.IO;

namespace Shopping.UIL
{
    public partial class Product : System.Web.UI.Page
    {
        ProductBLL objBLL = new ProductBLL();
        ProductDAL objDAL = new ProductDAL();
        CategoryDAL objCatDAL = new CategoryDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
                getData();
                Reset();
                populateCategory();
            }
        }
        private void getData()
        {
            gridProduct.DataSource = objDAL.GetAllProducts("select * from product");
            gridProduct.DataBind();
        }
        private void Reset()
        {
            lblcode.Text = "Auto Code";
            txtname.Text = string.Empty;
            txtprice.Text = string.Empty;
            rbstatus.SelectedValue = "1";
            ddlCategory.SelectedIndex = 0;
            btnSave.Visible = true;
            btnUpdate.Visible = false;

        }
        private void FillBLL()
        {
            objBLL.procode = lblcode.Text;
            objBLL.proname = txtname.Text;
            objBLL.prostatus = rbstatus.SelectedValue;
            objBLL.procat = ddlCategory.SelectedValue;
            objBLL.proprice = txtprice.Text;
            objBLL.proimage = fileUpload.FileName;
        }
        private void populateCategory()
        {
            ddlCategory.DataSource = objCatDAL.GetAllCategories();
            ddlCategory.DataTextField = "catname";
            ddlCategory.DataValueField = "catname";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- select Category --", "0"));
            ddlCategory.SelectedIndex = 0;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void ShowMessage(string Msg)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('" + Msg + "')" , true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(ddlCategory.SelectedIndex == 0)
            {
                ShowMessage("Select a Category!");
            }
            else
            {
            UploadFile("ProductImage", fileUpload);
            FillBLL();
            objDAL.SaveProduct(objBLL);
            getData();
            Reset();
            }

        }



        private void UploadFile(string FolderName , FileUpload fu)
        {
            if (fu.HasFile)
            {
                string FolderPath = "ProductImage/";
                DirectoryInfo FolderDir = new DirectoryInfo(Server.MapPath(FolderPath));
                if (!FolderDir.Exists)
                {
                    FolderDir.Create();
                }
                string FilePath = Path.Combine(Server.MapPath(FolderPath), fu.FileName);
                if (!File.Exists(FilePath))
                {
                    fu.PostedFile.SaveAs(FilePath);
                }  
            }
        }
        private void DeleteFile()
        {
            string filepath = Server.MapPath(imgpath.Text);
            if (!File.Exists(filepath))
            {
            File.Delete(filepath);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex == 0)
            {
                ShowMessage("Select a Category!");
            }
            else
            {
                UploadFile("ProductImage", fileUpload);
                FillBLL();
                if (fileUpload.HasFile)
                {
                    DeleteFile();
                    objDAL.UpdateProduct(objBLL, true);
                }
                else
                {
                    objDAL.UpdateProduct(objBLL, false);
                }
                getData();
                Reset();
            }
        }
        private string GetText(string control, int index)
        {
            return ((Label)gridProduct.Rows[index].FindControl(control)).Text;
        }
        protected void gridProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int tmp=0;
            int index = e.NewEditIndex;
            lblcode.Text = GetText("lblcode", index);
            txtname.Text = GetText("lblname", index);
            string status = GetText("lblstatus", index);
            txtprice.Text = GetText("lblprice", index);
            string catname = GetText("lblcat", index);
            imgpath.Text = ((Image)gridProduct.Rows[index].FindControl("img")).ImageUrl;
            rbstatus.SelectedValue = "1";
            if (status == "False")
            {
                rbstatus.SelectedValue = "0";
            }
            for(int i=0; i<ddlCategory.Items.Count; i++)
            {
                if(ddlCategory.Items[i].Text == catname)
                {
                    tmp = i;
                }
            }
            ddlCategory.SelectedIndex = tmp;
            btnSave.Visible = false;
            btnUpdate.Visible = true;

        }

        protected void gridProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            objBLL.procode = GetText("lblcode", index);
            objDAL.DeleteProduct(objBLL);
            getData();
            Reset();


        }

      
    }
}