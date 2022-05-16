using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Shopping.BLL;

namespace Shopping.DAL
{
    public class ProductDAL
    {
        DBManager objDb = new DBManager();
        public DataTable GetAllProducts(string query)
        {
            return objDb.ExecuteDatatable(query);
        }
        public void DeleteProduct(ProductBLL objBLL)
        {
            objDb.ExecuteNoneQuery("DELETE FROM product WHERE procode='" + objBLL.procode + "'");
        }
        public void SaveProduct(ProductBLL objBLL)
        {
            objDb.ExecuteNoneQuery("insert into product (proname, prostatus, procat , proprice , proimage) values('" + objBLL.proname + "' , '" + objBLL.prostatus + "' , '" + objBLL.procat + "' , '" + objBLL.proprice + "' , '" + objBLL.proimage + "')  ");
        }
        public void UpdateProduct(ProductBLL objBLL , bool UpdateImage)
        {
            if (UpdateImage)
            {
                objDb.ExecuteNoneQuery("update product set proname='" + objBLL.proname + "' , prostatus='" + objBLL.prostatus + "' , procat='" + objBLL.procat + "', proprice='" + objBLL.proprice + "' , proimage='" + objBLL.proimage + "' where procode=" + objBLL.procode + "  ");
            }
            else
            {
                objDb.ExecuteNoneQuery("update product set proname='" + objBLL.proname + "' , prostatus='" + objBLL.prostatus + "' , procat='" + objBLL.procat + "', proprice='" + objBLL.proprice + "' where procode=" + objBLL.procode + "  ");
            }

        }
    }
}