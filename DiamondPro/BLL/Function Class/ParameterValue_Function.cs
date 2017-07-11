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
    public class ParameterValue_Function
    {
        Operation Ope = new Operation();

        public int InsertUpdate(Parameter_Value_Property pProperty)
        {
            Request Request = new Request();
            Request.AddParameter("@Id",pProperty.Id,DbType.Int32,ParameterDirection.Input);
            Request.AddParameter("@TypeId", pProperty.ParameterType, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ParaCode", pProperty.ParaCode, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@ParaValue", pProperty.ParaValue, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Remark", pProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Active", pProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32,ParameterDirection.Output);
            Request.ComandText1 = "MST_ParameterValue_InsertUpdate";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1,Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }

        public DataTable GetDataFoGrid(string SearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam",SearchParam,DbType.String,ParameterDirection.Input);
            Request.ComandText1 = "MST_ParameterValue_GetDataForGrid";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(Operation.ConnectionString1,dt,Request);
            return dt;
        }
    }
}
