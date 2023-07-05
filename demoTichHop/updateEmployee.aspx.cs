using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demoTichHop
{
    public partial class updateEmployee : System.Web.UI.Page
    {
        sqlserver_chung usesql = new sqlserver_chung();
        mysql_chung usemysql = new mysql_chung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlBenefit.DataSource = usesql.sqlsv_nhieuDong("Select * from Benefit_Plans");
                ddlBenefit.DataBind();
                LoadForm();
            }
           
        }

        public void LoadForm()
        {
            String query = "select * from Personal where Employee_ID ="+ Request.QueryString["id"] + "";
            SqlDataReader reader = usesql.sqlsv_docNhieuDuLieu(query);
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    txtID.Text = reader.GetValue(0).ToString();
                    txtFirstName.Text = reader.GetString(1);
                    txtLastName.Text = reader.GetString(2);
                    txtMiddle.Text = reader.GetString(3);
                    txtAdr1.Text = reader.GetString(4);
                    txtAdr2.Text = reader.GetString(5);
                    txtCity.Text = reader.GetString(6);
                    txtState.Text = reader.GetString(7);
                    txtZip.Text = reader.GetValue(8).ToString();
                    txtEmail.Text = reader.GetString(9);
                    txtPhone.Text = reader.GetString(10);
                    txtSSN.Text = reader.GetString(11);
                    txtDL.Text = reader.GetString(12);
                    txtMS.Text = reader.GetString(13);

                    if (Convert.ToInt32(reader.GetValue(14)) == 1)
                        ddlGender.Text = "Male";
                    else
                        ddlGender.Text = "FeMale";

                    if (Convert.ToInt32(reader.GetValue(15)) == 1)
                        checkboxSS.Checked = true;
                    else
                        checkboxSS.Checked = false;
                    ddlBenefit.DataTextField = reader.GetValue(16).ToString();
                    txtEthnicity.Text = reader.GetString(17);
                }
            }
            txtID.Enabled = false;
        }

        private int updateSQL()
        {
            int check = 0;
            if (checkboxSS.Checked) check = 1;
            String query = "update Personal set " +
                "First_Name = '"+txtFirstName.Text.Trim()+"', Last_Name = '"+txtLastName.Text.Trim()+"', Middle_Initial = '"+txtMiddle.Text.Trim()+"', Address1 = '"+txtAdr1.Text.Trim()+"', Address2 = '"+txtAdr2.Text.Trim()+"', " +
                "City = '"+txtCity.Text.Trim()+"', State = '"+txtState.Text.Trim()+"',Zip = "+txtZip.Text.Trim()+", Email = '"+txtEmail.Text.Trim()+"', Phone_Number = '"+txtEmail.Text.Trim()+"', " +
                "Social_Security_Number = '"+txtSSN.Text.Trim()+"', Drivers_License = '"+txtDL.Text.Trim()+"', Marital_Status = '"+txtMS.Text.Trim()+"',Gender = "+ddlGender.SelectedValue+", " +
                "Shareholder_Status = "+check+", Benefit_Plans = "+ddlBenefit.SelectedValue+", Ethnicity = '"+txtEthnicity.Text.Trim()+"' where Employee_ID = "+txtID.Text.Trim()+"";
            int rowCout = usesql.sqlsv_xuLy(query);
            return rowCout;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim() != "" && txtLastName.Text.Trim() != "" && txtSSN.Text.Trim()!="")
            {
                if (updateSQL() == 1)
                {
                    String query = "UPDATE `payroll`.`employee` SET `Last_Name` = '"+txtLastName.Text.Trim()+"', `First_Name` = '"+txtFirstName.Text.Trim()+"', `SSN` = '"+txtSSN.Text.Trim()+"' WHERE (`idEmployee` = '"+txtID.Text.Trim()+"')";
                    int cout = usemysql.mysql_xuLy(query);
                    if (cout > 0) lblThongBao.Text = "Update Success";
                    else lblThongBao.Text = "Update Success";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("employeeProfile.aspx");
        }
    }
}