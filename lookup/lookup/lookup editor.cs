using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lookup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DataSet ds = Connection.GetData("select *");
            DataSet ds = Connection.GetData("select Emp_Name,salary from mst_staff order by Emp_Name,Salary");
            lookUpEdit1.Properties.DataSource = ds.Tables[0];
            lookUpEdit1.Properties.DisplayMember = "Emp_Name";
            lookUpEdit1.Properties.ValueMember = "salary";

        }

        private void BTNCLICKME_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employee Name :"   +lookUpEdit1.Text.ToString()+   "\t Employee Salary : "    + lookUpEdit1.EditValue.ToString());
        }
    }
}
