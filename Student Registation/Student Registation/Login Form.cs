using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Registration
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("select  * from student_registration");
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var First_Name = txtFirstname.Text;
            var Last_Name = txtlastname.Text;
            var Full_Name = txtfullname.Text;
            var Gender = txtgender.Text;
            var City = txtcity.Text;
            var State = cmbstate.Text;
            var Pin_Code  = txtpincode.Text.ToString();
            var Mobile_No = txtmobileno.Text;
            var Email = txtemail.Text;
            var DOB = Convert.ToDateTime(txtdob.EditValue).ToString("dd-MM-yy");

            var F_Name = txtFname.Text;
            var M_Name = txtMname.Text;
            var Address = txtAddress.Text;
            var Course = cmbCourse.Text;

            if (string.IsNullOrEmpty(First_Name))
            {
                XtraMessageBox.Show("Enter your Firstname", "information");
                txtFirstname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Last_Name))
            {
                XtraMessageBox.Show("Enter your Lastname", "information");
                txtlastname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Full_Name))
            {
                XtraMessageBox.Show("Enter your Fullname", "information");
                txtfullname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Gender))
            {
                XtraMessageBox.Show("Enter your Gender", "information");
                txtgender.Focus();
                return;
            }
            if (string.IsNullOrEmpty(City))
            {
                XtraMessageBox.Show("Enter your City", "information");
                txtcity.Focus();
                return;
            }
            if (string.IsNullOrEmpty(State))
            {
                XtraMessageBox.Show("Enter your State", "information");
                cmbstate.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Pin_Code))
            {
                XtraMessageBox.Show("Enter your Pincode", "information");
                txtpincode.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Mobile_No))
            {
                XtraMessageBox.Show("Enter your Mobile No", "information");
                txtmobileno.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Email))
            {
                XtraMessageBox.Show("Enter your Email", "information");
                txtemail.Focus();
                return;
            }
            if (string.IsNullOrEmpty(DOB))
            {
                XtraMessageBox.Show("Enter your Dob", "information");
                txtdob.Focus();
                return;
            }
            
            if (string.IsNullOrEmpty(F_Name))
            {
                XtraMessageBox.Show("Enter your Father name", "information");
                txtFname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(M_Name))
            {
                XtraMessageBox.Show("Enter your Mother name", "information");
                txtMname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Address))
            {
                XtraMessageBox.Show("Enter your Address", "information");
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Course))
            {
                XtraMessageBox.Show("Enter your Course", "information");
                cmbCourse.Focus();
                return;
            }
            String error = Connection.SetData("Insert Into student_registration (First_Name, Last_Name, Full_Name, Gender, City, State, Pin_Code, Mobile_No, Email, DOB, F_Name, M_Name,Address,Course) Values " +
                   "('" + First_Name + "', '" + Last_Name + "', '" + Full_Name + "', '" + Gender + "', '" + City + "', '" + State + "', '" + Pin_Code + "', '" + Mobile_No + "' , '" + Email + "', '" + DOB + "' , '" + F_Name + "' , '" + M_Name + "','" + Address + "','" + Course + "')");
            if (error == "")
            {
                MessageBox.Show("Data Saved.", " Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Error in Saving : " + error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var First_Name = txtFirstname.Text;
            var Last_Name = txtlastname.Text;
            var Full_Name = txtfullname.Text;
            var Gender = txtgender.Text;
            var City = txtcity.Text;
            var State = cmbstate.Text;
            var Pin_Code = txtpincode.Text.ToString();
            var Mobile_No = txtmobileno.Text;
            var Email = txtemail.Text;
            var DOB = Convert.ToDateTime(txtdob.EditValue).ToString("dd-MM-yy");

            var F_Name = txtFname.Text;
            var M_Name = txtMname.Text;
            var Address = txtAddress.Text;
            var Course = cmbCourse.Text;


            string error = Connection.SetData("Update student_registration set First_Name ='" + First_Name + "', Last_Name =  '" + Last_Name + "', Full_Name = '" + Full_Name + "', Gender = '" + Gender + "', City='" + City + "', State='" + State + "', Pin_Code= '" + Pin_Code + "', Mobile_No='" + Mobile_No + "' , Email = '" + Email + "', DOB = '" + DOB + "' , F_Name = '" + F_Name + "',M_Name = '" + M_Name + "', Address = '" + Address + "', Course = '" + Course + "' ");


            if (error == "")
            {
                MessageBox.Show("Data Updation Successfully...");
                       }
            else
            {
                MessageBox.Show("Error in updating: " + error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstname.Clear();
            txtlastname.Clear();
            txtfullname.Clear();
            txtgender.Clear();
            txtcity.Clear();
            cmbstate.Clear();
            txtpincode.Clear();
            txtmobileno.Clear();
            txtemail.Clear();
            txtdob.Clear();
            cmbCourse.Clear();
            txtFname.Clear();
            txtMname.Clear();
            txtAddress.Clear();





        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataSet ds = Connection.GetData("Delete from student_registration where First_Name = '" + txtFirstname.Text + "' ");
                MessageBox.Show("Student Record Deleted...");
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from student_registration where First_Name like '" + txtFirstname.Text + "%' ");
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtFirstname.Text = ds.Tables[0].Rows[0][0].ToString();
                txtlastname.Text = ds.Tables[0].Rows[0][1].ToString();
                txtfullname.Text = ds.Tables[0].Rows[0][2].ToString();
                txtgender.Text = ds.Tables[0].Rows[0][3].ToString();
                txtcity.Text = ds.Tables[0].Rows[0][4].ToString();
                cmbstate.Text = ds.Tables[0].Rows[0][5].ToString();
                txtpincode.Text = ds.Tables[0].Rows[0][6].ToString();
                txtmobileno.Text = ds.Tables[0].Rows[0][7].ToString();
                txtemail.Text = ds.Tables[0].Rows[0][8].ToString();
           
                txtdob.Text = ds.Tables[0].Rows[0][9].ToString();
                cmbCourse.Text = ds.Tables[0].Rows[0][13].ToString();
                txtFname.Text = ds.Tables[0].Rows[0][10].ToString();
                txtMname.Text = ds.Tables[0].Rows[0][11].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0][12].ToString();

            }
            else
            {
                
                MessageBox.Show("No Record with this Name No Exists..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
    }

