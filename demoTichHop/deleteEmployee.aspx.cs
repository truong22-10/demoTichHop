using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demoTichHop
{
    public partial class deleteEmployee : System.Web.UI.Page
    {
        sqlserver_chung usesql = new sqlserver_chung();
        mysql_chung usemysql = new mysql_chung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadform();
            }
        }

        public void loadform()
        {
            String query = "select * from Personal where Employee_ID =" + Request.QueryString["id"] + "";
            SqlDataReader reader = usesql.sqlsv_docNhieuDuLieu(query);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblID.Text = reader.GetValue(0).ToString();
                    lblFirst.Text = reader.GetString(1);
                    lblLast.Text = reader.GetString(2);
                    if (Convert.ToInt32(reader.GetValue(14)) == 1)
                        lblGender.Text = "Male";
                    else
                        lblGender.Text = "FeMale";
                    lblCity.Text = reader.GetString(6);
                    lblEmail.Text = reader.GetString(9);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String querysql = "delete from Personal where Employee_ID = "+Request.QueryString["id"]+"";
            int rowCout1 = usesql.sqlsv_xuLy(querysql);
            if (rowCout1 == 1)
            {
                String querymysql = "delete from `employee` where idEmployee = " + Request.QueryString["id"] + "";
                int rowCout2 = usemysql.mysql_xuLy(querymysql);
                if(rowCout2 == 1) lblThongBao.Text = "Delete Success";
                else lblThongBao.Text = "Delete Success";
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("employeeProfile.aspx");
        }
    }
}