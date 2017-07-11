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
    public class MST_Karkhana_Function
    {
        Operation Ope = new Operation();

        public int InsertUpdate(MST_Karkhana_Property pProperty)
        {
            Request Request = new Request();
            Request.AddParameter("@Id", pProperty.Id, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@KarkhanaName", pProperty.KarkhanaName, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@OwnerName", pProperty.OwnerName, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Mobile", pProperty.Mobile, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Address", pProperty.Address, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Active", pProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.ComandText1 = "MST_Karkhana_InsertUpdate";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }

        public DataTable GetDataFoGrid(string SearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", SearchParam, DbType.String, ParameterDirection.Input);
            Request.ComandText1 = "MST_Karkhana_GetDataForGrid";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }
    }
}
