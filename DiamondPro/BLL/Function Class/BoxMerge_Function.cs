using DiamondPro.BLL.Property_Class;
using DiamondPro.DLL;
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
    class BoxMerge_Function
    {
        Validation Val = new Validation();
        Operation Ope = new Operation();

        public DataTable PacketDetailGetDataForGrid(string pSearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", pSearchParam, DbType.String, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "TRN_Box_GetDataForMerging";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }

        public int BoxCreate(DataTable dtMerge, int BoxNo)
        {
            Int32 RetVal = 0;
            try
            {
                Request Request;
                foreach (DataRow dRow in dtMerge.Rows)
                {
                    if (Val.ToDouble(dRow["Cts"]) > 0 && Val.ToInt(dRow["KatNo"]) > 0 && Val.ToString(dRow["NotNo"]) != "")
                    {
                        Request = new Request();
                        Request.AddParameter("@Id", Val.ToInt(dRow["BoxId"]), DbType.Int32, ParameterDirection.Input);
                        //Request.AddParameter("@TransId", Val.ToInt32(dRow["TransId"]), DbType.Int32, ParameterDirection.Input);
                        Request.AddParameter("@NotNo", Val.ToString(dRow["NotNo"]), DbType.String, ParameterDirection.Input);
                        Request.AddParameter("@KatNo", Val.ToInt(dRow["KatNo"]), DbType.Int32, ParameterDirection.Input);
                        Request.AddParameter("@Cts", Val.ToDouble(dRow["Cts"]), DbType.Double, ParameterDirection.Input);
                        Request.AddParameter("@Rate", Val.ToDouble(dRow["Rate"]), DbType.Double, ParameterDirection.Input);
                        Request.AddParameter("@FinalTotal", Val.ToDouble(dRow["Amount"]), DbType.Double, ParameterDirection.Input);
                        Request.AddParameter("@Status", "BOX CREATED", DbType.String, ParameterDirection.Input);
                        Request.AddParameter("@BoxNo", BoxNo, DbType.Int32, ParameterDirection.Input);
                        Request.AddParameter("@BoxName", "B" + BoxNo, DbType.String, ParameterDirection.Input);
                        Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
                        Request.CommandType = CommandType.StoredProcedure;
                        Request.ComandText1 = "MST_BoxCreate_Save";
                        ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
                        RetVal = (Int32)arrlist[0];
                    }                    
                }
                return RetVal;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(string BoxName)
        {
            Int32 RetVal = 0;
            try
            {
                Request Request = new Request();

                Request.AddParameter("@BoxName", BoxName, DbType.String, ParameterDirection.Input);
                Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
                Request.CommandType = CommandType.StoredProcedure;
                Request.ComandText1 = "TRN_Box_Delete";
                ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
                RetVal = (Int32)arrlist[0];

                return RetVal;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int GetBoxNumber()
        {
            Request Request = new Request();
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "GetBoxNo";
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }

        public DataTable GetBoxDetail(string pSearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", pSearchParam, DbType.String, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "GetBoxDetail";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }

        public DataSet BoxSummaryDetails(string pSearchParam)
        {
            DataSet DS = new DataSet();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", pSearchParam, DbType.String, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "MST_GetBoxDetailForShow";
            Ope.GetDataSet(Operation.ConnectionString1, DS, "BoxDetail", Request);
            return DS;
        }
    }
}


    