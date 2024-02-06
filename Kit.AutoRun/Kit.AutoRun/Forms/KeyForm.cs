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
    public partial class KeyForm : BaseForm
    {
        public override void InitData()
        {
            base.InitData();
            bindingSource.DataSource = ObjectItem;

            txtValue.Enabled = !ObjectItem.IsFunction;

            if (ObjectItem.Special == "")
                rdbNone.Checked = true;
            else if (ObjectItem.Special == "^")
                rdbCtrl.Checked = true;
            else if (ObjectItem.Special == "%")
                rdbAlt.Checked = true;
            else if (ObjectItem.Special == "+")
                rdbShift.Checked = true;

            txtValue.Focus();
        }

        public KeyForm()
        {
            InitializeComponent();            
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {            
            ObjectItem.Type = "Key";
            ObjectItem.Special = Analyst.GetSpecial(rdbNone.Checked, rdbCtrl.Checked, rdbAlt.Checked, rdbShift.Checked);
            ObjectItem.Value = txtValue.Text;
            ObjectItem.Delay = (int)numDelay.Value;
            ObjectItem.Code = Analyst.GetCode(ObjectItem.Special, ObjectItem.Value, ObjectItem.IsFunction);
            ObjectItem.Num = (int)numTime.Value;
        }
    }
}
