using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kit.AutoRun
{
    public class KitMenuItem
    {
        public string Group { get; set; } //1, 2, 3
        public int Type { get; set; } // 1: Button, 2: Seperate, 3: Label, 4: Text, 5: ComboBox
        public string Name { get; set; }
        public string Tag { get; set; }
        public object[] Objects { get; set; }
        public Keys ShortKey { get; set; }
        public bool Enable { get; set; } = true;
        public int Connector { get; set; } = 1;
    }
}
