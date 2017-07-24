﻿using InterviewDemo.DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Function_Class
{
    public class UserRights_Function
    {
        Operation Ope = new Operation();

        public DataTable GetUserData(int UserTypeId)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@UserTypeId", UserTypeId, DbType.Int32, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "Get_UserRights_Data";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }
    }
}
