using System;
using System.Collections.Generic;
using System.Text;

namespace OperacaoCaixa.Core.Models
{
    public class Common
    {
        public DateTime Modificado { get; set; }
        public string StatusRow { get; set; }
        public Int32 IdUserInsert { get; set; }
        public Nullable<Int32> IdUserUpdate { get; set; }
    }
}
