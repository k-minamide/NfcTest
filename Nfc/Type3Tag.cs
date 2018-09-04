using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfcTest.Nfc
{
    public class Type3Tag : Tag
    {
        public virtual string idm { get; set; }
        public virtual string pmm { get; set; }
        public virtual string sys { get; set; }

        public override string identifier { get => this.idm; set => this.idm = value; }
    }
}
