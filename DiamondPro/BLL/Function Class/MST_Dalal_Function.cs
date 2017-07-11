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
    public class MST_Dalal_Function
    {
        Operation Ope = new Operation();

        public int InsertUpdate(MST_Dalal_Property pProperty)
        {
            Request Request = new Request();
            Request.AddParameter("@Id", pProperty.Id, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@PartyId", pProperty.PartyId, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@DalalName", pProperty.DalalName, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Mobile", pProperty.Mobile, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Address", pProperty.Address, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@DalalType", pProperty.DalalType, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Active", pProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.ComandText1 = "MST_Dalal_InsertUpdate";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }

        public DataTable DalalMasterGetDataFOrGrid(string pSearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", pSearchParam, DbType.String, ParameterDirection.Input);
            //Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "MST_Dalal_GetDataForGrid";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }

        public int Delete(int Id)
        {
            Request Request = new Request();
            Request.AddParameter("@Id", Id, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Input);
            Request.ComandText1 = "MST_Dalal_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }
    }
}
