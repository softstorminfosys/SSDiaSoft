using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace Param_Hospital
{
    class Patient_and_Services
    {
        SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"]);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public string patientname { get; set;}
        public DataSet patientgrid() {
            ds = new DataSet();
            cmd = new SqlCommand("patientselect", cn);
            cmd.Parameters.AddWithValue("@pname", patientname);
            //da = new SqlDataAdapter("patientselect", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }
        public string doctorname { get; set; }
        public DataSet doctorgrid()
        {
            ds = new DataSet();
            cmd = new SqlCommand("doctorselect", cn);
            cmd.Parameters.AddWithValue("@dname", doctorname);
            //da = new SqlDataAdapter("patientselect", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }
        public int pid { get; set; }
        public int did { get; set; }
        public DateTime opddate { get; set; }
        public int amount { get; set; }
        public string opdremark { get; set; }


        public int opdsave()
        {

            cmd = new SqlCommand("opdinsert", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@opddate", opddate);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@remark", opdremark);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }
    }


}
