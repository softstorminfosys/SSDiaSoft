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
    public class TRN_Payment_detail_Function
    {
        Operation Ope = new Operation();

        public int InsertUpdate(TRN_Payment_detail_Property pProperty, int PaymentType)
        {            
            Request Request = new Request();
            Request.AddParameter("@Id",pProperty.Id,DbType.Int32,ParameterDirection.Input);
            Request.AddParameter("@PaymentType", pProperty.PaymentType, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@TransId", pProperty.TransId, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@PaymentType", pProperty.PaymentType, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@PartyId", pProperty.PartyId, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@PaymwntDate", pProperty.PaymentDate, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@KharidiDate", pProperty.KharidiDate, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@NotNo", pProperty.NotNo, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@KatNo", pProperty.KatNo, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Cts", pProperty.Cts, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@Rate", pProperty.Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@Amount", pProperty.Amount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@PaidAmount", pProperty.PaidAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@DueAmount", pProperty.DueAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@IsPolish", PaymentType, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.ComandText1 = "TRN_Payment_Detail_InsertUpdate";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1,Request);
            Int32 RetValue = (Int32)arrlist[0];
            return RetValue;
        }

        public DataTable FillNotNo(string PSearchParam, int IsKharidi)
        {
            DataTable dtNotNo = new DataTable();
            Request Request = new Request();

            Request.AddParameter("@SearchParam",PSearchParam,DbType.String,ParameterDirection.Input);
            Request.AddParameter("@IsKharidi", IsKharidi, DbType.Int32, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "Get_NotNo_For_Search";
            Ope.GetDataTable(Operation.ConnectionString1,dtNotNo,Request);
            return dtNotNo;
        }

        public DataTable FilluniqueNotNo(string PSearchParam, int IsKharidi)
        {
            DataTable dtNotNo = new DataTable();
            Request Request = new Request();

            Request.AddParameter("@SearchParam", PSearchParam, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@IsKharidi", IsKharidi, DbType.Int32, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "KarkhanaIssue_UniqueNotno";
            Ope.GetDataTable(Operation.ConnectionString1, dtNotNo, Request);
            return dtNotNo;
        }
    }


}
