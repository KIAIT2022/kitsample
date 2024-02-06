using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kit.AutoRun
{
    public class Analyst
    {
        public static string GetCode(string strSpecial, string strValue, bool isFunction)
        {
            string strText = "";
            if (isFunction)
            {
                string[] arrValue = strValue.Split(':');
                return "{"+arrValue[1].Trim() + "}";
            }
            else
            {
                foreach (char chr in strValue)
                {
                    if (chr == ' ')
                    {
                        strText += " ";
                    }
                    else
                        strText += "{" + chr + "}";
                }
                return string.Format("{0}{1}", strSpecial, strText);
            }
        }

        public static string GetSpecial(bool bNone, bool bCtrl, bool bAlt, bool bShift)
        {
            string strKey = "";

            if (bNone)
                strKey = "";
            else if (bCtrl)
                strKey = "^";
            else if (bAlt)
                strKey = "%";
            else if (bShift)
                strKey = "+";

            return strKey;
        }

        public static void SetTitle(Form form,string fileName, bool bSaved)
        {
            if (fileName != "")            
                fileName = string.Format(" - {0}",fileName);

            form.Text = string.Format("Kit.Auto Run {0} {1}", fileName, (bSaved ? "Saved" : ""));
        }        
    }
}