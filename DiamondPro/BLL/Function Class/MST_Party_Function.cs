﻿using DiamondPro.BLL.Property_Class;
using DiamondPro.DLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.BLL.Function_Class
{
    public class MST_Party_Function
    {
        Operation Ope = new Operation();

        public int InsertUpdate(MST_Party_Property pProperty)
        {
            Request Request = new Request();
            Request.AddParameter("@Id", pProperty.Id, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@PartyName", pProperty.PartyName, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Mobile", pProperty.Mobile, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Address", pProperty.Address, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@PartyType", pProperty.PartyType, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Active", pProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.ComandText1 = "MST_Party_InsertUpdate";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }

        public DataTable PartyMasterGetDataFOrGrid(string pSearchParam)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParameter("@SearchParam", pSearchParam, DbType.String, ParameterDirection.Input);
            //Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.CommandType = CommandType.StoredProcedure;
            Request.ComandText1 = "MST_Party_GetDataForGrid";
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }

        public int Delete(int Id)
        {
            Request Request = new Request();
            Request.AddParameter("@Id", Id, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.ComandText1 = "MST_Party_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1, Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }
    }
}
