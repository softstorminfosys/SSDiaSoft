using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace DiamondPro.BLL.Property_Class
{
    public class BoxNumbering_Property
    {
        public int Id { get; set; }
        public int BoxNo { get; set; }
        public string BoxName { get; set; }
        public double Cts { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
    }
}
