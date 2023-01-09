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
    public partial class fulldetailform : Form
    {
        public fulldetailform()
        {
            InitializeComponent();
        }
        public void ClearAll()
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            dtdob.Text = "";
            txtfathername.Text = "";
            txtmothername.Text = "";
            txtaddress.Text = "";
            txtpincode.Text = "";
            cmbuniversity.Text = "";

        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            string FirstName = txtfirstname.Text;
            string LastName = txtlastname.Text;
            string DOB = Convert.ToDateTime(dtdob.Text).ToString("yyyy-MM-dd");
            string FatherName = txtfathername.Text;
            string MotherName = txtmothername.Text;
            string Address = txtaddress.Text;
            string Pincode = txtpincode.Text;
            string University = cmbuniversity.Text;


            string error = Connection.SetData("INSERT INTO application (First_Name,Last_Name,DOB,Father_Name,Mother_Name,Address,Pincode,University) Values ('" + FirstName + "', '" + LastName + "', '" + DOB + "','" + FatherName + "','" + MotherName + "','" + Address + "','" + Pincode + "','" + University + "') ");
            if (error == "")
            {
                MessageBox.Show("Data saved");
                ClearAll();
            }
            else
            {
                MessageBox.Show("Error in query :" + error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string First_Name = txtfirstname.Text;
            string Last_Name = txtlastname.Text;
            string DOB = Convert.ToDateTime(dtdob.Text).ToString("yyyy-MM-dd");
            string Father_Name = txtfathername.Text;
            string Mother_Name = txtmothername.Text;
            string Address = txtaddress.Text;
            string Pincode = txtpincode.Text;
            string University = cmbuniversity.Text;



            string error = Connection.SetData("update application set First_Name='" + First_Name + "',Last_Name='" + Last_Name + "',DOB='" + DOB + "',Father_Name='" + Father_Name + "',Mother_Name='" + Mother_Name + "',Address='" + Address + "',Pincode='" + Pincode + "',University='" + University + "' ");
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
            DataSet ds = Connection.GetData("select * from application where First_Name= '" + txtfirstname.Text + "'");

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtfirstname.Text = ds.Tables[0].Rows[0][1].ToString();
                txtlastname.Text = ds.Tables[0].Rows[0][2].ToString();
                dtdob.Text = ds.Tables[0].Rows[0][3].ToString();
                txtfathername.Text = ds.Tables[0].Rows[0][4].ToString();
                txtmothername.Text = ds.Tables[0].Rows[0][5].ToString();
                txtaddress.Text = ds.Tables[0].Rows[0][6].ToString();
                txtpincode.Text = ds.Tables[0].Rows[0][7].ToString();
                cmbuniversity.Text = ds.Tables[0].Rows[0][8].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure..??", "Conformation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                DataSet ds = Connection.GetData("Delete from application where First_Name = '" + txtfirstname.Text + "' ");
                MessageBox.Show("data delete succesfully");
                    ClearAll();
             }
               
         }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("select * from application ");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }


    }

