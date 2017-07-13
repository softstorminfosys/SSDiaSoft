using DiamondPro.BLL.Property_Class;
using InterviewDemo.DLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Function_Class
{
    class MST_Vechan_Function
    {
        Operation Ope = new Operation();
        public int InsertUpdate(MST_Vechan_Property pProperty)
        {
            Request Request = new Request();
            Request.AddParameter("@Id", pProperty.ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@VechanNotNo", pProperty.VechanNotno, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Qty", pProperty.Quality, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@QtySize", pProperty.QualitySize, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@VechanDate", DateTime.Parse(pProperty.VechanDate).ToString("MM/dd/yyyy"), DbType.String, ParameterDirection.Input);
            Request.AddParameter("@PaymentDate", DateTime.Parse(pProperty.PaymentDate).ToString("MM/dd/yyyy"), DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Term", pProperty.Term, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@PartyId", pProperty.PartyId, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@BrokerId", pProperty.BrokerId, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@Cts", pProperty.Cts, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@Rate", pProperty.Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@VechanPer", pProperty.VechanPer, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@BasicTotal", pProperty.BasicTotal, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@AngadiyaPer", pProperty.AngadiyaPer, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@AngadiyaKharch", pProperty.AngadiyaKharch, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@BroPer", pProperty.BroPer, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@BroAmount", pProperty.BroAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@FinalTotal", pProperty.FinalTotal, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@PendingAmount", pProperty.PendingAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@PaidAmount", pProperty.PaidAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.ComandText1 = "MST_Vechan_InsertUpdate";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }
    }
}
