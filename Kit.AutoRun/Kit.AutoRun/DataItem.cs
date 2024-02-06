using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kit.AutoRun
{
    public class DataItem
    {
        public DataItem() { }
        public DataItem(bool bWait) { Wait = bWait; }
        public DataItem(bool bWait, string strSpecial) { Wait = bWait; Special = strSpecial; }
        public string Type { get; set; }
        public string Special{ get; set; }
        public string Value { get; set; }
        public int Delay { get; set; }
        public string Code { get; set; }
        public bool IsFunction { get; set; } = false;
        public int Schedule { get; set; }
        public bool Wait { get; set; } = false;
        public int Num { get; set; }
    }
}