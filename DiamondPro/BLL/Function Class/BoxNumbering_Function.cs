using DiamondPro.BLL.Property_Class;
using DiamondPro.DLL;
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
    public class BoxNumbering_Function
    {
        Validation Val = new Validation();
        Operation Ope = new Operation();
        SqlConnection conn = new SqlConnection();

        public DataTable GetBoxDetails(string pSearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", pSearchParam, DbType.String, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "GetBoxDetails_For_Numbering";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }

        public int SaveNumbering(BoxNumbering_Property pPE, DataTable dt)
        {
            int RetValue = 0;
            try
            {
                //Ope.Transaction =  Ope.BeginTransaction();
                Request Request = new Request();
                Request.AddParameter("@BoxNo", pPE.BoxNo, DbType.Int32, ParameterDirection.Input);
                Request.AddParameter("@BoxName", pPE.BoxName, DbType.String, ParameterDirection.Input);
                Request.AddParameter("@Cts", pPE.Cts, DbType.Double, ParameterDirection.Input);
                Request.AddParameter("@Rate", pPE.Rate, DbType.Double, ParameterDirection.Input);
                Request.AddParameter("@Amount", pPE.Amount, DbType.Double, ParameterDirection.Input);
                Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
                Request.CommandType = CommandType.StoredProcedure;
                Request.ComandText1 = "BoxNumber_Master_Save";
                ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request, Ope.Transaction);
                RetValue = (Int32)arrlist[0];

                if (RetValue < 1)
                {
                    return 0;
                }
                else
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        if (Val.ToString(dRow["QualityId"]) != "")
                        {
                            Request Request1 = new Request();
                            Request1.AddParameter("@NDID", Val.ToString(dRow["NDID"]) == "" ? 0 : Val.ToInt(dRow["NDID"]), DbType.Int32, ParameterDirection.Input);
                            Request1.AddParameter("@NID", RetValue, DbType.Int32, ParameterDirection.Input);
                            Request1.AddParameter("@BoxName", pPE.BoxName, DbType.String, ParameterDirection.Input);
                            Request1.AddParameter("@QualityId", Val.ToString(dRow["QualityId"]), DbType.Int32, ParameterDirection.Input);
                            Request1.AddParameter("@ChavniId", Val.ToString(dRow["ChavniId"]), DbType.Int32, ParameterDirection.Input);
                            Request1.AddParameter("@Cts", Val.ToDouble(dRow["Cts"]), DbType.Double, ParameterDirection.Input);
                            Request1.AddParameter("@Rate", Val.ToDouble(dRow["Rate"]), DbType.Double, ParameterDirection.Input);
                            Request1.AddParameter("@Amount", Val.ToDouble(dRow["Amount"]), DbType.Double, ParameterDirection.Input);
                            Request1.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
                            Request1.CommandType = CommandType.StoredProcedure;
                            Request1.ComandText1 = "BoxNumber_Detail_Save";
                            ArrayList arrlist1 = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request1, Ope.Transaction);
                            Int32 RetValue1 = (Int32)arrlist1[0];
                        }                        
                    }
                }
                //Ope.CommitTransaction();
            }
            catch (Exception)
            {
                //Ope.RollbackTransaction();
                return 0;
            }
            return RetValue;
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

        public int DBBackup()
        {
            Int32 RetVal = 0;
            try
            {
                Request Request = new Request();
                Request.AddParameter("@ReturnValue",0,DbType.Int32,ParameterDirection.Output);
                Request.CommandType = CommandType.StoredProcedure;
                Request.ComandText1 = "Sp_Database_Backup";
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
