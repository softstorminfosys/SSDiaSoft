using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Property_Class
{
    public class TRN_Payment_detail_Property
    {
        public int Id { get; set; }
        public string TransId { get; set; }
        public string  PaymentType { get; set; }
        public int PartyId { get; set; }
        public string  PaymentDate { get; set; }
        public string KharidiDate { get; set; }
        public string NotNo { get; set; }
        public string KatNo { get; set; }
        public double Cts { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double PaidAmount { get; set; }
        public double DueAmount { get; set; }
    }
}
