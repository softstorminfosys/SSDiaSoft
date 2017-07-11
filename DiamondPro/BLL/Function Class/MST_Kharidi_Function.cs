using DiamondPro.BLL.Property_Class;
using InterviewDemo.DLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL
{
    public class MST_Kharidi_Function
    {
        Operation Ope = new Operation();

        public int InsertUpdate(MST_Kharidi_Property pProperty)
        {
            Request Request = new Request();
            Request.AddParameter("@Id",pProperty.ID,DbType.Int32,ParameterDirection.Input);
            Request.AddParameter("@NotNo", pProperty.notno, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@KatNo", pProperty.katno, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@KharidiDate", DateTime.Parse(pProperty.KharidiDate).ToString("MM/dd/yyyy"), DbType.String, ParameterDirection.Input);
            Request.AddParameter("@PaymentDate", DateTime.Parse(pProperty.PaymentDate).ToString("MM/dd/yyyy"), DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Term", pProperty.Term, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@PartyId", pProperty.PartyId, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@BrokerId", pProperty.BrokerId, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@Cts", pProperty.Cts, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@Rate", pProperty.Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@RafPer", pProperty.RafPer, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@BasicTotal", pProperty.BasicTotal, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@AngadiyaPer", pProperty.AngadiyaPer, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@AngadiyaKharch", pProperty.AngadiyaKharch, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@FinalTotal", pProperty.FinalTotal, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@PendingAmount", pProperty.PendingAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@PaidAmount", pProperty.PaidAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.ComandText1 = "MST_Kharidi_InsertUpdate";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1,Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }

        public DataTable KharidiMasterGetDataFOrGrid(string pSearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", pSearchParam, DbType.String, ParameterDirection.Input);
            //Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "MST_Kharidi_GetDataForGrid";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }

        public int Delete(int Id)
        {
            Request Request = new Request();
            Request.AddParameter("@Id", Id, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Input);
            Request.ComandText1 = "MST_Kharidi_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }

        public DataTable KharidiMasterGetNotNo(int IsPolish)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@IsPolish", IsPolish,DbType.Int32,ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "MST_Kharidi_GetNotNo";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            
            return dt;
        }
    }
}
