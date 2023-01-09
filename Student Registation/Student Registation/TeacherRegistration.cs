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
    public partial class TeacherRegistration : DevExpress.XtraEditors.XtraForm
    {
        public TeacherRegistration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TeacherRegistration_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("select  * from teacher_registration");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var First_Name = txtfirstname.Text;
            var Last_Name = txtlastname.Text;
            var Gender = cmbgender.Text;
            var address = txtaddress.Text;
            var City = txtcity.Text;
            var Pin_Code = txtpincode.Text.ToString();
            var State = cmbstate.Text;
            var Mobile_No = txtmobileno.Text;
            var Email = txtemail.Text;
            var DOB = Convert.ToDateTime(txtdob.EditValue).ToString("dd-MM-yy");
            var Subjects = cmbsubjects.Text;
            var Qualification = txtqualification.Text;
            

            if (string.IsNullOrEmpty(First_Name))
            {
                XtraMessageBox.Show("Enter your Firstname", "information");
                txtfirstname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Last_Name))
            {
                XtraMessageBox.Show("Enter your Lastname", "information");
                txtlastname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Gender))
            {
                XtraMessageBox.Show("Enter your Gender", "information");
                cmbgender.Focus();
                return;
            }
            if (string.IsNullOrEmpty(City))
            {
                XtraMessageBox.Show("Enter your City", "information");
                txtcity.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Pin_Code))
            {
                XtraMessageBox.Show("Enter your Pincode", "information");
                txtpincode.Focus();
                return;
            }
            if (string.IsNullOrEmpty(State))
            {
                XtraMessageBox.Show("Enter your State", "information");
                cmbstate.Focus();
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

            if (string.IsNullOrEmpty(Subjects))
            {
                XtraMessageBox.Show("Enter your Address", "information");
                cmbsubjects.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Qualification))
            {
                XtraMessageBox.Show("Enter your Course", "information");
                txtqualification.Focus();
                return;
            }
            String error = Connection.SetData("Insert Into teacher_registration (First_Name, Last_Name, Gender, Address, City, Pin_Code, State, Mobile_No, Email, DOB, Subjects, Qualification)" +
                " Values ('" + First_Name + "', '" + Last_Name + "', '" + Gender + "','" + address + "', '" + City + "', '" + Pin_Code + "', '" + State + "', '" + Mobile_No + "', '" + Email + "', '" + DOB + "', '" + Subjects + "', '" + Qualification + "')");
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

            var First_Name = txtfirstname.Text;
            var Last_Name = txtlastname.Text;
            var Gender = cmbgender.Text;
            var Address = txtaddress.Text;
            var City = txtcity.Text;
            var Pin_Code = txtpincode.Text.ToString();
            var State = cmbstate.Text;
            var Mobile_No = txtmobileno.Text;
            var Email = txtemail.Text;
            var DOB = Convert.ToDateTime(txtdob.EditValue).ToString("dd-MM-yy");
            var Subjects = cmbsubjects.Text;
            var Qualification = txtqualification.Text;

            string error = Connection.SetData("Update teacher_registration set First_Name ='" + First_Name + "', Last_Name =  '" + Last_Name + "', Gender = '" + Gender + "', Address = '" + Address + "', City='" + City + "',Pin_Code= '" + Pin_Code + "', State='" + State + "',  Mobile_No='" + Mobile_No + "' , Email = '" + Email + "', DOB = '" + DOB + "' , Subjects = '" + Subjects + "',Qualification = '" + Qualification + "' ");


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

            txtfirstname.Clear();
            txtlastname.Clear();
            cmbgender.Clear();
            txtaddress.Clear();
            txtcity.Clear();
            txtpincode.Clear();
            cmbstate.Clear();
            txtmobileno.Clear();
            txtemail.Clear();
            txtdob.Clear();
            cmbsubjects.Clear();
            txtqualification.Clear();
            }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataSet ds = Connection.GetData("Delete from teacher_registration where First_Name = '" + txtfirstname.Text + "' ");
                MessageBox.Show("Teacher Record Deleted...");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from teacher_registration where First_Name like '" + txtfirstname.Text + "%' ");
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtfirstname.Text = ds.Tables[0].Rows[0][0].ToString();
                txtlastname.Text = ds.Tables[0].Rows[0][1].ToString();
                cmbgender.Text = ds.Tables[0].Rows[0][2].ToString();
                txtaddress.Text = ds.Tables[0].Rows[0][3].ToString();
                txtcity.Text = ds.Tables[0].Rows[0][4].ToString();
                txtpincode.Text = ds.Tables[0].Rows[0][5].ToString();
                cmbstate.Text = ds.Tables[0].Rows[0][6].ToString();
                txtmobileno.Text = ds.Tables[0].Rows[0][7].ToString();
                txtemail.Text = ds.Tables[0].Rows[0][8].ToString();
                txtdob.Text = ds.Tables[0].Rows[0][9].ToString();
                cmbsubjects.Text = ds.Tables[0].Rows[0][10].ToString();
                txtqualification.Text = ds.Tables[0].Rows[0][11].ToString();
       
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
    
    
