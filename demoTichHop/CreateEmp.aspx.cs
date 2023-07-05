using System;
using System.Collections.Generic;
using System.Drawing.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demoTichHop
{
    public partial class CreateEmp : System.Web.UI.Page
    {
        sqlserver_chung usesql = new sqlserver_chung();
        mysql_chung usemysql = new mysql_chung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlBenefit.DataSource = usesql.sqlsv_nhieuDong("Select * from Benefit_Plans");
                ddlBenefit.DataBind();
            }
        }

        private int insertSQlSerVer()
        {
            int sharehoder_status = 0;
            if (checkboxSS.Checked) sharehoder_status = 1;
            String query = "insert into Personal values ("+txtID.Text.Trim()+",N'"+txtFirstName.Text.Trim()+"',N'"+txtLastName.Text.Trim()+
                "','"+txtMiddle.Text.Trim()+"','"+txtAdr1.Text.Trim()+"','"+txtAdr2.Text.Trim()+"',N'"+txtCity.Text.Trim()+"','"+txtState.Text.Trim()+
                "',"+txtZip.Text.Trim()+",'"+txtEmail.Text.Trim()+"','"+txtPhone.Text.Trim()+"','"+txtSSN.Text.Trim()+"','"+txtDL.Text.Trim()+"','"+txtMS.Text.Trim()+
                "',"+ddlGender.SelectedValue+","+ sharehoder_status + ","+ddlBenefit.SelectedValue+",'"+txtEthnicity.Text.Trim()+"')";
            int rowCount = usesql.sqlsv_xuLy(query);
            return rowCount;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() != "" && txtFirstName.Text.Trim() != "" && txtLastName.Text.Trim() != "")
            {
                if (insertSQlSerVer() == 1)
                {
                    String query = "insert into `employee` (`idEmployee`,`Last_Name`,`First_Name`,`SSN`) values (" + txtID.Text.Trim() +
                        ",'" + txtLastName.Text.Trim() + "','" + txtFirstName.Text.Trim() + "',"+txtSSN.Text.Trim()+")";
                    int cout = usemysql.mysql_xuLy(query);
                    if (cout > 0)
                    {
                        lblThongBao.Text = "Insert Success";
                        lblThongBao.ForeColor = System.Drawing.Color.Red;
                    }
                    else lblThongBao.Text = "Insert Failure";
                }
            }
        }
    }
}