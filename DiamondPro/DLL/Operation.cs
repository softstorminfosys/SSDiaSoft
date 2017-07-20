using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace InterviewDemo.DLL
{
    public class Operation
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        public static string MDI = "DiamondPro.FrmMDI";
        private SqlTransaction _Transaction;

        public SqlTransaction Transaction
        {
            get { return _Transaction; }
            set { _Transaction = value; }
        }

        private static string ConnectionString;

        public static string ConnectionString1
        {
            get { return ConnectionString; }
            set { ConnectionString = value; }
        }

        private void CreateAllObjects(string ConnStr)
        {
            try
            {
                connection.ConnectionString = ConnStr;
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                               
                command = new SqlCommand();
                DataAdapter = new SqlDataAdapter();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't Create DB Connection","Connection");
            }
        }

        private void DisposeAllObjects(SqlConnection Conn)
        {
            try
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }

                if (DataAdapter != null)
                {
                    DataAdapter.Dispose();
                    DataAdapter = null;
                }

                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                        Conn = null;
                    }
                }
                else
                {
                    Conn = null;
                }
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_Transaction == null)
            {
                Transaction = connection.BeginTransaction();
            }

            return Transaction;
        }

        public void CommitTransaction()
        {
            if (_Transaction != null)
            {
                Transaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (_Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void ClearParameter(Request pRequest)
        {
            if (pRequest != null)
            {
                if (pRequest.CollectionParameters != null)
                {
                    pRequest.CollectionParameters.Clear();
                }
                pRequest.CollectionParameters = null;
                pRequest = null;
            }
        }

        private SqlParameter[] GetParameter(Request pRequest)
        {
            if (pRequest.CollectionParameters != null)
            {
                int i = 0;
                SqlParameter[] GetParam = new SqlParameter[pRequest.CollectionParameters.Count];
                foreach(ParameterInfo Param in pRequest.CollectionParameters)
                {
                    GetParam[i] = new SqlParameter(Param.ParameterName1,Param.ParameterType);
                    GetParam[i].Value = Param.ParameterValue;
                    GetParam[i].Direction = Param.ParameterDirection;
                    i++;
                }
                ClearParameter(pRequest);
                return GetParam;
            }
            return null;
        }

        private void FillDataTable(string connStr, string commandtext, CommandType commandType, SqlParameter[] ParameterList, DataTable dt)
        {
            try
            {
                CreateAllObjects(connStr);
                command.CommandText = commandtext;
                command.CommandType = commandType;
                command.Connection = connection;

                if (ParameterList != null && commandType == CommandType.StoredProcedure)
                {
                    for (int i = 0; i < ParameterList.Length; i++)
                    {
                        if (ParameterList[i] != null)
                            command.Parameters.Add(ParameterList[i]);
                    }

                    if (dt != null)
                    {
                        dt.Rows.Clear();
                        dt.Columns.Clear();
                    }

                    DataAdapter.SelectCommand = command;

                    DataAdapter.Fill(dt);
                }
                else if (commandType == CommandType.Text)
                {
                    if (dt != null)
                    {
                        dt.Rows.Clear();
                        dt.Columns.Clear();
                    }

                    DataAdapter.SelectCommand = command;

                    DataAdapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DisposeAllObjects(connection);
            }
        }

        public void FillDataSet(string pStrConnectionString, DataSet pDs, string pStrTableName, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, string pStrPrimaryKeys = "")
        {          
            try
            {
                CreateAllObjects(pStrConnectionString);
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = pStrCommandText;
                command.Connection = connection;

                command.CommandType = pEnmCommandType;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    //for (int IntI = 0; IntI < pIntRefCurOut; IntI++)
                    //{
                    //    if (IntI == 0)
                    //    {
                    //        Command.Parameters.Add("REF_CUR_OUT", OracleType.Cursor).Direction = ParameterDirection.Output;
                    //    }
                    //    else
                    //    {
                    //        Command.Parameters.Add("REF_CUR_OUT" + IntI.ToString(),  OracleType.Cursor).Direction = ParameterDirection.Output;
                    //    }

                    //}

                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            command.Parameters.Add(pParamList[i]);
                    }
                }

                if (pDs.Tables[pStrTableName] != null)
                {
                    pDs.Tables[pStrTableName].Rows.Clear();
                }


                DataAdapter.SelectCommand = command;

                DataAdapter.Fill(pDs, pStrTableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DisposeAllObjects(connection);
                if (pStrPrimaryKeys != "")
                {
                    string[] StrArray;
                    StrArray = pStrPrimaryKeys.Split(',');
                    DataColumn[] DataColumnPrimaryKey;
                    DataColumnPrimaryKey = new DataColumn[StrArray.GetUpperBound(0) + 1];
                    for (int IntCount = 0; IntCount <= StrArray.GetUpperBound(0); IntCount++)
                    {
                        DataColumnPrimaryKey[IntCount] = pDs.Tables[pStrTableName].Columns[IntCount];
                    }
                    pDs.Tables[pStrTableName].PrimaryKey = DataColumnPrimaryKey;
                    DataColumnPrimaryKey = null;
                }
            }
        }

        private ArrayList ExecuteNonQueryWithValue(ArrayList AL, string connStr, string CommandText, CommandType CommandType, SqlParameter[] ParamList, SqlTransaction pTransaction = null)
        {
            int RetValue = 0;
            try
            {
                CreateAllObjects(connStr);
                //Transaction = BeginTransaction();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = CommandText;
                command.Connection = connection;
                //command.Transaction = pTransaction;

                if (CommandType == System.Data.CommandType.StoredProcedure && ParamList != null)
                {
                    command.CommandType = CommandType;
                    for (int i = 0; i < ParamList.Length; i++)
                    {
                        if (ParamList[i] != null)
                        {
                            if ((ParamList[i].DbType == DbType.String || ParamList[i].DbType == DbType.AnsiString) && ParamList[i].Direction == ParameterDirection.Output)
                            {
                                ParamList[i].Size = 500;
                            }
                            command.Parameters.Add(ParamList[i]);
                        }
                    }

                }
                else if (CommandType == System.Data.CommandType.Text)
                {
                    command.CommandType = System.Data.CommandType.Text;
                }

                RetValue = command.ExecuteNonQuery();

                AL.Clear();
                foreach (SqlParameter iparam in ParamList)
                {
                    if (iparam.Direction == ParameterDirection.Output || iparam.Direction == ParameterDirection.InputOutput || iparam.Direction == ParameterDirection.ReturnValue)
                    {
                        AL.Add(iparam.Value);
                    }
                }
                //Transaction.Commit();
            }
            catch (Exception ex)
            {
                //Transaction.Rollback();
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            { 
                DisposeAllObjects(connection); 
                
            }
            return AL;

        }

        public DataRow GetDataRow(string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null)
        {
            DataTable DTab = new DataTable();
            DataRow DRow = null;
            try
            {
                FillDataTable(pStrConnectionString, pStrCommandText, pEnmCommandType, pParamList,  DTab);
                if (DTab.Rows.Count != 0)
                {
                    DRow = DTab.Rows[0];
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DTab = null;
                DisposeAllObjects(connection);
            }
            return DRow;
        }


        public DataRow GetDataRow(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            DataTable DTab = new DataTable();
            DataRow DRow = null;
            try
            {
                string StrQuery = "Select " + pStrField + " From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

                DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DTab = null;
                DisposeAllObjects(connection);
            }
            return DRow;
        }

        public string FindText(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            string StrRes = "";

            string StrQuery = "Select " + pStrField + " As ID From " + pStrTableName + " Where 1=1 AND " + pStrCriteria + "";

            DataRow DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            if (DRow != null)
            {
                StrRes = DRow["ID"].ToString();
            }
            DRow = null;
            return StrRes;
        }

        public void GetDataTable(string ConnStr,  DataTable DTab, Request pRequest)
        {
            FillDataTable(ConnStr, pRequest.ComandText1, pRequest.CommandType, GetParameter(pRequest),DTab);
        }

        public void GetDataSet(string ConnStr,  DataSet DS, string Tablename, Request pRequest)
        {
            FillDataSet(ConnStr, DS, Tablename, pRequest.ComandText1, pRequest.CommandType, GetParameter(pRequest));
        }

        public ArrayList ExecuteQueryWithValue(string ConnStr, Request pRequest, SqlTransaction pTransaction = null)
        {
            ArrayList AL = new ArrayList();
            ExecuteNonQueryWithValue(AL, ConnStr, pRequest.ComandText1, pRequest.CommandType, GetParameter(pRequest), pTransaction);
            ClearParameter(pRequest);
            return AL;
        }

    }
}
