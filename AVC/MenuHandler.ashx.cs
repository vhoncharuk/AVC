using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;


namespace AVC
{
	/// <summary>
	/// Summary description for MenuHandler
	/// </summary>
	public class MenuHandler : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			List<Menu>  listMenu = new List<Menu>();
			using (SqlConnection con = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("spMenuBuilder", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Menu menu = new Menu();
					menu.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
					menu.CategoryName = rdr["CategoryName"].ToString();
					menu.SubCategory = rdr["SubCategory"] != DBNull.Value ? Convert.ToInt32(rdr["SubCategory"]) : (int?) null;
					listMenu.Add(menu);
				}
			}
			List<Menu> menuTree = GetMenuTree(listMenu,null);
			JavaScriptSerializer js = new JavaScriptSerializer();
			context.Response.Write(js.Serialize(menuTree));
		}

		private int count = 0;
		private List<Menu> GetMenuTree(List<Menu> list, int? subcategory)
		{
			return list.Where(x => x.SubCategory == subcategory).Select(x => new Menu()
				{
					CategoryId = x.CategoryId,
					CategoryName = x.CategoryName,
					SubCategory = x.SubCategory,
					List = GetMenuTree(list,x.CategoryId)
				}).ToList();
			
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}