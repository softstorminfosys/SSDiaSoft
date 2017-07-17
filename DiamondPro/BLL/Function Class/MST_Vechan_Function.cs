using DiamondPro.BLL.Property_Class;
using DiamondPro.DLL;
using InterviewDemo.DLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Function_Class
{
    class MST_Vechan_Function
    {
        Operation Ope = new Operation();
        Validation Val = new Validation();
        public string GetMaxSalNo()
        {
            Request Request = new Request();
            Request.AddParameter("@MexSaleNo","",DbType.String,ParameterDirection.Output);
            Request.ComandText1 = "GetMaxSaleNo";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            String RetVal = (String)arrlist[0];
            return RetVal;
        }

        public int InsertUpdate(MST_Vechan_Property pProperty, DataTable dtSale)
        {
                Request Request = new Request();
                Request.AddParameter("@Id", pProperty.ID, DbType.Int32, ParameterDirection.Input);
                Request.AddParameter("@VechanNotNo", pProperty.VechanNotno, DbType.String, ParameterDirection.Input);
                Request.AddParameter("@VechanDate", DateTime.Parse(pProperty.VechanDate).ToString("MM/dd/yyyy"), DbType.String, ParameterDirection.Input);
                Request.AddParameter("@PaymentDate", DateTime.Parse(pProperty.PaymentDate).ToString("MM/dd/yyyy"), DbType.String, ParameterDirection.Input);
                Request.AddParameter("@Term", pProperty.Term, DbType.Int32, ParameterDirection.Input);
                Request.AddParameter("@PartyId", pProperty.PartyId, DbType.Int32, ParameterDirection.Input);
                Request.AddParameter("@BrokerId", pProperty.BrokerId, DbType.Int32, ParameterDirection.Input);
                Request.AddParameter("@Cts", pProperty.Cts, DbType.Double, ParameterDirection.Input);
                Request.AddParameter("@Rate", pProperty.Rate, DbType.Double, ParameterDirection.Input);
                Request.AddParameter("@VechanPer", pProperty.VechanPer, DbType.Double, ParameterDirection.Input);
                Request.AddParameter("@BasicTotal", pProperty.BasicTotal, DbType.Double, ParameterDirection.Input);
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

                if (RetVal < 1)
                {
                    return 0;
                }

                foreach (DataRow dRow in dtSale.Rows)
                {
                    if (Val.ToInt(dRow["QualityId"]) > 0 && Val.ToInt(dRow["QualityId"]) != null)
                    {
                        Request Request1 = new Request();
                        Request1.AddParameter("@VechanId", RetVal, DbType.Int32, ParameterDirection.Input);
                        Request1.AddParameter("@VechanNotNo", pProperty.VechanNotno, DbType.String, ParameterDirection.Input);
                        Request1.AddParameter("@QualityId", Val.ToInt(dRow["QualityId"]), DbType.Int32, ParameterDirection.Input);
                        Request1.AddParameter("@Cts", Val.ToDouble(dRow["Cts"]), DbType.Double, ParameterDirection.Input);
                        Request1.AddParameter("@Rate", Val.ToDouble(dRow["Rate"]), DbType.Double, ParameterDirection.Input);
                        Request1.AddParameter("@Amount", Val.ToDouble(dRow["Amount"]), DbType.Double, ParameterDirection.Input);
                        Request1.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
                        Request1.ComandText1 = "MST_Vechan_Details_InsertUpdate";
                        Request1.CommandType = CommandType.StoredProcedure;
                        ArrayList arrlist1 = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request1);
                        Int32 RetVal1 = (Int32)arrlist1[0];
                    }
                }
                return RetVal;
                     
        }
    }
}
