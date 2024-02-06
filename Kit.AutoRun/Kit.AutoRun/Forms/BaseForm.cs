using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kit.AutoRun.Forms
{
    public partial class BaseForm : Form
    {
        public bool Saved { get; set; } = false;
        public bool IsNew { get; set; } = true;
        public bool HasChanged { get; set; } = false;
        public DataItem ObjectItem { get; set; }
        public string StringValue { get; set; }

        public BaseForm()
        {
            InitializeComponent();
        }

        public virtual void InitData()
        { }

        public ToolStripButton CreateButton(string strText, object strTag, object objImage, bool bEnable, EventHandler clickEvent)
        {
            if (objImage != null)
            {
                return CreateButton(strText, strTag, (Bitmap)objImage, bEnable, clickEvent, ToolStripItemDisplayStyle.Image);
            }
            else
            {
                return CreateButton(strText, strTag, null, bEnable, clickEvent, ToolStripItemDisplayStyle.Text);
            }

        }

        public ToolStripButton CreateButton(string strText, object strTag, Bitmap image, bool bEnable, EventHandler clickEvent, ToolStripItemDisplayStyle toolStripItemDisplayStyle)
        {

            ToolStripButton toolStripButton = new ToolStripButton();

            toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton.Name = string.Format("tsb{0}", strText);
            toolStripButton.Size = new System.Drawing.Size(23, 22);
            toolStripButton.Tag = strTag;
            toolStripButton.Text = strText;
            toolStripButton.Click += clickEvent;
            toolStripButton.Enabled = bEnable;

            if (image != null)
                toolStripButton.Image = image;

            return toolStripButton;
        }

        public ToolStripButton CreateButton(string strText, object strTag, Bitmap image, bool bEnable, EventHandler clickEvent, EventHandler enabledChangedEvent)
        {
            ToolStripButton toolStripButton = CreateButton(strText, strTag, image, bEnable, clickEvent);
            toolStripButton.EnabledChanged += enabledChangedEvent;
            return toolStripButton;
        }

        public ToolStripSeparator CreateSeparator(string strName)
        {
            ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
            toolStripSeparator.Name = strName;
            toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            return toolStripSeparator;
        }

        public ToolStripLabel CreateLabel(string strText)
        {
            ToolStripLabel toolStripLabel = new ToolStripLabel();
            toolStripLabel.Name = string.Format("lbl{0}", strText);
            toolStripLabel.Text = strText;
            toolStripLabel.Size = new System.Drawing.Size(6, 25);
            return toolStripLabel;
        }

        public ToolStripTextBox CreateTextBox(string strName, string strDefault, bool bEnable, EventHandler changeTextEvent)
        {
            ToolStripTextBox toolStripTextBox = new ToolStripTextBox();
            toolStripTextBox.Name = strName;
            toolStripTextBox.Text = strDefault;
            toolStripTextBox.Size = new System.Drawing.Size(50, 25);
            toolStripTextBox.Enabled = bEnable;
            toolStripTextBox.RightToLeft = RightToLeft.Yes;

            toolStripTextBox.TextChanged += changeTextEvent;
            return toolStripTextBox;
        }

        public ToolStripComboBox CreateComboBox(string strName, object objTag, object[] listOfObj, int iIndex, EventHandler eventHandler)
        {
            ToolStripComboBox toolStripComboBox = new ToolStripComboBox();
            toolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toolStripComboBox.Items.AddRange(listOfObj);
            toolStripComboBox.Tag = objTag;
            toolStripComboBox.Name = strName;
            toolStripComboBox.Size = new System.Drawing.Size(121, 39);

            if (iIndex <= listOfObj.Length - 1)
                toolStripComboBox.SelectedIndex = iIndex;

            toolStripComboBox.SelectedIndexChanged += eventHandler;
            RegistryData.Update(RegistryData.KIT_SET_SPECIAL_VALUE, toolStripComboBox.SelectedText);

            return toolStripComboBox;
        }

        public ToolStrip BuildToolStrip(string strText, int iSize)
        {
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Location = new System.Drawing.Point(0, 74);
            toolStrip.Name = string.Format("tss{0}", strText);
            toolStrip.Size = new System.Drawing.Size(1069, 25);
            toolStrip.TabIndex = 6;
            toolStrip.Text = strText;
            toolStrip.ImageScalingSize = new Size(iSize, iSize);
            return toolStrip;
        }

        public MenuStrip BuildMenuStrip(string strText, ToolStripItem[] listOfItem)
        {
            MenuStrip menuStrip = new MenuStrip();
            if (listOfItem != null)
                menuStrip.Items.AddRange(listOfItem);

            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = string.Format("men{0}", strText);
            menuStrip.Size = new System.Drawing.Size(1069, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = strText;
            return menuStrip;
        }

        public ToolStripMenuItem CreateToolStripMenuItem(string strText, object objTag, Bitmap bitmap, Keys shortKeys, EventHandler clickEvent, params ToolStripItem[] listOfItem)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = string.Format("tsi{0}", strText);
            toolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            toolStripMenuItem.Tag = objTag;
            toolStripMenuItem.Text = strText;
            toolStripMenuItem.ShortcutKeys = shortKeys;

            if (clickEvent != null)
                toolStripMenuItem.Click += clickEvent;

            if (bitmap != null)
                toolStripMenuItem.Image = bitmap;

            if (listOfItem != null)
                toolStripMenuItem.DropDownItems.AddRange(listOfItem);

            return toolStripMenuItem;
        }

    }
}
