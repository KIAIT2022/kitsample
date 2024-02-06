using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kit.AutoRun.Forms
{
    public partial class ClickForm : BaseForm
    {
        public override void InitData()
        {
            base.InitData();            
            bindingSource.DataSource = ObjectItem;

            //lblSize.Text = string.Format("Windows Size is: W = {0} and H = {1}.", Screen.PrimaryScreen.Bounds.Width.ToString(), Screen.PrimaryScreen.Bounds.Height.ToString());
            lblWidth.Text = Screen.PrimaryScreen.Bounds.Width.ToString();
            lblHeight.Text = Screen.PrimaryScreen.Bounds.Height.ToString();

            int iRate = 20;
            pnlSize.Location = new Point(83 + 64 - (Screen.PrimaryScreen.Bounds.Width / iRate) / 2, 6 + 34 - (Screen.PrimaryScreen.Bounds.Height / iRate) / 2);
            pnlSize.Size = new Size(Screen.PrimaryScreen.Bounds.Width/iRate, Screen.PrimaryScreen.Bounds.Height / iRate);

            numericUpDownX.Minimum = 0;
            numericUpDownX.Maximum = Screen.PrimaryScreen.Bounds.Width;
            numericUpDownY.Minimum = 0;
            numericUpDownY.Maximum = Screen.PrimaryScreen.Bounds.Height;
            if (ObjectItem.Special == "")
                rdbNone.Checked = true;
            else if (ObjectItem.Special == "^")
                rdbCtrl.Checked = true;
            else if (ObjectItem.Special == "%")
                rdbAlt.Checked = true;
            else if (ObjectItem.Special == "+")
                rdbShift.Checked = true;
            if (ObjectItem.Value != null)
            {
                string[] arrValue = ObjectItem.Value.Split(',');
                numericUpDownX.Value = int.Parse(arrValue[0]);
                numericUpDownY.Value = int.Parse(arrValue[1]);
            }
            numericUpDownX.Focus();

            cmbClickType.SelectedIndex = 0;
        }

        public ClickForm()
        {
            InitializeComponent();
            
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ObjectItem.Type = cmbClickType.SelectedItem.ToString();
            ObjectItem.Special = ObjectItem.Special = Analyst.GetSpecial(rdbNone.Checked, rdbCtrl.Checked, rdbAlt.Checked, rdbShift.Checked);
            ObjectItem.Value = string.Format("{0},{1}", numericUpDownX.Value, numericUpDownY.Value);
            ObjectItem.Delay = (int)numDelay.Value;
            ObjectItem.Code = ObjectItem.Value;
        }
    }
}
