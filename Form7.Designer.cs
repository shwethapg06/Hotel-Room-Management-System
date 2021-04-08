namespace WindowsFormsApp6
{
    partial class Form7
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtreserveid = new System.Windows.Forms.TextBox();
            this.txtcustid = new System.Windows.Forms.TextBox();
            this.txtroomno = new System.Windows.Forms.TextBox();
            this.txtdatein = new System.Windows.Forms.TextBox();
            this.txtdateout = new System.Windows.Forms.TextBox();
            this.comboroomtype = new System.Windows.Forms.ComboBox();
            this.btninsert2 = new System.Windows.Forms.Button();
            this.btnedit2 = new System.Windows.Forms.Button();
            this.btndelete3 = new System.Windows.Forms.Button();
            this.backbtn = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnview = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reserve ID :";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-1, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(852, 48);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Manage Reservation";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Room Type :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Room No :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 241);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Date in :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 469);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Date out :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtreserveid
            // 
            this.txtreserveid.Location = new System.Drawing.Point(189, 86);
            this.txtreserveid.Name = "txtreserveid";
            this.txtreserveid.Size = new System.Drawing.Size(100, 26);
            this.txtreserveid.TabIndex = 8;
            // 
            // txtcustid
            // 
            this.txtcustid.Location = new System.Drawing.Point(190, 118);
            this.txtcustid.Name = "txtcustid";
            this.txtcustid.Size = new System.Drawing.Size(100, 26);
            this.txtcustid.TabIndex = 9;
            // 
            // txtroomno
            // 
            this.txtroomno.Location = new System.Drawing.Point(190, 198);
            this.txtroomno.Name = "txtroomno";
            this.txtroomno.Size = new System.Drawing.Size(100, 26);
            this.txtroomno.TabIndex = 10;
            // 
            // txtdatein
            // 
            this.txtdatein.Location = new System.Drawing.Point(190, 238);
            this.txtdatein.Name = "txtdatein";
            this.txtdatein.Size = new System.Drawing.Size(100, 26);
            this.txtdatein.TabIndex = 11;
            // 
            // txtdateout
            // 
            this.txtdateout.Location = new System.Drawing.Point(190, 277);
            this.txtdateout.Name = "txtdateout";
            this.txtdateout.Size = new System.Drawing.Size(100, 26);
            this.txtdateout.TabIndex = 12;
            this.txtdateout.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // comboroomtype
            // 
            this.comboroomtype.FormattingEnabled = true;
            this.comboroomtype.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Family",
            "Suite"});
            this.comboroomtype.Location = new System.Drawing.Point(189, 159);
            this.comboroomtype.Name = "comboroomtype";
            this.comboroomtype.Size = new System.Drawing.Size(121, 27);
            this.comboroomtype.TabIndex = 13;
            // 
            // btninsert2
            // 
            this.btninsert2.BackColor = System.Drawing.SystemColors.Highlight;
            this.btninsert2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninsert2.Location = new System.Drawing.Point(67, 373);
            this.btninsert2.Name = "btninsert2";
            this.btninsert2.Size = new System.Drawing.Size(75, 38);
            this.btninsert2.TabIndex = 14;
            this.btninsert2.Text = "Insert";
            this.btninsert2.UseVisualStyleBackColor = false;
            this.btninsert2.Click += new System.EventHandler(this.btninsert2_Click);
            // 
            // btnedit2
            // 
            this.btnedit2.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnedit2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit2.Location = new System.Drawing.Point(201, 374);
            this.btnedit2.Name = "btnedit2";
            this.btnedit2.Size = new System.Drawing.Size(75, 37);
            this.btnedit2.TabIndex = 15;
            this.btnedit2.Text = "Edit";
            this.btnedit2.UseVisualStyleBackColor = false;
            this.btnedit2.Click += new System.EventHandler(this.btnedit2_Click);
            // 
            // btndelete3
            // 
            this.btndelete3.BackColor = System.Drawing.SystemColors.Highlight;
            this.btndelete3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete3.Location = new System.Drawing.Point(326, 373);
            this.btndelete3.Name = "btndelete3";
            this.btndelete3.Size = new System.Drawing.Size(75, 38);
            this.btndelete3.TabIndex = 16;
            this.btndelete3.Text = "Delete";
            this.btndelete3.UseVisualStyleBackColor = false;
            this.btndelete3.Click += new System.EventHandler(this.btndelete3_Click);
            // 
            // backbtn
            // 
            this.backbtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.backbtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backbtn.Location = new System.Drawing.Point(326, 426);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(75, 29);
            this.backbtn.TabIndex = 17;
            this.backbtn.Text = "Back";
            this.backbtn.UseVisualStyleBackColor = false;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnsearch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.Location = new System.Drawing.Point(67, 426);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 29);
            this.btnsearch.TabIndex = 18;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnview
            // 
            this.btnview.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnview.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.Location = new System.Drawing.Point(201, 426);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(75, 29);
            this.btnview.TabIndex = 19;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = false;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(407, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 427);
            this.dataGridView1.TabIndex = 20;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(848, 473);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.backbtn);
            this.Controls.Add(this.btndelete3);
            this.Controls.Add(this.btnedit2);
            this.Controls.Add(this.btninsert2);
            this.Controls.Add(this.comboroomtype);
            this.Controls.Add(this.txtdateout);
            this.Controls.Add(this.txtdatein);
            this.Controls.Add(this.txtroomno);
            this.Controls.Add(this.txtcustid);
            this.Controls.Add(this.txtreserveid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Reservation";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtreserveid;
        private System.Windows.Forms.TextBox txtcustid;
        private System.Windows.Forms.TextBox txtroomno;
        private System.Windows.Forms.TextBox txtdatein;
        private System.Windows.Forms.TextBox txtdateout;
        private System.Windows.Forms.ComboBox comboroomtype;
        private System.Windows.Forms.Button btninsert2;
        private System.Windows.Forms.Button btnedit2;
        private System.Windows.Forms.Button btndelete3;
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}