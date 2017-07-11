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
    public class Karkhana_Return_Function
    {
        Operation Ope = new Operation();

        public int InsertUpdate(Karkhana_Return_Property pProperty)
        {
            Request Request = new Request();
            Request.AddParameter("@Id",pProperty.Id,DbType.Int32,ParameterDirection.Input);
            Request.AddParameter("@KarkhanaId", pProperty.KarkhanaId, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@IssueDate", pProperty.ReturnDate, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@ReturnDate", pProperty.ReturnDate, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@NotNo", pProperty.NotNo, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@KatNo", pProperty.KatNo, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Kharididate", pProperty.Kharididate, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@Cts", pProperty.KachuVajan, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@Rate", pProperty.Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@Amount", pProperty.Amount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@BanvaChadelu", pProperty.BanvaChadelu, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@VajanLoss", pProperty.VajanLoss, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@VajanGhatt", pProperty.VajanGhatt, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@PalsuVajan", pProperty.PalsuVajan, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@PalsuRate", pProperty.PalsuRate, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@PalsuAmount", pProperty.PalsuAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@ChokiVajan", pProperty.ChokiVajan, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@ChokiRate", pProperty.ChokiRate, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@ChokiAmount", pProperty.ChokiAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@DblVajan", pProperty.DblVajan, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@DblRate", pProperty.DblRate, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@DblAmount", pProperty.DblAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@PCDAmount", pProperty.PCDAmount, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@Than", pProperty.Than, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@ThanTotal", pProperty.ThanTotal, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@TaiyarVajan", pProperty.TaiyarVajan, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@TaiyarPadatar", pProperty.TaiyarPadatar, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@CommPadatar", pProperty.CommPadatar, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@FinalPadatar", pProperty.FinalPadatar, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@STaka", pProperty.STaka, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@RafTaka", pProperty.RafTaka, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@ThanMajuri", pProperty.ThanMajuri, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@CommMajuri", pProperty.CommMajuri, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@FinalPer", pProperty.FinalPadatarTaka, DbType.Double, ParameterDirection.Input);
            Request.AddParameter("@Status", pProperty.Status, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.ComandText1 = "Karkhana_IssueReturn_InsertUpdate";
            Request.CommandType = CommandType.StoredProcedure;
            ArrayList arrlist = Ope.ExecuteQueryWithValue(Operation.ConnectionString1,Request);
            Int32 RetVal = (Int32)arrlist[0];
            return RetVal;
        }

        public int Delete(int Id, int KarkhanaId, string NotNo, string KatNo)
        {
            Request Request = new Request();
            Request.AddParameter("@Id", Id, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@KarkhanaId", KarkhanaId, DbType.Int32, ParameterDirection.Input);
            Request.AddParameter("@NotNo", NotNo, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@KatNo", KatNo, DbType.String, ParameterDirection.Input);
            Request.AddParameter("@ReturnValue", 0, DbType.Int32, ParameterDirection.Output);
            Request.ComandText1 = "Karkhana_IssueReturn_Delete";
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
            Request.ComandText1 = "Karkhana_IssueReturn_GetDataForGrid";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(Operation.ConnectionString1, dt, Request);
            return dt;
        }

    }
}
