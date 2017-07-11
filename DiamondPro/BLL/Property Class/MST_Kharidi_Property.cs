using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Property_Class
{
    public class MST_Kharidi_Property
    {
        public int ID { get; set; }
        public string notno { get; set; }
        public string katno { get; set; }
        public string KharidiDate { get; set; }
        public int Term { get; set; }   
        public string PaymentDate { get; set; }
        public int PartyId { get; set; }
        public int BrokerId { get; set; }
        public double Cts { get; set; }
        public double Rate { get; set; }
        public double RafPer { get; set; }
        public double BasicTotal { get; set; }
        public double AngadiyaPer { get; set; }
        public double AngadiyaKharch { get; set; }
        public double FinalTotal { get; set; }
        public double PaidAmount { get; set; }
        public double PendingAmount { get; set; }
    }
}
