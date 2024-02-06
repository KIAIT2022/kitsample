    namespace Kit.AutoRun.Forms
{
    partial class ClickForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClickForm));
            this.grpMouse = new System.Windows.Forms.GroupBox();
            this.cmbClickType = new System.Windows.Forms.ComboBox();
            this.rdbNone = new System.Windows.Forms.RadioButton();
            this.rdbShift = new System.Windows.Forms.RadioButton();
            this.rdbAlt = new System.Windows.Forms.RadioButton();
            this.rdbCtrl = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlSize = new System.Windows.Forms.Panel();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.grpMouse.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMouse
            // 
            this.grpMouse.Controls.Add(this.cmbClickType);
            this.grpMouse.Controls.Add(this.rdbNone);
            this.grpMouse.Controls.Add(this.rdbShift);
            this.grpMouse.Controls.Add(this.rdbAlt);
            this.grpMouse.Controls.Add(this.rdbCtrl);
            this.grpMouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMouse.Location = new System.Drawing.Point(0, 0);
            this.grpMouse.Name = "grpMouse";
            this.grpMouse.Size = new System.Drawing.Size(284, 39);
            this.grpMouse.TabIndex = 7;
            this.grpMouse.TabStop = false;
            this.grpMouse.Text = "Special Key";
            // 
            // cmbClickType
            // 
            this.cmbClickType.FormattingEnabled = true;
            this.cmbClickType.Items.AddRange(new object[] {
            "Single",
            "Double"});
            this.cmbClickType.Location = new System.Drawing.Point(11, 15);
            this.cmbClickType.Name = "cmbClickType";
            this.cmbClickType.Size = new System.Drawing.Size(62, 21);
            this.cmbClickType.TabIndex = 15;
            // 
            // rdbNone
            // 
            this.rdbNone.AutoSize = true;
            this.rdbNone.Checked = true;
            this.rdbNone.Location = new System.Drawing.Point(229, 17);
            this.rdbNone.Name = "rdbNone";
            this.rdbNone.Size = new System.Drawing.Size(51, 17);
            this.rdbNone.TabIndex = 14;
            this.rdbNone.TabStop = true;
            this.rdbNone.Text = "None";
            this.rdbNone.UseVisualStyleBackColor = true;
            // 
            // rdbShift
            // 
            this.rdbShift.AutoSize = true;
            this.rdbShift.Location = new System.Drawing.Point(177, 17);
            this.rdbShift.Name = "rdbShift";
            this.rdbShift.Size = new System.Drawing.Size(46, 17);
            this.rdbShift.TabIndex = 13;
            this.rdbShift.Text = "Shift";
            this.rdbShift.UseVisualStyleBackColor = true;
            // 
            // rdbAlt
            // 
            this.rdbAlt.AutoSize = true;
            this.rdbAlt.Location = new System.Drawing.Point(134, 17);
            this.rdbAlt.Name = "rdbAlt";
            this.rdbAlt.Size = new System.Drawing.Size(37, 17);
            this.rdbAlt.TabIndex = 12;
            this.rdbAlt.Text = "Alt";
            this.rdbAlt.UseVisualStyleBackColor = true;
            // 
            // rdbCtrl
            // 
            this.rdbCtrl.AutoSize = true;
            this.rdbCtrl.Location = new System.Drawing.Point(88, 17);
            this.rdbCtrl.Name = "rdbCtrl";
            this.rdbCtrl.Size = new System.Drawing.Size(40, 17);
            this.rdbCtrl.TabIndex = 11;
            this.rdbCtrl.Text = "Ctrl";
            this.rdbCtrl.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(181, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Tag = "100";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(79, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 24);
            this.btnOk.TabIndex = 3;
            this.btnOk.Tag = "100";
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnOk);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 28);
            this.panel3.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblX);
            this.panel1.Controls.Add(this.lblY);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 74);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Delay:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(45, 12);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 6;
            this.lblX.Text = "X:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(45, 34);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 7;
            this.lblY.Text = "Y:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlSize);
            this.panel2.Controls.Add(this.numDelay);
            this.panel2.Controls.Add(this.numericUpDownX);
            this.panel2.Controls.Add(this.numericUpDownY);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(69, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 74);
            this.panel2.TabIndex = 12;
            // 
            // pnlSize
            // 
            this.pnlSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSize.Controls.Add(this.lblHeight);
            this.pnlSize.Controls.Add(this.lblWidth);
            this.pnlSize.Location = new System.Drawing.Point(83, 6);
            this.pnlSize.Name = "pnlSize";
            this.pnlSize.Size = new System.Drawing.Size(128, 68);
            this.pnlSize.TabIndex = 10;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.Location = new System.Drawing.Point(3, 29);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(11, 9);
            this.lblHeight.TabIndex = 13;
            this.lblHeight.Text = "...";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.Location = new System.Drawing.Point(49, 2);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(11, 9);
            this.lblWidth.TabIndex = 13;
            this.lblWidth.Text = "...";
            // 
            // numDelay
            // 
            this.numDelay.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Delay", true));
            this.numDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDelay.Location = new System.Drawing.Point(7, 53);
            this.numDelay.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.ReadOnly = true;
            this.numDelay.Size = new System.Drawing.Size(70, 20);
            this.numDelay.TabIndex = 9;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Kit.AutoRun.DataItem);
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(7, 9);
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownX.TabIndex = 5;
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(7, 31);
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownY.TabIndex = 5;
            // 
            // ClickForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.grpMouse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClickForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Mouse Click ";
            this.grpMouse.ResumeLayout(false);
            this.grpMouse.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlSize.ResumeLayout(false);
            this.pnlSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMouse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rdbNone;
        private System.Windows.Forms.RadioButton rdbShift;
        private System.Windows.Forms.RadioButton rdbAlt;
        private System.Windows.Forms.RadioButton rdbCtrl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Panel pnlSize;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.ComboBox cmbClickType;
    }
}