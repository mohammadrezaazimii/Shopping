using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping.BLL;
using System.Data;
using Shopping.DAL;

namespace Shopping.UIL.Products
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        ProductDAL objDAL = new ProductDAL();
        CategoryDAL objCatDAL = new CategoryDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
                //GetCategory();
            }
        }
        private void GetData()
        {
            dlProduct.DataSource = objDAL.GetAllProducts("select * from product");
            dlProduct.DataBind();
        }

     
        //private void GetCategory()
        //{
        //    dlCategory.DataSource = objCatDAL.GetAllCategories();
        //    dlCategory.DataBind();
        //}
    }
}