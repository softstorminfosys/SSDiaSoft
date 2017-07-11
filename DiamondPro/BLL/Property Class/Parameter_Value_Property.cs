using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Property_Class
{
    public class Parameter_Value_Property
    {
        public int Id { get; set; }
        public int ParameterType { get; set; }
        public string ParaCode { get; set; }
        public string ParaValue { get; set; }
        public string Remark { get; set; }
        public int Active { get; set; }
    }
}
