namespace SysTrayTimeCard
{
    partial class SysTrayTimeCardDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysTrayTimeCardDialog));
            this.datePicker = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btn1h = new System.Windows.Forms.Button();
            this.btn30m = new System.Windows.Forms.Button();
            this.btn15m = new System.Windows.Forms.Button();
            this.btn15ms = new System.Windows.Forms.Button();
            this.btn30ms = new System.Windows.Forms.Button();
            this.btn1hs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(13, 13);
            this.datePicker.Name = "datePicker";
            this.datePicker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Spent: ";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(343, 23);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00:00";
            // 
            // btn1h
            // 
            this.btn1h.Location = new System.Drawing.Point(403, 18);
            this.btn1h.Name = "btn1h";
            this.btn1h.Size = new System.Drawing.Size(35, 23);
            this.btn1h.TabIndex = 3;
            this.btn1h.Tag = "60";
            this.btn1h.Text = "+1H";
            this.btn1h.UseVisualStyleBackColor = true;
            this.btn1h.Click += new System.EventHandler(this.addTime);
            // 
            // btn30m
            // 
            this.btn30m.Location = new System.Drawing.Point(444, 18);
            this.btn30m.Name = "btn30m";
            this.btn30m.Size = new System.Drawing.Size(42, 23);
            this.btn30m.TabIndex = 4;
            this.btn30m.Tag = "30";
            this.btn30m.Text = "+30m";
            this.btn30m.UseVisualStyleBackColor = true;
            this.btn30m.Click += new System.EventHandler(this.addTime);
            // 
            // btn15m
            // 
            this.btn15m.Location = new System.Drawing.Point(492, 18);
            this.btn15m.Name = "btn15m";
            this.btn15m.Size = new System.Drawing.Size(42, 23);
            this.btn15m.TabIndex = 5;
            this.btn15m.Tag = "15";
            this.btn15m.Text = "+15m";
            this.btn15m.UseVisualStyleBackColor = true;
            this.btn15m.Click += new System.EventHandler(this.addTime);
            // 
            // btn15ms
            // 
            this.btn15ms.Location = new System.Drawing.Point(492, 47);
            this.btn15ms.Name = "btn15ms";
            this.btn15ms.Size = new System.Drawing.Size(42, 23);
            this.btn15ms.TabIndex = 8;
            this.btn15ms.Tag = "-15";
            this.btn15ms.Text = "-15m";
            this.btn15ms.UseVisualStyleBackColor = true;
            this.btn15ms.Click += new System.EventHandler(this.addTime);
            // 
            // btn30ms
            // 
            this.btn30ms.Location = new System.Drawing.Point(444, 47);
            this.btn30ms.Name = "btn30ms";
            this.btn30ms.Size = new System.Drawing.Size(42, 23);
            this.btn30ms.TabIndex = 7;
            this.btn30ms.Tag = "-30";
            this.btn30ms.Text = "-30m";
            this.btn30ms.UseVisualStyleBackColor = true;
            this.btn30ms.Click += new System.EventHandler(this.addTime);
            // 
            // btn1hs
            // 
            this.btn1hs.Location = new System.Drawing.Point(403, 47);
            this.btn1hs.Name = "btn1hs";
            this.btn1hs.Size = new System.Drawing.Size(35, 23);
            this.btn1hs.TabIndex = 6;
            this.btn1hs.Tag = "-60";
            this.btn1hs.Text = "-1H";
            this.btn1hs.UseVisualStyleBackColor = true;
            this.btn1hs.Click += new System.EventHandler(this.addTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "What you spent time on:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(258, 84);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(276, 92);
            this.txtDesc.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(457, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(363, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SysTrayTimeCardDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 226);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn15ms);
            this.Controls.Add(this.btn30ms);
            this.Controls.Add(this.btn1hs);
            this.Controls.Add(this.btn15m);
            this.Controls.Add(this.btn30m);
            this.Controls.Add(this.btn1h);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SysTrayTimeCardDialog";
            this.ShowInTaskbar = false;
            this.Text = "SysTrayTimeCard";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar datePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btn1h;
        private System.Windows.Forms.Button btn30m;
        private System.Windows.Forms.Button btn15m;
        private System.Windows.Forms.Button btn15ms;
        private System.Windows.Forms.Button btn30ms;
        private System.Windows.Forms.Button btn1hs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}

