using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Property_Class
{
    public class Karkhana_Issue_Property
    {
        public int Id { get; set; }
        public int KarkhanaId { get; set; }
        public string IssueDate { get; set; }
        public string NotNo { get; set; }
        public string KatNo { get; set; }
        public string Kharididate { get; set; }
        public double Vajan { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double BanvaChadelu { get; set; }
        public double VajanLoss { get; set; }
        public double VajanGhatt { get; set; }
        public double PalsuVajan { get; set; }
        public double PalsuRate { get; set; }
        public double PalsuAmount { get; set; }
        public double ChokiVajan { get; set; }
        public double ChokiRate { get; set; }
        public double ChokiAmount { get; set; }
        public double DblVajan { get; set; }
        public double DblRate { get; set; }
        public double DblAmount { get; set; }
        public double PCDAmount { get; set; }
        public int Than { get; set; }
        public double ThanTotal { get; set; }
        public double TaiyarVajan { get; set; }
        public double TaiyarPadatar { get; set; }
        public double CommPadatar { get; set; }
        public double FinalPadatar { get; set; }
        public double STaka { get; set; }
        public double RafTaka { get; set; }
        public double ThanMajuri { get; set; }
        public double CommMajuri { get; set; }
        public double FinalPadatarTaka { get; set; }
        public string Status { get; set; }
    }
}
