using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Param_Hospital.BLL.Property_Class
{
    public class FrmSearchProperty
    {
        public DataTable dtTable { get; set; }
        public DataGridViewRow Row { get; set; }
        public bool FlagExit { get; set; }
        public string serachfield { get; set; }
    }
}
