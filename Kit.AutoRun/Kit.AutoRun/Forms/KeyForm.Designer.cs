namespace Kit.AutoRun.Forms
{
    partial class KeyForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.rdbCtrl = new System.Windows.Forms.RadioButton();
            this.rdbAlt = new System.Windows.Forms.RadioButton();
            this.rdbShift = new System.Windows.Forms.RadioButton();
            this.rdbNone = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpKey = new System.Windows.Forms.GroupBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.grpKey.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(79, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.Tag = "1000";
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // rdbCtrl
            // 
            this.rdbCtrl.AutoSize = true;
            this.rdbCtrl.Location = new System.Drawing.Point(82, 12);
            this.rdbCtrl.Name = "rdbCtrl";
            this.rdbCtrl.Size = new System.Drawing.Size(40, 17);
            this.rdbCtrl.TabIndex = 0;
            this.rdbCtrl.Text = "Ctrl";
            this.rdbCtrl.UseVisualStyleBackColor = true;
            // 
            // rdbAlt
            // 
            this.rdbAlt.AutoSize = true;
            this.rdbAlt.Location = new System.Drawing.Point(128, 12);
            this.rdbAlt.Name = "rdbAlt";
            this.rdbAlt.Size = new System.Drawing.Size(37, 17);
            this.rdbAlt.TabIndex = 1;
            this.rdbAlt.Text = "Alt";
            this.rdbAlt.UseVisualStyleBackColor = true;
            // 
            // rdbShift
            // 
            this.rdbShift.AutoSize = true;
            this.rdbShift.Location = new System.Drawing.Point(171, 12);
            this.rdbShift.Name = "rdbShift";
            this.rdbShift.Size = new System.Drawing.Size(46, 17);
            this.rdbShift.TabIndex = 2;
            this.rdbShift.Text = "Shift";
            this.rdbShift.UseVisualStyleBackColor = true;
            // 
            // rdbNone
            // 
            this.rdbNone.AutoSize = true;
            this.rdbNone.Checked = true;
            this.rdbNone.Location = new System.Drawing.Point(223, 12);
            this.rdbNone.Name = "rdbNone";
            this.rdbNone.Size = new System.Drawing.Size(51, 17);
            this.rdbNone.TabIndex = 3;
            this.rdbNone.TabStop = true;
            this.rdbNone.Text = "None";
            this.rdbNone.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Delay:";
            // 
            // numDelay
            // 
            this.numDelay.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Delay", true));
            this.numDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDelay.Location = new System.Drawing.Point(80, 37);
            this.numDelay.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.ReadOnly = true;
            this.numDelay.Size = new System.Drawing.Size(70, 20);
            this.numDelay.TabIndex = 2;
            this.numDelay.ThousandsSeparator = true;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Kit.AutoRun.DataItem);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(181, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Tag = "1000";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpKey
            // 
            this.grpKey.Controls.Add(this.rdbNone);
            this.grpKey.Controls.Add(this.rdbShift);
            this.grpKey.Controls.Add(this.rdbAlt);
            this.grpKey.Controls.Add(this.rdbCtrl);
            this.grpKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpKey.Location = new System.Drawing.Point(0, 0);
            this.grpKey.Name = "grpKey";
            this.grpKey.Size = new System.Drawing.Size(284, 39);
            this.grpKey.TabIndex = 200;
            this.grpKey.TabStop = false;
            this.grpKey.Text = "Special Key";
            // 
            // txtValue
            // 
            this.txtValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Value", true));
            this.txtValue.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(80, 6);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(196, 22);
            this.txtValue.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Value:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numTime);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.numDelay);
            this.panel1.Controls.Add(this.txtValue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 132);
            this.panel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(73, 132);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 32);
            this.panel2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Time:";
            // 
            // numTime
            // 
            this.numTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Num", true));
            this.numTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTime.Location = new System.Drawing.Point(80, 68);
            this.numTime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.ReadOnly = true;
            this.numTime.Size = new System.Drawing.Size(70, 20);
            this.numTime.TabIndex = 14;
            this.numTime.ThousandsSeparator = true;
            // 
            // KeyForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 171);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Key";
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.grpKey.ResumeLayout(false);
            this.grpKey.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rdbCtrl;
        private System.Windows.Forms.RadioButton rdbAlt;
        private System.Windows.Forms.RadioButton rdbShift;
        private System.Windows.Forms.RadioButton rdbNone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpKey;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.Label label1;
    }
}