using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demoTichHop
{
    public class Hienthi
    {
        public String Employee_ID { get; set; }
        public String First_Name { get; set; }
        public String Last_Name { get; set; }
        public String Gender { get; set; }
        public String Shareholder_Status { get; set; }
        public String Department { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public String Pay_Rate { get; set; }
        public int Vacation_Days { get; set; }
        public int Paid_To_Date { get; set; }
        public Hienthi()
        {

        }
    }

    public partial class Home : System.Web.UI.Page
    {
        sqlserver_chung use = new sqlserver_chung();
        mysql_chung usemysql = new mysql_chung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String query = "select Personal.Employee_ID, First_Name , Last_Name , Gender , Shareholder_Status, Department,Start_Date,End_Date " +
                                    "from Personal join Job_History on Personal.Employee_ID = Job_History.Employee_ID";
                SqlDataReader reader = use.sqlsv_docNhieuDuLieu(query);
                List<Hienthi> lst = new List<Hienthi>();
                if (reader.HasRows)
                {        
                    while (reader.Read())
                    {
                        Hienthi ht = new Hienthi();
                        ht.Employee_ID = reader.GetValue(0).ToString();
                        ht.First_Name = reader.GetString(1);
                        ht.Last_Name = reader.GetString(2);

                        if (Convert.ToInt32(reader.GetValue(3)) == 1)
                            ht.Gender = "Male";
                        else
                            ht.Gender = "Female";
                        if (Convert.ToInt32(reader.GetValue(4)) == 1)
                            ht.Shareholder_Status = "is shareholder";
                        else
                            ht.Shareholder_Status = "non-sharehoder";
                        ht.Department = reader.GetString(5);
                        ht.Start_Date = Convert.ToDateTime(reader.GetValue(6));
                        ht.End_Date = Convert.ToDateTime(reader.GetValue(7));
                        String qr = "select Pay_Rate,Vacation_Days,Paid_To_Date from employee where idEmployee = " + ht.Employee_ID + "";
                        MySqlDataReader rd = usemysql.mysql_docNhieuDuLieu(qr);
                        while (rd.Read())
                        {
                            ht.Pay_Rate = rd.GetString(0);
                            ht.Vacation_Days = Convert.ToInt32(rd.GetValue(1));
                            ht.Paid_To_Date = Convert.ToInt32(rd.GetValue(2));
                        }
                       // ht.Vacation_Days = Convert.ToInt32(usemysql.mysql_docDuyNhat(qr));
                        lst.Add(ht);
                    }
                }
                GridView1.DataSource = lst;
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("employeeProfile.aspx");
        }
    }
}