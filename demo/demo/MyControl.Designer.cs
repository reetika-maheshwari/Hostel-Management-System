
namespace demo
{
    partial class MyControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtbox
            // 
            this.txtbox.Location = new System.Drawing.Point(2, 2);
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(259, 20);
            this.txtbox.TabIndex = 0;
            this.txtbox.Enter += new System.EventHandler(this.txtbox_Enter);
            this.txtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbox_KeyDown_1);
            this.txtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbox_KeyPress);
            this.txtbox.Leave += new System.EventHandler(this.txtbox_Leave);
            this.txtbox.MouseLeave += new System.EventHandler(this.txtbox_MouseLeave);
            this.txtbox.MouseHover += new System.EventHandler(this.txtbox_MouseHover);
            this.txtbox.Validating += new System.ComponentModel.CancelEventHandler(this.txtbox_Validating);
            // 
            // MyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtbox);
            this.Name = "MyControl";
            this.Size = new System.Drawing.Size(287, 23);
            this.Load += new System.EventHandler(this.MyControl_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox;
    }
}
