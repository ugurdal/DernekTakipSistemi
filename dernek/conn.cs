using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dernek
{
    public static class conn
    {
        public static string bag = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                  @"Data Source=" + Application.StartupPath + "\\dernek.mdb; " +
                                  @"Jet OLEDB:Database Password=grdl;Persist Security Info=true";

    }
}
