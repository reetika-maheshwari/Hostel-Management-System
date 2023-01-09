using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ClearAll()
        {
            myControlname.Text = "";
            myControlemail.Text = "";
            myControlphoneno.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Name = myControlname.Text;
            string Email = myControlemail.Text;
            string Phone = myControlphoneno.Text;

            string error = Connection.SetData("INSERT INTO basicdetail (Name,Email,Phone_No) Values ('" + Name + "', '" + Email + "', '" + Phone + "') ");
            if (error == "")
            {
                MessageBox.Show("Data saved");
                ClearAll();
                fulldetailform frm = new fulldetailform();
                frm.Show();
             
            }
            else
            {
                MessageBox.Show("Error in query :" + error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Name = myControlname.Text;
            string Email = myControlemail.Text;
            string Phone = myControlphoneno.Text;

            string error = Connection.SetData("update basicdetail set Name='" + Name + "',Email='" + Email + "',Phone_No='" + Phone + "' ");
            if (error == "")
            {
                MessageBox.Show("data update successfully");
                ClearAll();
            }
            else
            {
                MessageBox.Show("error in message....." + error);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("select * from basicdetail where Phone_No= '" + myControlphoneno.Text + "'");

            if (ds.Tables[0].Rows.Count != 0)
            {
                myControlname.Text = ds.Tables[0].Rows[0][1].ToString();
                myControlemail.Text = ds.Tables[0].Rows[0][2].ToString();
                //myControlphoneno.Text = ds.Tables[0].Rows[0][4].ToString();
            }
            else
            {
                ClearAll();
                MessageBox.Show("No Record Exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }
        }
    }
}
        

    

