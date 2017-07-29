using DiamondPro.DLL;
using DiamondPro.DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Function_Class
{
    public class Login_Function
    {
        Operation Ope = new Operation();

        public DataTable GetUserDetail(string UserName, string Password)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@UserName",UserName,DbType.String,ParameterDirection.Input);
            Request.AddParameter("@PassWord", Password, DbType.String, ParameterDirection.Input);
            Request.ComandText1 = "MST_USERDETAIL_GETDATAFOR_LOGIN";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }
    }
}
