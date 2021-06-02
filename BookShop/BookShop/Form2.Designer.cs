using System.Drawing;
using System.Windows.Forms;

namespace BookShop
{
    partial class Form2
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CartBut = new System.Windows.Forms.Button();
            this.HomeBut = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LogoutBut = new System.Windows.Forms.Button();
            this.AdminBut = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(250, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 670);
            this.panel1.TabIndex = 1;
            // 
            // CartBut
            // 
            this.CartBut.BackColor = System.Drawing.Color.Navy;
            this.CartBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CartBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CartBut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CartBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CartBut.ForeColor = System.Drawing.Color.Aqua;
            this.CartBut.Image = ((System.Drawing.Image)(resources.GetObject("CartBut.Image")));
            this.CartBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CartBut.Location = new System.Drawing.Point(1100, 30);
            this.CartBut.Name = "CartBut";
            this.CartBut.Size = new System.Drawing.Size(252, 85);
            this.CartBut.TabIndex = 17;
            this.CartBut.Text = "       ตะกร้าของฉัน";
            this.CartBut.UseVisualStyleBackColor = false;
            this.CartBut.Click += new System.EventHandler(this.CartBut_Click);
            // 
            // HomeBut
            // 
            this.HomeBut.BackColor = System.Drawing.Color.Navy;
            this.HomeBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeBut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HomeBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.HomeBut.ForeColor = System.Drawing.Color.Aqua;
            this.HomeBut.Location = new System.Drawing.Point(20, 150);
            this.HomeBut.Name = "HomeBut";
            this.HomeBut.Size = new System.Drawing.Size(215, 82);
            this.HomeBut.TabIndex = 18;
            this.HomeBut.Text = "หน้าหลัก";
            this.HomeBut.UseVisualStyleBackColor = false;
            this.HomeBut.Click += new System.EventHandler(this.HomeBut_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // LogoutBut
            // 
            this.LogoutBut.BackColor = System.Drawing.Color.Navy;
            this.LogoutBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoutBut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogoutBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LogoutBut.ForeColor = System.Drawing.Color.Aqua;
            this.LogoutBut.Location = new System.Drawing.Point(20, 250);
            this.LogoutBut.Name = "LogoutBut";
            this.LogoutBut.Size = new System.Drawing.Size(215, 82);
            this.LogoutBut.TabIndex = 20;
            this.LogoutBut.Text = "ออกจากระบบ";
            this.LogoutBut.UseVisualStyleBackColor = false;
            this.LogoutBut.Click += new System.EventHandler(this.LogoutBut_Click);
            // 
            // AdminBut
            // 
            this.AdminBut.BackColor = System.Drawing.Color.Navy;
            this.AdminBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdminBut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AdminBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.AdminBut.ForeColor = System.Drawing.Color.Aqua;
            this.AdminBut.Location = new System.Drawing.Point(20, 350);
            this.AdminBut.Name = "AdminBut";
            this.AdminBut.Size = new System.Drawing.Size(215, 82);
            this.AdminBut.TabIndex = 22;
            this.AdminBut.Text = "แอดมิน";
            this.AdminBut.UseVisualStyleBackColor = false;
            this.AdminBut.Click += new System.EventHandler(this.AdminBut_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1375, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1500, 850);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.AdminBut);
            this.Controls.Add(this.LogoutBut);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HomeBut);
            this.Controls.Add(this.CartBut);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "มิคุบุ๊ค";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CartBut;
        private Button HomeBut;
        private PictureBox pictureBox1;
        private Button LogoutBut;
        private Button AdminBut;
        private PictureBox pictureBox2;
    }
}