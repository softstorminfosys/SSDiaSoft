using DiamondPro.BLL.Property_Class;
using InterviewDemo.DLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DiamondPro.DLL;

namespace DiamondPro.BLL.Function_Class
{
    public class StockTransfer_Function
    {
        Validation Val = new Validation();
        Operation Ope = new Operation();

        public int GetMaxReferenceNo()
        {
            int RefNo = 0;
            Request Request = new Request();
           
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "GetMax_ReferenceNo_StockTransfer";
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            RefNo = (Int32)arrlist[0];
            return RefNo;
        }

        public DataTable GetQualityDetail(string SearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", SearchParam, DbType.String, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "GetNumberingDetail";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }

        public DataTable GetQualityDetailSale(string SearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", SearchParam, DbType.String, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "Get_Stock_Details";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }

        public int Save(DataTable dtFrom, DataTable dtTo)
        {
            int RetValue = 0;
            try
            {
                int ReferenceId = GetMaxReferenceNo();

                foreach (DataRow Drow in dtFrom.Rows)
                {
                    if (Val.ToString(Drow["QualityId"]) != "")
                    {
                        Request Request = new Request();
                        Request.AddParameter("@RefId", ReferenceId, DbType.Int32, ParameterDirection.Input);
                        Request.AddParameter("@QualityId", Val.ToInt(Drow["QualityId"]), DbType.Int32, ParameterDirection.Input);
                        Request.AddParameter("@Cts", Val.ToDouble(Drow["Cts"]), DbType.Double, ParameterDirection.Input);
                        Request.AddParameter("@Rate", Val.ToDouble(Drow["Rate"]), DbType.Double, ParameterDirection.Input);
                        Request.AddParameter("@Amount", Val.ToDouble(Drow["Amount"]), DbType.Double, ParameterDirection.Input);
                        Request.AddParameter("@TCarat", Val.ToDouble(Drow["TCarat"]), DbType.Double, ParameterDirection.Input);
                        Request.AddParameter("@TRate", Val.ToDouble(Drow["TRate"]), DbType.Double, ParameterDirection.Input);
                        Request.AddParameter("@TAmount", Val.ToDouble(Drow["TAmount"]), DbType.Double, ParameterDirection.Input);
                        Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
                        Request.CommandType = CommandType.StoredProcedure;
                        Request.ComandText1 = "TRN_Stock_Transfer_From_Save";
                        ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request, Ope.Transaction);
                        RetValue = (Int32)arrlist[0];
                    }
                }
                if (RetValue < 1)
                {
                    return 0;
                }
                else
                {
                    foreach (DataRow dRow in dtTo.Rows)
                    {
                        if (Val.ToString(dRow["QualityId"]) != "")
                        {
                            Request Request1 = new Request();
                            //Request1.AddParameter("@NDID", Val.ToString(dRow["NDID"]) == "" ? 0 : Val.ToInt32(dRow["NDID"]), DbType.Int32, ParameterDirection.Input);
                            Request1.AddParameter("@RefId", ReferenceId, DbType.Int32, ParameterDirection.Input);
                            Request1.AddParameter("@QualityId", Val.ToInt(dRow["QualityId"]), DbType.Int32, ParameterDirection.Input);
                            Request1.AddParameter("@Cts", Val.ToDouble(dRow["Cts"]), DbType.Double, ParameterDirection.Input);
                            Request1.AddParameter("@Rate", Val.ToDouble(dRow["Rate"]), DbType.Double, ParameterDirection.Input);
                            Request1.AddParameter("@Amount", Val.ToDouble(dRow["Amount"]), DbType.Double, ParameterDirection.Input);
                            Request1.AddParameter("@TCarat", Val.ToDouble(dRow["TCarat"]), DbType.Double, ParameterDirection.Input);
                            Request1.AddParameter("@TRate", Val.ToDouble(dRow["TRate"]), DbType.Double, ParameterDirection.Input);
                            Request1.AddParameter("@TAmount", Val.ToDouble(dRow["TAmount"]), DbType.Double, ParameterDirection.Input);
                            Request1.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
                            Request1.CommandType = CommandType.StoredProcedure;
                            Request1.ComandText1 = "TRN_Stock_Transfer_To_Save";
                            ArrayList arrlist1 = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request1, Ope.Transaction);
                            Int32 RetValue1 = (Int32)arrlist1[0];
                        }
                    }
                }
                return RetValue;
            }
            catch (Exception)
            {
               return 0;
            }
            
        }

        public int Delete(int BoxNo, string BoxName,int Mul)
        {
            Int32 RetVal = 0;
            try
            {
                Request Request = new Request();
                Request.AddParameter("@BoxNo", BoxNo, DbType.Int32, ParameterDirection.Input);
                Request.AddParameter("@BoxName", BoxName, DbType.String, ParameterDirection.Input);
                Request.AddParameter("@Detail", Mul, DbType.Int32, ParameterDirection.Input);
                Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
                Request.CommandType = CommandType.StoredProcedure;
                Request.ComandText1 = "TRN_BoxNumber_Delete";
                ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
                RetVal = (Int32)arrlist[0];

                return RetVal;
            }
            catch (Exception)
            {
                return 0;
            }
        }
               
    }
}
