using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demoTichHop
{
    public partial class employeeProfile : System.Web.UI.Page
    {
        sqlserver_chung use = new sqlserver_chung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String query = "select * from Personal";
                GridView1.DataSource = use.sqlsv_docNhieuDuLieu(query);
                GridView1.DataBind();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEmp.aspx");
        }
    }
}