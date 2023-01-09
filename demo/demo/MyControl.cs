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
    public partial class MyControl: UserControl
    {
        public enum TextInputType
        {
            String = 0,
            Numeric = 1,
            Email = 2,
            Phone = 3
        }
        private TextInputType m_textInputType = TextInputType.String;
        public delegate void InvalidKeyCaptureEvent();
        public event InvalidKeyCaptureEvent InvalidKeyCapture;

        public MyControl()
        {
            InitializeComponent();
        }
        private void MyControl_Load_1(object sender, EventArgs e)
        {
            txtbox.Width = 200;
            txtbox.Height = 50;
            txtbox.BorderStyle = BorderStyle.Fixed3D;
            txtbox.MaxLength = 0;

            txtbox.AcceptsReturn = true;
            txtbox.AcceptsTab = true;

        }
        private void txtbox_MouseHover(object sender, EventArgs e)
        {
            txtbox.BackColor = Color.Red;
        }

        private void txtbox_MouseLeave(object sender, EventArgs e)
        {
            txtbox.BackColor = Color.Cyan;
        }

        private void txtbox_Enter(object sender, EventArgs e)
        {
            txtbox.BackColor = Color.Cyan;
            if (txtbox.Text == "Enter your text here") ;
            {
                txtbox.Text = "";
                txtbox.ForeColor = Color.Black;
            }
        }

        private void txtbox_Leave(object sender, EventArgs e)
        {
            txtbox.BackColor = Color.Red;
            
            if (txtbox.Text == "")
            {
                txtbox.Text = "enter your text here";
                txtbox.ForeColor = Color.Silver;
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (m_textInputType == TextInputType.Numeric)
            {
                if (Char.IsDigit(ch) || ch == 8 || ch == '.')
                {
                    e.Handled = false;//allow
                }
                else
                {
                    e.Handled = true;//not allow
                    if (InvalidKeyCapture != null)
                    {
                        InvalidKeyCapture();
                    }
                }
            }
            else if (m_textInputType == TextInputType.Phone)
            {

                if (Char.IsDigit(ch) || ch == (Char)Keys.Back)
                {
                    e.Handled = false;//allow
                }
                else
                {
                    e.Handled = true;//not allow
                    if (InvalidKeyCapture != null)
                    {
                        InvalidKeyCapture();
                    }
                }



            }

        }
        

        public static bool IsValidEmail(String email)
        {
            if (email.Contains("@") &&
                email.Contains("."))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        [Browsable(true)]
        [DefaultValue(TextInputType.String)]
        public TextInputType InputType
        {
            get
            {
                return m_textInputType;
            }
            set
            {
                m_textInputType = value;
            }
        }

        private bool m_AllowBlank = true;
        [Browsable(true)]
        [DefaultValue(true)]
        public bool AllowBlank
        {
            get
            {
                return m_AllowBlank;
            }
            set
            {
                m_AllowBlank = value;
            }
        }

        private bool m_AllowNegative = true;
        [Browsable(true)]
        [DefaultValue(true)]
        public bool AllowNegative
        {
            get
            {
                return m_AllowNegative;
            }
            set
            {
                m_AllowNegative = value;
            }
        }
        public override string Text
        {
            get
            {
                return txtbox.Text;
            }

            set
            {
                txtbox.Text = value;
            }
        }


              

        private void txtbox_Validating(object sender, CancelEventArgs e)
        {
            if (AllowBlank == false && string.IsNullOrWhiteSpace(txtbox.Text))
            {
                MessageBox.Show("Blank value is not allowed");
                e.Cancel = true;
                return;
            }

            if (m_textInputType == TextInputType.Email)
            {
                if (IsValidEmail(txtbox.Text) == false)
                {
                    e.Cancel = true;
                }
            }
            else if (m_textInputType == TextInputType.Numeric)
            {
                if (AllowNegative == false)
                {
                    if (string.IsNullOrWhiteSpace(txtbox.Text) == false &&
                        Convert.ToDouble(txtbox.Text) < 0)
                    {
                        MessageBox.Show("Negative value is not allowed");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void txtbox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("Tab");
            }
        }
    }
}
