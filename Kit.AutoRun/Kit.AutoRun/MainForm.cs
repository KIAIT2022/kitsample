using Kit.AutoRun.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kit.AutoRun
{
    public partial class MainForm : BaseForm
    {
        private string strDefaultName = "auto01.kit";
        private string strFileName = "";        

        private bool bWait = false;
        private bool bLoop = false;
        
        private const string SAVEIFLE = "Do you want to save this file?";

        private const string GROUP01 = "GROUP01"; //Function Key: Enter, Esc, Tab..
        private const string GROUP02 = "GROUP02"; //Special Key: Copy; Cut; Paste...
        private const string GROUP03 = "DOUBLE"; // More than 1 line data
        private const string GROUP04 = "MENU";
        private const string GROUP05 = "OPTIONSET";
        private const string GROUP06 = "OPTIONSIZE";
        private const string GROUP99 = "GROUP99"; //Loop: Begin, End
        private const string SEPERATECHAR = " ";

        private const string NEW_FILE = "NEW_FILE";
        private const string SAVE_FILE = "SAVE_FILE";
        private const string OPEN_FILE = "OPEN_FILE";

        private const string ADD_KEY = GROUP02 + "1";
        private const string ADD_MOUSE = "2";
        private const string EDIT_RECORD = "11112";
        private const string DELETE_RECORD = "3";
        private const string RUN_KEY = "555";
        private const string MOVE_UP = "999";
        private const string MOVE_DOWN = "888";

        private const string OPTION_SEND = "OPTION_SEND";
        private const string OPTION_WAIT = "OPTION_WAIT";

        private const string BEGIN_LOOP = "Begin";
        private const string END_LOOP = "End";

        private const string INCREASE_DELAY = "INCREASE_DELAY" + SEPERATECHAR + "100";
        private const string DECREASE_DELAY = "DECREASE_DELAY" + SEPERATECHAR + "-100";        

        private const string INCREASE_TIME = "INCREASE_TIME" + SEPERATECHAR + "1";
        private const string DECREASE_TIME = "DECREASE_TIME" + SEPERATECHAR + "-1";

        private const string COPY_KEY = GROUP02 + SEPERATECHAR + "^{INS}";
        private const string CUT_KEY = GROUP02 + SEPERATECHAR + "+{DEL}";
        private const string PASTE_KEY = GROUP02 +SEPERATECHAR + "+{INS}";
        private const string TITLE_KEY = GROUP02 + SEPERATECHAR + "Title";
        private const string SELECTALL_KEY = GROUP02 + SEPERATECHAR + "{END}" + SEPERATECHAR + "+{HOME}";

        private const string ICON_SET_01 = GROUP05 + SEPERATECHAR + "_1";
        private const string ICON_SET_02 = GROUP05 + SEPERATECHAR + "_2";
        private const string ICON_SET_03 = GROUP05 + SEPERATECHAR + "_3";

        private const string ICON_SIZE_16 = GROUP06 + SEPERATECHAR + "16";
        private const string ICON_SIZE_24 = GROUP06 + SEPERATECHAR + "24";
        private const string ICON_SIZE_32 = GROUP06 + SEPERATECHAR + "32";

        private const string SPECIAL_KEY = "²";

        private int iDelay = 0, iIndex = 0, iIconSize = 24, numOfTime = 1;
        string strSetIcon = "_1";
        private string strSpecial = "";
        private Hashtable buttonTable;
        private Hashtable menuTable;
        private int iItemCount = 0;

        private const string DELAY = "DELAY";
        private const string TIME = "TIME";

        private Color KeyColor { get; set; } = Color.Black;
        private Color ClickColor { get; set; } = Color.Red;
        private Color FunctionColor { get; set; } = Color.Orange;
            
        private DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();

        public MainForm()
        {
            InitializeComponent();

            iDelay = int.Parse(RegistryData.Select(RegistryData.KIT_SET_DELAY, 100).ToString());
            iIndex = int.Parse(RegistryData.Select(RegistryData.KIT_SET_FUNCTION_INDEX, 0).ToString());
            iIconSize = int.Parse(RegistryData.Select(RegistryData.KIT_ICON_SIZE, 24).ToString());
            strSetIcon = RegistryData.Select(RegistryData.KIT_SET_ICON, "_1").ToString();
            bWait = (RegistryData.Select(RegistryData.KIT_OPTIOPN_SEND, "1").ToString() == "1");
            strSpecial = RegistryData.Select(RegistryData.KIT_SET_SPECIAL_VALUE, "").ToString();

            InitButton();
            InitData();

            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.BindingSource_ListChanged);
        }
         
        private Bitmap GetBitmap(string strName)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Properties.Resources.ResourceManager.GetType();
            object objBitmap = Properties.Resources.ResourceManager.GetObject(strName, Properties.Resources.Culture);
            if (objBitmap != null)
                return (Bitmap)objBitmap;
            return null;
        }

        private ToolStrip GetToolStrip(string strGroup, string strName, int iSize)
        {
            if (!buttonTable.ContainsKey(strGroup))
            {
                ToolStrip toolStrip = BuildToolStrip(strName, iSize);
                buttonTable[strGroup] = toolStrip;                
            }
            return (ToolStrip)buttonTable[strGroup];
        }

        private ToolStripMenuItem GetMenuItem(string strGroup, string strName)
        {
            if (!menuTable.ContainsKey(strGroup))
            {
                ToolStripMenuItem toolStrip = CreateToolStripMenuItem(strName.Substring(1),"", null, Keys.Alt | Keys.F,  null);
                menuTable[strGroup] = toolStrip;
            }
            return (ToolStripMenuItem)menuTable[strGroup];
        }
        
        //Create Menu & Toolstrip
        private void InitButton()
        {
            strSetIcon = RegistryData.Select(RegistryData.KIT_SET_ICON, "_1").ToString();
            iIndex = (int)RegistryData.Select(RegistryData.KIT_SET_FUNCTION_INDEX, 0);            
            iIconSize = (int)RegistryData.Select(RegistryData.KIT_ICON_SIZE, 24); 

            //Set Notification
            notifyIcon1.Icon = global::Kit.AutoRun.Properties.Resources.Start;

            buttonTable = new Hashtable();
            menuTable = new Hashtable();

            //Create Buttons
            List<KitMenuItem> listOfItem = new List<KitMenuItem>
            {
                new KitMenuItem() { Group = "2", Type = 1, Name = "Key", Tag = ADD_KEY, Objects = null },
                new KitMenuItem() { Group = "2", Type = 1, Name = "Mouse", Tag = ADD_MOUSE, Objects = null },
                new KitMenuItem() { Group = "2", Type = 2, Name = "Sep1", Tag = "", Objects = null },
                new KitMenuItem() { Group = "2", Type = 1, Name = "MoveUp", Tag = MOVE_UP, Objects = null, Enable = false, Connector = 200 },
                new KitMenuItem() { Group = "2", Type = 1, Name = "MoveDown", Tag = MOVE_DOWN, Objects = null, Enable = false, Connector = 200 },
                new KitMenuItem() { Group = "2", Type = 2, Name = "Sep21", Tag = "", Objects = null },
                new KitMenuItem() { Group = "2", Type = 1, Name = "Run", Tag = RUN_KEY, Objects = null },

                new KitMenuItem() { Group = "2", Type = 2, Name = "Sep21", Tag = "", Objects = null },
                new KitMenuItem() { Group = "2", Type = 3, Name = "Delay (ms): ", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "2", Type = 4, Name = DELAY, Tag = iDelay.ToString(), Objects = null, Enable = false },
                new KitMenuItem() { Group = "2", Type = 1, Name = "Increase", Tag = INCREASE_DELAY, Objects = null, Connector = 100 },
                new KitMenuItem() { Group = "2", Type = 1, Name = "Decrease", Tag = DECREASE_DELAY, Objects = null, Connector = 100 },

                new KitMenuItem() { Group = "2", Type = 2, Name = "Sep21", Tag = "", Objects = null },
                new KitMenuItem() { Group = "2", Type = 3, Name = "Time : ", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "2", Type = 4, Name = TIME, Tag = numOfTime.ToString(), Objects = null, Enable = false },
                new KitMenuItem() { Group = "2", Type = 1, Name = "IncreaseTime", Tag = INCREASE_TIME, Objects = null, Connector = 999 },
                new KitMenuItem() { Group = "2", Type = 1, Name = "DecreaseTime", Tag = DECREASE_TIME, Objects = null, Connector = 999 },

                new KitMenuItem() { Group = "2", Type = 2, Name = "Sep23", Tag = "", Objects = null },
                new KitMenuItem() { Group = "2", Type = 3, Name = "Special Key: ", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "2", Type = 5, Name = "SpecialKey", Tag = "SpecialKey", Objects = new object[] { "None", "Ctrl(^)", "Alt(%)", "Shift(+)" } },
                new KitMenuItem() { Group = "2", Type = 1, Name = "Title", Tag = TITLE_KEY, Objects = null },

                new KitMenuItem() { Group = "2", Type = 2, Name = "Sep22", Tag = "", Objects = null },
                new KitMenuItem() { Group = "2", Type = 1, Name = "Copy", Tag = COPY_KEY, Objects = null },
                new KitMenuItem() { Group = "2", Type = 1, Name = "Cut", Tag = CUT_KEY, Objects = null },
                new KitMenuItem() { Group = "2", Type = 1, Name = "Paste", Tag = PASTE_KEY, Objects = null },
                new KitMenuItem() { Group = "2", Type = 2, Name = "Sep23", Tag = "", Objects = null },
                new KitMenuItem() { Group = "2", Type = 1, Name = "SelectAll", Tag = SELECTALL_KEY, Objects = null },

                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep1", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Loop", Tag = GROUP99, Objects = null },                
                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep1", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Tab", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Backspace", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep1", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Esc", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Enter", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep1111", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Delete", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep1", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Home", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "End", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "PgUp", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "PgDn", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep1", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Insert", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep1", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Left", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Right", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Up", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "Down", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep1", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F1", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F2", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F3", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F4", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep21", Tag = "", Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F5", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F6", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F7", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F8", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 2, Name = "Sep21", Tag = "", Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F9", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F10", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F11", Tag = GROUP01, Objects = null },
                new KitMenuItem() { Group = "1", Type = 1, Name = "F12", Tag = GROUP01, Objects = null }
            };

            List<object> objects = new List<object>();
            foreach (KitMenuItem item in listOfItem)
            {
                ToolStrip toolStrip = GetToolStrip(item.Group, item.Name, iIconSize);
                toolStrip.Tag = 9;                
                toolStrip.ItemClicked += ToolStrip_ItemClicked;                
                
                switch (item.Type)
                {
                    case 1:
                        ToolStripButton toolStripButton = CreateButton(item.Name, item, GetBitmap(item.Name + strSetIcon), item.Enable, AddButton_Click);
                        if (item.Connector == 200)
                            objects.Add(toolStripButton);
                        toolStrip.Items.Add(toolStripButton);
                        break;
                    case 2: toolStrip.Items.Add(CreateSeparator(item.Name)); break;
                    case 3: toolStrip.Items.Add(CreateLabel(item.Name)); break;
                    case 4: toolStrip.Items.Add(CreateTextBox(item.Name, item.Tag, item.Enable, OnDelayTextChanged)); break;
                    case 5:toolStrip.Items.Add(CreateComboBox(item.Name, item.Tag, item.Objects, iIndex, OnSpecialKeySelectedChange)); break;
                }
            }

            dgView.Tag = objects;

            IDictionaryEnumerator dictionaryEnumerator = buttonTable.GetEnumerator();
            while (dictionaryEnumerator.MoveNext())
            {
                ToolStrip toolStrip = dictionaryEnumerator.Value as ToolStrip;
                if (Controls.ContainsKey(toolStrip.Name))
                    Controls.Remove(Controls[toolStrip.Name]);

                Controls.Add(toolStrip);
            }

            //Menu
            List<KitMenuItem> listOfMenu = new List<KitMenuItem>
            {
                new KitMenuItem() { Group = "9File", Type = 1, Name = "New", Tag = NEW_FILE, ShortKey = Keys.Control | Keys.N },
                new KitMenuItem() { Group = "9File", Type = 1, Name = "Open", Tag = OPEN_FILE, ShortKey = Keys.Control | Keys.O },
                new KitMenuItem() { Group = "9File", Type = 1, Name = "Save", Tag = SAVE_FILE, ShortKey = Keys.Control | Keys.S },

                new KitMenuItem() { Group = "8Action", Type = 1, Name = "Key", Tag = ADD_KEY, ShortKey = Keys.Control | Keys.K },
                new KitMenuItem() { Group = "8Action", Type = 1, Name = "Mouse", Tag = ADD_MOUSE, ShortKey = Keys.Control | Keys.M },
                new KitMenuItem() { Group = "8Action", Type = 2, Name = "Sep333", Tag = "" },
                new KitMenuItem() { Group = "8Action", Type = 1, Name = "Edit", Tag = EDIT_RECORD, ShortKey = Keys.Control | Keys.E },
                new KitMenuItem() { Group = "8Action", Type = 1, Name = "Remove", Tag = DELETE_RECORD, ShortKey = Keys.Delete },
                new KitMenuItem() { Group = "8Action", Type = 1, Name = "Run", Tag = RUN_KEY, ShortKey = Keys.F5 },

                new KitMenuItem() { Group = "7Tools", Type = 1, Name = "Options", Tag = ADD_KEY },
                new KitMenuItem() { Group = "7Tools", Type = 1, Name = "Icon: Black & White", Tag = ICON_SET_01, ShortKey = Keys.Control | Keys.D1 },
                new KitMenuItem() { Group = "7Tools", Type = 1, Name = "Icon: Light Blue", Tag = ICON_SET_02, ShortKey = Keys.Control | Keys.D2 },
                new KitMenuItem() { Group = "7Tools", Type = 1, Name = "Icon: Blue", Tag = ICON_SET_03, ShortKey = Keys.Control | Keys.D3 },
                new KitMenuItem() { Group = "7Tools", Type = 2, Name = "Sep333", Tag = "" },
                new KitMenuItem() { Group = "7Tools", Type = 1, Name = "Icon Size: 16x16", Tag = ICON_SIZE_16 },
                new KitMenuItem() { Group = "7Tools", Type = 1, Name = "Icon Size: 24x24", Tag = ICON_SIZE_24 },
                new KitMenuItem() { Group = "7Tools", Type = 1, Name = "Icon Size: 32x32", Tag = ICON_SIZE_32 },
                new KitMenuItem() { Group = "7Tools", Type = 2, Name = "Sep333", Tag = "" },
                new KitMenuItem() { Group = "7Tools", Type = 1, Name = (bWait ? "SendWait" : "Sendwithoutwaiting"), Tag = OPTION_SEND }
            };

            foreach (KitMenuItem item in listOfMenu)
            {
                ToolStripMenuItem menuStrip = GetMenuItem(item.Group, item.Group);

                switch (item.Type)
                {
                    case 1: menuStrip.DropDownItems.Add(CreateToolStripMenuItem(item.Name, item, GetBitmap(item.Name + strSetIcon), item.ShortKey, AddButton_Click));break;
                    case 2: menuStrip.DropDownItems.Add(CreateSeparator(item.Name)); break;
                }
            }

            string strMenu = "Main";
            string strKey = "men" + strMenu;
            MenuStrip mainMenu = (Controls.ContainsKey(strKey)) ? Controls[strKey] as MenuStrip : BuildMenuStrip(strMenu, null);
            mainMenu.Items.Clear();
            IDictionaryEnumerator menuEnum = menuTable.GetEnumerator();
            while (menuEnum.MoveNext())
            {
                mainMenu.Items.Add(menuEnum.Value as ToolStripItem);
            }

            Controls.Add(mainMenu);
        }        

        public override void InitData()
        {            
            ObjectItem = new DataItem(bWait,strSpecial);

            strFileName = strDefaultName;
            //tssRecord.Text = "0 / 0";            
            SetDisplayItem();
            notifyIcon1.Visible = true;            
            this.ShowInTaskbar = true;
            Action.SetRegistry(0);           
        }             

        #region Add/Del/Edit
        private void ShowForm(BaseForm baseForm, DataItem objectItem, Color foreColor, params object[] objects)
        {
            baseForm.ObjectItem = objectItem;
            baseForm.InitData();

            DialogResult dialogResult = baseForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (baseForm.ObjectItem != null)
                {
                    AddDataItem(baseForm.ObjectItem, GetIndex(), foreColor);

                    if (objects.Length > 0)
                        bindingSource.Remove(objects[0]);
                }
            }
        }

        private void DeleteCurrentRow()
        {
            if (dgView.SelectedRows.Count > 0)
            {
                int iIndex = dgView.SelectedRows[0].Index;
                DataItem dataItem = bindingSource[iIndex] as DataItem;
                string strMessage = string.Format("Are you sure you want to delete the record of no {0}? \r\n({1})", iIndex + 1, dataItem.Value);
                DialogResult dialogResult = MessageBox.Show(strMessage, "Kit.AutoRun", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    bindingSource.RemoveAt(iIndex);

                    if (iIndex >= bindingSource.Count)
                        iIndex = bindingSource.Count - 1;

                    if (bindingSource.Count > 0)
                        dgView.Rows[iIndex].Selected = true;
                }
            }
        }

        private void EditCurrentRecord()
        {
            DataItem currentItem = bindingSource[dgView.SelectedRows[0].Index] as DataItem;
            ObjectItem = new DataItem() { Type = currentItem.Type, Special = currentItem.Special, Delay = currentItem.Delay, Code = currentItem.Code, Value = currentItem.Value, IsFunction = currentItem.IsFunction, Wait = currentItem.Wait };

            if (ObjectItem.Type == "Click")
                ShowForm(new ClickForm(), ObjectItem, ClickColor, currentItem);
            else if (ObjectItem.IsFunction)
                ShowForm(new KeyForm(), ObjectItem, FunctionColor, currentItem);
            else if (!ObjectItem.IsFunction)
                ShowForm(new KeyForm(), ObjectItem, KeyColor, currentItem);
        }

        private void AddDataItem(DataItem dataItem, int iIndex, Color color)
        {
            bindingSource.Insert(iIndex, dataItem);
            dgView.Rows[iIndex].DefaultCellStyle.ForeColor = color;

            SetDisplayItem();
            SetSelectedRow(GetIndex());
        }

        private string GetSpecialValue(string strData)
        {
            int iIndex = strData.IndexOf(SEPERATECHAR);
            if (iIndex != -1)
            {
                return strData.Substring(iIndex + 1);
            }
            return strData;
        }

        private int GetIndex()
        {
            if (bindingSource.Count == 0)
                return 0;

            return dgView.SelectedRows[0].Index + 1;
        }

        private void SetSelectedRow(int iIndex)
        {
            //int iIndex = GetIndex();
            if (iIndex == 1)
            {
                iIndex = bindingSource.Count;
                dgView.Rows[iIndex - 1].Selected = true;
            }
            else
                dgView.Rows[iIndex].Selected = true;
        }
        #endregion

        #region Work Item
        private void MoveItem(int iCount)
        {
            int iIndex = dgView.SelectedRows[0].Index;
            DataItem objA = (DataItem)bindingSource[iIndex];

            bindingSource.RemoveAt(iIndex);
            bindingSource.Insert(iIndex + iCount, objA);

            dgView.ClearSelection();
            dgView.Rows[iIndex + iCount].Selected = true;
            RefreshGrid();
        }

        private void dgView_SelectionChanged(object sender, EventArgs e)
        {
            SetDisplayItem();
        }

        private void SetDisplayItem()
        {
            List<object> objects = dgView.Tag as List<object>;
            int iIndex;

            if (dgView.Rows.Count > 0 && dgView.SelectedRows.Count > 0)
            {
                iIndex = dgView.SelectedRows[0].Index;
                ((ToolStripButton)objects[0]).Enabled = !(iIndex == 0);
                ((ToolStripButton)objects[1]).Enabled = !(iIndex == dgView.RowCount - 1);
            }            

            iIndex = 0;
            if (dgView.SelectedRows.Count != 0)
            {
                iIndex = dgView.SelectedRows[0].Index + 1;
            }
            tssRecord.Text = string.Format("{0} / {1}", iIndex, bindingSource.Count.ToString());

            Analyst.SetTitle(this, strFileName, Saved);
        }

        private void RefreshGrid()
        {
            foreach (DataGridViewRow row in dgView.Rows)
            {
                row.DefaultCellStyle.ForeColor = (((DataItem)row.DataBoundItem).IsFunction) ? FunctionColor : (((DataItem)row.DataBoundItem).Type == "Key" ? KeyColor : ClickColor);
            }
        }
        #endregion

        #region File
        private void CreateNew()
        {
            DialogResult result = VerifyChangeFile();
            if (result != DialogResult.Cancel)
            {
                bindingSource.Clear();
                strFileName = strDefaultName;
                IsNew = true;
                HasChanged = false;
            }
            Analyst.SetTitle(this, strFileName, Saved);            
        }

        //Save a new file
        private void SaveFile()
        {            
            if (IsNew)
            {
                DialogResult dialogResult = saveFileDialog.ShowDialog();                
                if (dialogResult == DialogResult.OK)
                {
                    strFileName = saveFileDialog.FileName;                    
                }                
            }

            SaveData(strFileName);
            Saved = true;
            IsNew = false;

            Analyst.SetTitle(this, strFileName, Saved);
            SetDisplayItem();
            if (bindingSource.Count > 0)
                RegistryData.Update(strFileName, dgView.SelectedRows[0].Index);
        }

        //Save a exist file
        private void SaveData(string strFileName)
        {
            if (strFileName != "")
            {
                string strValue = Action.GetDataValue(bindingSource);
                using (StreamWriter sw = File.CreateText(strFileName))
                {
                    sw.Write(strValue);
                }
                HasChanged = false;
            }
        }
        
        private void OpenData(string strFileName)
        {
            if (File.Exists(strFileName))
            {
                List<DataItem> listOfItem = new List<DataItem>();
                using (StreamReader sr = File.OpenText(strFileName))
                {
                    string strLine;
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        DataItem newItem = new DataItem();
                        newItem.Type = strLine;
                        newItem.Special = sr.ReadLine();
                        newItem.Value = sr.ReadLine();
                        newItem.Delay = int.Parse(sr.ReadLine());
                        newItem.Code = sr.ReadLine();
                        newItem.IsFunction = (sr.ReadLine() == "1");
                        newItem.Num = int.Parse(sr.ReadLine());
                        newItem.Wait = (sr.ReadLine() == "1");
                        listOfItem.Add(newItem);
                    }
                }
                bindingSource.Clear();
                bindingSource.DataSource = listOfItem;
            }
            else
                MessageBox.Show("File is not exist");
        }

        private DialogResult VerifyChangeFile()
        {
            if (HasChanged)
            {
                DialogResult dialog = MessageBox.Show(SAVEIFLE, this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    SaveFile();               
                }

                HasChanged = (dialog == DialogResult.Cancel) ? HasChanged : false;

                return dialog;
            }
            return DialogResult.None;
        }

        private void OpenFile()
        {
            VerifyChangeFile();

            if (bindingSource.Count > 0)
                RegistryData.Update(strFileName, dgView.SelectedRows[0].Index);

            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                strFileName = openFileDialog.FileName;
                // Open the file to read from.
                try
                {
                    OpenData(strFileName);
                    RefreshGrid();
                    Analyst.SetTitle(this, strFileName, Saved);
                    SetDisplayItem();
                    int iSelected = (int)RegistryData.Select(strFileName,0);
                    dgView.Rows[iSelected].Selected = true;

                    HasChanged = false;
                    IsNew = false;                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        #endregion

        #region Excute
        private void ExcuteItem(DataItem dataItem)
        {
            switch (dataItem.Type)
            {
                case "Key":
                    string[] strValues = dataItem.Code.Split(SPECIAL_KEY[0]);
                    foreach (string strValue in strValues)
                    {
                        if (dataItem.Wait)
                            SendKeys.SendWait(dataItem.Code);
                        else
                            SendKeys.Send(dataItem.Code);
                        Thread.Sleep(dataItem.Delay);
                    }
                    break;

                case "Single":
                    SendKeys.Send(dataItem.Special);
                    string[] arrValue = dataItem.Value.Split(',');
                    Action.DoMouseClick(int.Parse(arrValue[0]), int.Parse(arrValue[1]));
                    Thread.Sleep(dataItem.Delay);
                    break;

                case "Double":
                    SendKeys.Send(dataItem.Special);
                    string[] arrValue1 = dataItem.Value.Split(',');
                    Action.DoMouseDoubleClick(int.Parse(arrValue1[0]), int.Parse(arrValue1[1]));
                    Thread.Sleep(dataItem.Delay);
                    break;

                case "Clipboard":
                    //string strTitle = Action.GetActiveWindowTitle();
                    int strTitle = Action.GetWindows();
                    Action.SetClipboardText(strTitle);
                    break;
            }

            string strTest = Action.GetActiveWindowTitle();

            if (Action.GetForegroundWindow() == this.Handle)
            {
                MessageBox.Show("error");
                return;
            }
        }

        private bool IsBegin(DataItem dataItem)
        {
            if (dataItem.Code == BEGIN_LOOP)
                return true;
            return false;
        }

        private int GetEndIndex(BindingSource bindingSource, int iStart)
        {
            if (iStart > bindingSource.Count)
                return -1;

            for (int i = iStart; i < bindingSource.Count; i++)
            {
                object objData = bindingSource[i];
                DataItem dataItem = objData as DataItem;
                bool bEnd = IsEnd(dataItem);
                if (bEnd)
                    return i;
            }

            return -1;
        }

        private bool IsEnd(DataItem dataItem)
        {
            if (dataItem.Code == END_LOOP)
                return true;
            return false;
        }

        #region Run#1
        //using for(), xác định thời điểm bắt đầu và kết thúc loop => không chạy thread
        private void Run()
        {
            try
            {
                Action.SetRegistry(0);
                notifyIcon1.Icon = global::Kit.AutoRun.Properties.Resources.Start;
                int iIndex = 0;

                //foreach (object objData in bindingSource)
                for (int i = 0; i < bindingSource.Count; i++)
                {
                    object objData = bindingSource[i];
                    if (Action.GetStopKey() > 0)
                    {
                        this.Show();
                        break;
                    }

                    DataItem dataItem = objData as DataItem;
                    bool bBegin = IsBegin(dataItem);

                    if (bBegin)
                    {
                        int iLoop = numOfTime;
                        int iEnd = GetEndIndex(bindingSource, i);

                        for (int j = 0; j < iLoop; j++)
                        {
                            for (int k = i + 1; k < iEnd; k++)
                            {
                                DataItem subItem = bindingSource[k] as DataItem;
                                ExcuteItem(subItem);
                                iIndex = bindingSource.IndexOf(subItem);
                                dgView.Rows[iIndex].Selected = true;
                            }
                        }
                        i = iEnd;
                    }
                    else
                    {
                        ExcuteItem(dataItem);
                        iIndex = bindingSource.IndexOf(dataItem);
                        dgView.Rows[iIndex].Selected = true;
                    }                                       
                }
            }
            catch (Exception e)
            {
                this.Activate();
                MessageBox.Show(e.Message,"Kit.AutoRun");                
            }
        }
        #endregion

        #region Run#1
        //using foreach, chạy thread theo thời gian delay đã chọn
        private void Run2()
        {
            try
            {
                Action.SetRegistry(0);
                notifyIcon1.Icon = global::Kit.AutoRun.Properties.Resources.Start;
                int iIndex = 0;

                foreach (object objData in bindingSource)
                {
                    if (Action.GetStopKey() > 0)
                    {
                        this.Show();
                        break;
                    }

                    DataItem dataItem = objData as DataItem;
                    switch (dataItem.Type)
                    {
                        case "Key":
                            string[] strValues = dataItem.Code.Split(SPECIAL_KEY[0]);
                            foreach (string strValue in strValues)
                            {
                                if (dataItem.Wait)
                                    SendKeys.SendWait(dataItem.Code);
                                else
                                    SendKeys.Send(dataItem.Code);
                                Thread.Sleep(dataItem.Delay);
                            }
                            break;

                        case "Single":
                            SendKeys.Send(dataItem.Special);
                            string[] arrValue = dataItem.Value.Split(',');
                            Action.DoMouseClick(int.Parse(arrValue[0]), int.Parse(arrValue[1]));
                            Thread.Sleep(dataItem.Delay);
                            break;

                        case "Double":
                            SendKeys.Send(dataItem.Special);
                            string[] arrValue1 = dataItem.Value.Split(',');
                            Action.DoMouseDoubleClick(int.Parse(arrValue1[0]), int.Parse(arrValue1[1]));
                            Thread.Sleep(dataItem.Delay);
                            break;

                        case "Clipboard":
                            //string strTitle = Action.GetActiveWindowTitle();
                            int strTitle = Action.GetWindows();
                            Action.SetClipboardText(strTitle);
                            break;
                    }

                    string strTest = Action.GetActiveWindowTitle();

                    if (Action.GetForegroundWindow() == this.Handle)
                    {
                        MessageBox.Show("error");
                        return;
                    }

                    iIndex = bindingSource.IndexOf(objData);
                    dgView.Rows[iIndex].Selected = true;
                }
            }
            catch (Exception e)
            {
                this.Activate();
                MessageBox.Show(e.Message, "Kit.AutoRun");
            }
        }

        #region Event
        private void AddButton_Click(object sender, EventArgs e)
        {
            Type typeOfSender = sender.GetType();
            PropertyInfo pTag = typeOfSender.GetProperty("Tag");
            PropertyInfo pName = typeOfSender.GetProperty("Text");
            PropertyInfo pIcon = typeOfSender.GetProperty("Image");
            object objNameValue = pName.GetValue(sender);
            if (pTag != null)
            {
                object objValue = pTag.GetValue(sender, null);
                if (objValue != null)
                {
                    KitMenuItem kitMenuItem = objValue as KitMenuItem;
                    string strTag = kitMenuItem.Tag.ToString();

                    //Menu
                    if(strTag == TITLE_KEY)
                    {
                        //string strTitle = Action.GetActiveWindowTitle();
                        //Action.SetClipboardText(strTitle);

                        ObjectItem = new DataItem();
                        string strValue = "Clipboard";
                        ObjectItem.Type = "Clipboard";
                        ObjectItem.Special = "";
                        ObjectItem.IsFunction = true;
                        
                        ObjectItem.Value = strValue;
                        ObjectItem.Delay = iDelay;
                        ObjectItem.Wait = bWait;
                        ObjectItem.Num = numOfTime;
                        ObjectItem.Code = "";

                        AddDataItem(ObjectItem, GetIndex(), FunctionColor);
                    }
                    else if (strTag == OPTION_SEND)
                    {
                        bWait = !bWait;
                        pName.SetValue(sender, bWait ? "Send Wait" : "Send without waiting");
                        pIcon.SetValue(sender, bWait ? Properties.Resources.SentWait_1 : Properties.Resources.Sendwithoutwaiting_1);
                    }
                    else if (strTag.StartsWith(GROUP06))
                    {
                        string[] strValues = strTag.Split(SEPERATECHAR[0]);
                        RegistryData.Update(RegistryData.KIT_ICON_SIZE, int.Parse(strValues[1]));
                        InitButton();
                    }
                    else if (strTag.StartsWith(GROUP05))
                    {
                        string[] strValues = strTag.Split(SEPERATECHAR[0]);
                        RegistryData.Update(RegistryData.KIT_SET_ICON, strValues[1]);
                        InitButton();
                    }
                    else if (strTag == RUN_KEY)
                    {
                        Run();
                    }
                    else if (strTag == MOVE_UP)
                    {
                        MoveItem(-1);
                    }
                    else if (strTag == MOVE_DOWN)
                    {
                        MoveItem(1);
                    }
                    else if (strTag == ADD_KEY)
                    {
                        ShowForm(new KeyForm(), new DataItem(bWait), KeyColor);
                    }
                    else if (strTag == EDIT_RECORD)
                    {
                        //int iSelected = dgView.SelectedRows[0].Index;
                        EditCurrentRecord();
                        //dgView.Rows[iSelected].Selected = true;
                    }
                    else if (strTag == ADD_MOUSE)
                    {
                        ShowForm(new ClickForm(), new DataItem(bWait), ClickColor);
                    }
                    else if (strTag == NEW_FILE)
                    {
                        CreateNew();
                    }
                    else if (strTag == OPEN_FILE)
                    {
                        OpenFile();
                    }
                    else if (strTag == SAVE_FILE)
                    {
                        SaveFile();
                    }
                    else if (strTag == DELETE_RECORD)
                    {
                        DeleteCurrentRow();
                    }
                    else if (strTag.StartsWith(GROUP01))
                    {
                        string strValue = "{" + objNameValue + " " + numOfTime + "}";
                        ObjectItem = SetDataItem(objNameValue);
                        ObjectItem.Special = strSpecial;
                        ObjectItem.Code = string.Format("{0}{1}", ObjectItem.Special, strValue.Trim());

                        AddDataItem(ObjectItem, GetIndex(), FunctionColor);                        
                    }
                    else if (strTag.StartsWith(GROUP99))
                    {                        
                        string strValue = "Begin";
                        ObjectItem = SetDataItem(strValue);                        
                        ObjectItem.Code = string.Format("{0}", strValue.Trim());

                        AddDataItem(ObjectItem, GetIndex(), FunctionColor);

                        strValue = "End";
                        ObjectItem = SetDataItem(strValue);
                        ObjectItem.Code = string.Format("{0}", strValue.Trim());
                        ObjectItem.Num = 0;

                        AddDataItem(ObjectItem, GetIndex(), FunctionColor);
                        SetSelectedRow(GetIndex() - 2);
                    }
                    else if (strTag.StartsWith(GROUP02))
                    {
                        ObjectItem = SetDataItem(objNameValue); ;                        
                        ObjectItem.Code = GetSpecialValue(strTag);

                        AddDataItem(ObjectItem, GetIndex(), FunctionColor);                        
                    }
                }
            }
        }      
        
        private DataItem SetDataItem (object objValue)
        {
            ObjectItem = new DataItem();           
            ObjectItem.Type = "Key";
            ObjectItem.IsFunction = true;
            ObjectItem.Value = string.Format("Funtion Key : {0}", objValue);
            ObjectItem.Delay = iDelay;
            ObjectItem.Wait = bWait;
            ObjectItem.Num = numOfTime;

            return ObjectItem;
        }

        private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            HasChanged = true;
            Saved = false;
            SetDisplayItem();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryData.Update(RegistryData.KIT_SET_DELAY, iDelay);
            RegistryData.Update(RegistryData.KIT_SET_FUNCTION_INDEX, iIndex);
            RegistryData.Update(RegistryData.KIT_ICON_SIZE, iIconSize);
            RegistryData.Update(RegistryData.KIT_SET_ICON, strSetIcon);
            RegistryData.Update(RegistryData.KIT_SET_SPECIAL_VALUE, strSpecial);
            RegistryData.Update(RegistryData.KIT_OPTIOPN_SEND, bWait);

            DialogResult result = VerifyChangeFile();
            if (result == DialogResult.Cancel)
                e.Cancel = true;
            else
                notifyIcon1.Dispose();

            if (bindingSource.Count > 0)
                RegistryData.Update(strFileName, dgView.SelectedRows[0].Index);
        }
        
        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Action.SetRegistry(1);
            notifyIcon1.Icon = global::Kit.AutoRun.Properties.Resources.Stop;
        }

        /// <summary>
        /// To setup the delay value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            iItemCount++;

            ToolStrip toolStrip = sender as ToolStrip;

            if (iItemCount == toolStrip.Items.Count)
            {
                if (e.ClickedItem.Tag is KitMenuItem clickMenuItem)
                {
                    if (clickMenuItem.Tag.ToString() == INCREASE_DELAY || clickMenuItem.Tag.ToString() == DECREASE_DELAY)
                    {
                        string[] strValues = clickMenuItem.Tag.ToString().Split(SEPERATECHAR[0]);
                        iDelay += int.Parse(strValues[1]);

                        if (iDelay <= 0)
                        {
                            iDelay = 0;
                            e.ClickedItem.Enabled = false;
                        }
                        else
                        {
                            foreach (ToolStripItem item in toolStrip.Items)
                            {
                                if (item.Tag is KitMenuItem menuItem && menuItem.Connector != 1 && menuItem.Connector == clickMenuItem.Connector)
                                {
                                    item.Enabled = true;
                                }
                            }
                        }

                        toolStrip.Items[int.Parse(toolStrip.Tag.ToString())].Enabled = false;
                        toolStrip.Items[int.Parse(toolStrip.Tag.ToString())].Text = iDelay.ToString();
                    }

                    if (clickMenuItem.Tag.ToString() == INCREASE_TIME || clickMenuItem.Tag.ToString() == DECREASE_TIME)
                    {
                        string[] strValues = clickMenuItem.Tag.ToString().Split(SEPERATECHAR[0]);
                        numOfTime += int.Parse(strValues[1]);

                        if (numOfTime <= 1)
                        {
                            numOfTime = 1;
                            e.ClickedItem.Enabled = false;
                        }
                        else
                        {
                            foreach (ToolStripItem item in toolStrip.Items)
                            {
                                if (item.Tag is KitMenuItem menuItem && menuItem.Connector != 1 && menuItem.Connector == clickMenuItem.Connector)
                                {
                                    item.Enabled = true;
                                }
                            }
                        }

                        toolStrip.Items[14].Enabled = false;
                        toolStrip.Items[14].Text = numOfTime.ToString();
                    }

                    iItemCount = 0;
                }
            }
        }     

        private void dgView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                EditCurrentRecord();
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                EditCurrentRecord();
        }

        private void OnSpecialKeySelectedChange(object sender, EventArgs e)
        {
            ToolStripComboBox toolStripComboBox = sender as ToolStripComboBox;

            iIndex = toolStripComboBox.SelectedIndex;
            int iCut = toolStripComboBox.SelectedItem.ToString().IndexOf("(");
            strSpecial = (iCut != -1) ? toolStripComboBox.SelectedItem.ToString().Substring(iCut + 1, 1) : "";            
            RegistryData.Update(RegistryData.KIT_SET_SPECIAL_VALUE, strSpecial);
        }

        private void OnDelayTextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox toolStripTextBox = sender as ToolStripTextBox;
            if(toolStripTextBox.Name.ToString() == DELAY)
                iDelay = int.Parse(toolStripTextBox.Text);
            else
                numOfTime = int.Parse(toolStripTextBox.Text);
        }
        #endregion
    }
}