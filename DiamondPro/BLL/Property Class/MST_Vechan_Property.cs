using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Property_Class
{
    class MST_Vechan_Property
    {
        public int ID { get; set; }
        public string VechanNotno { get; set; }
        public string Quality { get; set; }
        public string QualitySize { get; set; }
        public string VechanDate { get; set; }
        public int Term { get; set; }
        public string PaymentDate { get; set; }
        public int PartyId { get; set; }
        public int BrokerId { get; set; }
        public double Cts { get; set; }
        public double Rate { get; set; }
        public double VechanPer { get; set; }
        public double BasicTotal { get; set; }
        public double AngadiyaPer { get; set; }
        public double AngadiyaKharch { get; set; }
        public double BroPer { get; set; }
        public double BroAmount { get; set; }
        public double FinalTotal { get; set; }
        public double PaidAmount { get; set; }
        public double PendingAmount { get; set; }
    }
}
