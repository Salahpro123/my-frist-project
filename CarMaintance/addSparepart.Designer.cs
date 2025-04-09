namespace CarMaintance
{
    partial class addSparepart
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_addPart_number = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_addPart_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_addPart_payment = new System.Windows.Forms.TextBox();
            this.phototoPart = new System.Windows.Forms.Button();
            this.dateTimePickerPart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 50);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(131, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "اضافة قطعة جديدة";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_addPart_number);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_addPart_name);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_addPart_payment);
            this.panel2.Controls.Add(this.phototoPart);
            this.panel2.Controls.Add(this.dateTimePickerPart);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 325);
            this.panel2.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(73, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "اضافة القطعة";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(319, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "رقم القطعة";
            // 
            // txt_addPart_number
            // 
            this.txt_addPart_number.Location = new System.Drawing.Point(135, 43);
            this.txt_addPart_number.Name = "txt_addPart_number";
            this.txt_addPart_number.Size = new System.Drawing.Size(247, 20);
            this.txt_addPart_number.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(319, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "اسم القطعة";
            // 
            // txt_addPart_name
            // 
            this.txt_addPart_name.Location = new System.Drawing.Point(135, 101);
            this.txt_addPart_name.Name = "txt_addPart_name";
            this.txt_addPart_name.Size = new System.Drawing.Size(247, 20);
            this.txt_addPart_name.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "سعر القطعة";
            // 
            // txt_addPart_payment
            // 
            this.txt_addPart_payment.Location = new System.Drawing.Point(135, 161);
            this.txt_addPart_payment.Name = "txt_addPart_payment";
            this.txt_addPart_payment.Size = new System.Drawing.Size(247, 20);
            this.txt_addPart_payment.TabIndex = 7;
            // 
            // phototoPart
            // 
            this.phototoPart.Location = new System.Drawing.Point(12, 113);
            this.phototoPart.Name = "phototoPart";
            this.phototoPart.Size = new System.Drawing.Size(91, 41);
            this.phototoPart.TabIndex = 10;
            this.phototoPart.Text = "اختيار صورة";
            this.phototoPart.UseVisualStyleBackColor = true;
            this.phototoPart.Click += new System.EventHandler(this.phototoPart_Click);
            // 
            // dateTimePickerPart
            // 
            this.dateTimePickerPart.Location = new System.Drawing.Point(189, 243);
            this.dateTimePickerPart.Name = "dateTimePickerPart";
            this.dateTimePickerPart.Size = new System.Drawing.Size(193, 20);
            this.dateTimePickerPart.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(311, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "تاريخ الاضافة";
            // 
            // addSparepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 375);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "addSparepart";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قطع الغيار";
            this.Load += new System.EventHandler(this.addSparepart_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_addPart_number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_addPart_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_addPart_payment;
        private System.Windows.Forms.Button phototoPart;
        private System.Windows.Forms.DateTimePicker dateTimePickerPart;
        private System.Windows.Forms.Label label6;
    }
}