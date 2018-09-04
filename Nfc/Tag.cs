using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfcTest.Nfc
{
    public class Tag
    {
        public virtual string identifier { get; set; }
        public virtual bool is_authenticated { get; set; }
        public virtual bool is_present { get; set; }
        public virtual string product { get; set; }
        public virtual Type type { get; set; }
    }
}
