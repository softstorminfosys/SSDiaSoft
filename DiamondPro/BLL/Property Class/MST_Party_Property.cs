using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Property_Class
{
    public class MST_Party_Property
    {
        public int Id { get; set; }
        public string PartyType { get; set; }
        public string PartyName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int Active { get; set; }
    }
}
