using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Shopping.BLL;

namespace Shopping.DAL
{
    public class CategoryDAL
    {
        DBManager objDB = new DBManager();
        public DataTable GetAllCategories()
        {
            return objDB.ExecuteDatatable("select * from category"); 
        }
        public void SaveCategory(CategoryBLL objBLL) 
        {
            objDB.ExecuteNoneQuery("insert into category(catname , catstatus ) values ('" + objBLL.catname + "' , '" + objBLL.catstatus + "')");
        }
        public void UpdateCategory(CategoryBLL objBLL)
        {
            objDB.ExecuteNoneQuery("update category set catname='" + objBLL.catname + "', catstatus='" + objBLL.catstatus + "' where catcode=" + objBLL.catcode + " ");
        }
        public void DeleteCategory(CategoryBLL objBLL)
        {
            objDB.ExecuteNoneQuery("DELETE FROM category WHERE catcode='" + objBLL.catcode + "'");
        }
        public bool IsCategoryExists(CategoryBLL objBLL)
        {
           return objDB.ExecuteScalar("if exists (select catname from category where catname='" + objBLL.catname + "') select 'True'");
        }

    }
}